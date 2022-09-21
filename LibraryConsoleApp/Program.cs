using LibraryConsoleApp;
using LibraryConsoleApp.NewApproach;
using System;


// LOGIN --->
Console.WriteLine("Hello! Welcome to the Library!\n");
Console.WriteLine("Please login!\n");

//INSTANTIEZ mockdb o singura data
MockDbContext dbContext = new MockDbContext();


LoopLogin:
User user = new User();
Console.WriteLine("UserName: "); user.UserName = Console.ReadLine()!;
if ((user.UserName == "" || user.UserName is null) )
{
    Console.WriteLine("Username cannot be null. Please input a valid username\n");
    goto LoopLogin;
}
Console.WriteLine("\n");
Console.WriteLine("Password: "); user.Password = Console.ReadLine()!;

if ((user.Password == "" || user.Password is null))
{
    Console.WriteLine("Password cannot be null. Please input a valid password\n");
    goto LoopLogin;
}


var loggedUser = user.Login(user.UserName, user.Password, dbContext);

if (loggedUser.GetType() ==typeof(Exception))
{
    Console.WriteLine(loggedUser);
    goto LoopLogin;
}


//LOGIN <---


var operations = new BookOperations();
var OK = 1;

if (loggedUser.GetType() == typeof(Librarian)) 
{
    var librarian = (global::LibraryConsoleApp.NewApproach.Librarian)loggedUser;
    Console.WriteLine("\nHere are the operations available to Librarian\n");


    while (OK == 1)
    {
        Console.WriteLine("1.Show available books");
        Console.WriteLine("2.Search book");
        Console.WriteLine("3.Add book");
        Console.WriteLine("4.Delete book");
        Console.WriteLine("9.Logout");
        Console.WriteLine("0.Exit application!");

        int userinput;

        while (!int.TryParse(Console.ReadLine(), out userinput))
        {
            Console.Write("This is not valid input. Please enter an integer value shown above: \n");
        }

        switch (userinput)
        {
            case 1:
                operations.ShowBooks(dbContext);
                break;
            case 2:
                operations.SearchBook(dbContext);
                break;
            case 3:
                librarian.AddBook(dbContext);
                break;
            case 4:
                librarian.DeleteBook(dbContext);
                break;
            case 9:
                Console.WriteLine("Successfully logged out! \n");
                goto LoopLogin;
            case 0:
                OK = 0;
                break;

        }
    }
}
else if (loggedUser.GetType() == typeof(Rentor))
{
    Console.WriteLine("\nHere are the operations available to Rentor\n");
    var rentor = (global::LibraryConsoleApp.NewApproach.Rentor)loggedUser;
    while (OK == 1)
    {
        Console.WriteLine("1.Show available books");
        Console.WriteLine("2.Search book");
        Console.WriteLine("3.Rent book");
        Console.WriteLine("4.See rented books");
        Console.WriteLine("5.Return book");
        Console.WriteLine("9.Logout");
        Console.WriteLine("0.Exit application!");

        int userinput;

        while (!int.TryParse(Console.ReadLine(), out userinput))
        {
            Console.Write("This is not valid input. Please enter an integer value shown above: \n");
        }

        switch (userinput)
        {
            case 1:
                operations.ShowBooks(dbContext);
                break;
            case 2:
                operations.SearchBook(dbContext);
                break;
            case 3:
                operations.Rent(rentor, dbContext);
                break;
            case 4:
                operations.RentedBooks(rentor, dbContext);
                break;

            case 5:
                operations.ReturnBook(rentor, dbContext);
                break;
            case 9:
                Console.WriteLine("Successfully logged out! \n");
                goto LoopLogin;
            case 0:
                OK = 0;
                break;

        }
    }
}





