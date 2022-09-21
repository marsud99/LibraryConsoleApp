using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.NewApproach
{
    internal class Librarian:User
    {
        internal string EmployeeBrand { get; set; } = string.Empty;

        public void AddBook(MockDbContext dbContext)
        {
        Loop:
            Console.WriteLine("Please input the following information for the book you want to add: \n");
            Console.WriteLine("Library Book Code: "); var libraryBookCode = Console.ReadLine();
            foreach (var book in dbContext.booksAvailable)
            {
                if (book.LibraryBookCode == libraryBookCode)
                {
                    Console.WriteLine("The library book code you inserted is already used. Please use another!");
                    goto Loop;
                }
            }

            foreach (var user in dbContext.users)
            {
                if(user.GetType()== typeof(Rentor))
                {
                    var rentor = (Rentor)user;

                    foreach (var book in rentor.RentedBooks)
                    {
                        if (book.LibraryBookCode == libraryBookCode)
                        {
                            Console.WriteLine($"The library book code you inserted is already used by a rented book by user with Rentor brand : {rentor.RentorBrand}. Please use another!");
                            goto Loop;
                        }
                    }
                }

            }

            Console.WriteLine("Book Name: "); var bookName = Console.ReadLine();
            Console.WriteLine("Author: "); var author = Console.ReadLine();
            Console.WriteLine("ISBN: "); var ISBN = Console.ReadLine();
            Console.WriteLine("RentalPrice: ");

            double rentalPrice;

            while (!double.TryParse(Console.ReadLine(), out rentalPrice))
            {
                Console.Write("This is not valid input. Please enter a double value shown above: \n");
            }

            if (libraryBookCode != null && bookName != null && author != null && ISBN != null)
            {
                Book newbook = new Book()
                {
                    Name = bookName,
                    Author = author,
                    LibraryBookCode = libraryBookCode,
                    ISBN = ISBN,
                    RentalPrice = rentalPrice
                };
                dbContext.booksAvailable.Add(newbook);
            }
        }

        public void DeleteBook(MockDbContext dbContext)
        {
            Loop:
            Console.WriteLine("Please input the library book code of the book you want to delete:"); var libraryBookCode = Console.ReadLine();

            foreach (var user in dbContext.users)
            {
                if (user.GetType() == typeof(Rentor))
                {
                    var rentor = (Rentor)user;

                    foreach (var book in rentor.RentedBooks)
                    {
                        if (book.LibraryBookCode == libraryBookCode)
                        {
                            Console.WriteLine($"The library book code you inserted is already used by a rented book by user with Rentor brand : {rentor.RentorBrand}. Please use another!");
                            goto Loop;
                        }
                    }
                }

            }

            if(dbContext.booksAvailable.FirstOrDefault(x=>x.LibraryBookCode == libraryBookCode) is null)
            {
                Console.WriteLine("The library book code you inserted is not found in available books. Please make sure the code is correct!");
                goto Loop;
            }
            else
            {
            dbContext.booksAvailable.RemoveAll(x => x.LibraryBookCode == libraryBookCode);
                Console.WriteLine("Book successfully deleted!");
            }




        }




    }
}
