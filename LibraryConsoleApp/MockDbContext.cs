using LibraryConsoleApp.NewApproach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    internal class MockDbContext 
    {
        public List<Book> booksAvailable = new List<Book>()
        {
              new Book()
              {
                  LibraryBookCode = "BK01",
                  Name = "Where the crawdads sing",
                  Author = "Olivia Newman",
                  ISBN = "9781234567897",
                  RentalPrice = 5.99


              },
              new Book()
              {
                  LibraryBookCode = "BK02",
                  Name = "Where the crawdads sing",
                  Author = "Olivia Newman",
                  ISBN = "9781234567897",
                  RentalPrice = 5.99


              },
              new Book()
              {
                  LibraryBookCode = "BK03",
                  Name = "Where the crawdads sing",
                  Author = "Olivia Newman",
                  ISBN = "9781234567897",
                  RentalPrice = 5.99


              },
              new Book()
              {
                  LibraryBookCode = "BK04",
                  Name = "Where the crawdads sing",
                  Author = "Olivia Newman",
                  ISBN = "9781234567897",
                  RentalPrice = 5.99


              },
              new Book()
              {
                  LibraryBookCode = "BK05",
                  Name = "A Tale of Two Cities",
                  Author = "Charles Dickens",
                  ISBN = "9781234567333",
                  RentalPrice = 7.99


              },
              new Book()
              {
                  LibraryBookCode = "BK06",
                  Name = "A Tale of Two Cities",
                  Author = "Charles Dickens",
                  ISBN = "9781234567333",
                  RentalPrice = 7.99


              },
              new Book()
              {
                  LibraryBookCode = "BK07",
                  Name = "The Little Prince",
                  Author = "Antoine de Saint-Exupéry",
                  ISBN = "9781234567223",
                  RentalPrice = 10.99


              },
              new Book()
              {
                  LibraryBookCode = "BK08",
                  Name = "The Hobbit",
                  Author = "J. R. R. Tolkien",
                  ISBN = "9781234564423",
                  RentalPrice = 11.99


              },

        };

        public List<User> users = new List<User>()
        {
            new Rentor()
            {
                Name= "David Ion",
                Age = 22,
                UserName ="davii",
                Password ="davion123",
                RentorBrand = "2332",
                RentedBooks = new List<Book>()

            },
            new Rentor()
            {
                Name= "Sorin Anghel",
                Age = 25,
                UserName ="sorian",
                Password ="sorrrian123x",
                RentorBrand = "2532",
                RentedBooks = new List<Book>()
            },
            new Librarian()
            {
                Name= "Petrescu Marcel",
                Age = 35,
                UserName ="petrema",
                Password ="ptr3332x",
                
            }
        };

    }
}
