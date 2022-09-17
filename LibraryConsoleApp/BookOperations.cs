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
        private MockDbContext dbContext = new MockDbContext();

        public void ShowBooks()
        {
            Console.WriteLine("The books available are the following: \n" +
                "------------------------------------------------------------\n");
            var bk = dbContext.booksAvailable.GroupBy(x=>x.ISBN).Select(x=>x.First()).ToList();  
            foreach(Book book in bk)
            {
                Console.WriteLine($"BookName : {book.Name}\n" +
                    $"Author:{book.Author}\n" +
                    $"RentalPrice:{book.RentalPrice}\n");
            }
            Console.WriteLine("------------------------------------------------------------\n");
        }

        public void SearchBook()
        {
            Console.WriteLine("Please input a book name or a book name keyword and I will return the closest match: \n" +
                "------------------------------------------------------------\n");
            var userinput = Console.ReadLine();
            var bk = dbContext.booksAvailable.Where(x => x.Name.ToLower().Contains(userinput.ToLower())).GroupBy(x => x.Name).Select(x=>x.First()).ToList();
            
            if(bk.Count() > 0)
            {
                Console.WriteLine("The books that match are the following: \n" +
                    "------------------------------------------------------------\n");

                foreach (Book book in bk)
                {
                    Console.WriteLine($"BookName : {book.Name}\n" +
                                        $"Author:{book.Author}\n" +
                                        $"RentalPrice:{book.RentalPrice}\n" +
                                        $"Stock:{BookStock(book)} books left\n");
                    
                }
                Console.WriteLine("------------------------------------------------------------\n");
            }
           

        }

        public int BookStock(Book book)
        {
            return dbContext.booksAvailable.Where(x => x.ISBN.Equals(book.ISBN)).Count();
            
        }
    }
}
