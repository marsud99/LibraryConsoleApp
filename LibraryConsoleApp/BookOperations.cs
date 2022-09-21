using LibraryConsoleApp.NewApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    internal class BookOperations
    {


        public void ShowBooks(MockDbContext dbContext)
        {
            Console.WriteLine("The books available are the following: \n" +
                "------------------------------------------------------------\n");
            var bk = dbContext.booksAvailable.GroupBy(x => x.ISBN).Select(x => x.First()).ToList();
            foreach (Book book in bk)
            {
                Console.WriteLine($"BookName : {book.Name}\n" +
                    $"Author:{book.Author}\n" +
                    $"RentalPrice:{book.RentalPrice}\n" +
                    $"ISBN: {book.ISBN}\n" +
                    $"Stock:{BookStock(book, dbContext)} books left\n");
            }
            Console.WriteLine("------------------------------------------------------------\n");
        }

        public void SearchBook(MockDbContext dbContext)
        {
            Console.WriteLine("Please input a book name or a book name keyword and I will return the closest match: \n" +
                "------------------------------------------------------------\n");
            var userinput = Console.ReadLine();
            var bk = dbContext.booksAvailable.Where(x => x.Name.ToLower().Contains(userinput!.ToLower())).GroupBy(x => x.Name).Select(x => x.First()).ToList();

            if (bk.Count() > 0)
            {
                Console.WriteLine("The books that match are the following: \n" +
                    "------------------------------------------------------------\n");

                foreach (Book book in bk)
                {
                    Console.WriteLine($"BookName : {book.Name}\n" +
                                        $"Author:{book.Author}\n" +
                                        $"RentalPrice:{book.RentalPrice}\n" +
                                        $"ISBN: {book.ISBN}\n" +
                                        $"Stock:{BookStock(book, dbContext)} books left\n");

                }
                Console.WriteLine("------------------------------------------------------------\n");
            }


        }

        public int BookStock(Book book, MockDbContext dbContext)
        {
            return dbContext.booksAvailable.Where(x => x.ISBN.Equals(book.ISBN)).Count();

        }

        public void Rent(Rentor rentor, MockDbContext dbContext)
        {
            Console.WriteLine("Please input book ISBN that you want to rent : "); var isbn = Console.ReadLine();

            var book = dbContext.booksAvailable.Where(x => x.ISBN == isbn).FirstOrDefault();



            dbContext.booksAvailable.RemoveAll(x => x.LibraryBookCode == book!.LibraryBookCode); //Presupunem ca LibraryBookCode este Unique

            book!.RentalDate = DateTime.Now;
            rentor.RentedBooks.Add(book);

            Console.WriteLine("Book successfully rented!\n");
        }

        public void RentedBooks(Rentor rentor, MockDbContext dbContext)
        {
            if (rentor.RentedBooks.Count <= 0)
            {
                Console.WriteLine("You have no rented books\n");
            }

            else
            {
                Console.WriteLine("The books you rented are the following: \n" +
                "------------------------------------------------------------\n");

                foreach (Book book in rentor.RentedBooks)
                {
                    Console.WriteLine($"BookName : {book.Name}\n" +
                        $"Author:{book.Author}\n" +
                        $"RentalPrice:{book.RentalPrice}\n" +
                        $"ISBN: {book.ISBN}\n" +
                        $"LibraryBookCode: {book.LibraryBookCode}\n" +
                        $"RentalDate:{book.RentalDate}\n" +
                        $"Book deadline:{book.RentalDate.AddDays(14)}\n");

                }
                Console.WriteLine("------------------------------------------------------------\n");
            }

        }

        public void ReturnBook(Rentor rentor, MockDbContext dbContext)
        {
        Loop:
            Console.WriteLine("Please input the LibraryBookCode of the book you want to return");
            var librarybookcode = Console.ReadLine();
            var bookToReturn = rentor.RentedBooks.FirstOrDefault(x => x.LibraryBookCode == librarybookcode);
            if (bookToReturn! == null)
            {
                Console.WriteLine("The library book code you inserted is not found in your rented books. Would you like to try again?" +
                    "1.Yes 2.No");

                int userinput;
                while (!int.TryParse(Console.ReadLine(), out userinput) && (userinput < 1 || userinput > 2))
                {
                    Console.Write("This is not valid input. Please enter an integer value shown above: \n");
                }
                if (userinput == 1)
                {
                    goto Loop;
                }


            }
            else
            {
                if ((bookToReturn.RentalDate - DateTime.Now).TotalDays > 14)
                {
                    Console.WriteLine($"Your book rental deadline passed {(bookToReturn.RentalDate - DateTime.Now).TotalDays} days ago." +
                        $"You have to pay {0.01 * bookToReturn.RentalPrice / ((bookToReturn.RentalDate - DateTime.Now).TotalDays - 14)}. ");

                    rentor.RentedBooks.RemoveAll(x => x.LibraryBookCode == librarybookcode);
                    dbContext.booksAvailable.Add(bookToReturn);
                    Console.WriteLine("Thank you for paying. Book returned successfully!");
                }
                else
                {
                    Console.WriteLine($"You have not pass the book rental deadline. You have to pay {bookToReturn.RentalPrice}");
                    rentor.RentedBooks.RemoveAll(x => x.LibraryBookCode == librarybookcode);
                    dbContext.booksAvailable.Add(bookToReturn);
                    Console.WriteLine("Thank you for paying. Book returned successfully!");
                }
            }




        }


        






    }
}