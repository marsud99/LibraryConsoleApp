using LibraryConsoleApp;
using LibraryConsoleApp.NewApproach;


Console.WriteLine("Hello! Welcome to the Library!\n");
Console.WriteLine("Please login!\n");
MockDbContext dbContext = new MockDbContext();
LoopLogin:
User user = new User();
Console.WriteLine("UserName: "); user.UserName = Console.ReadLine();
if ((user.UserName == "" || user.UserName is null) )
{
    Console.WriteLine("Username cannot be null. Please input a valid username");
    goto LoopLogin;
}
Console.WriteLine("\n");
Console.WriteLine("Password: "); user.Password = Console.ReadLine();

if ((user.Password == "" || user.Password is null))
{
    Console.WriteLine("Password cannot be null. Please input a valid password");
    goto LoopLogin;
}


var loggedUser = user.Login(user.UserName, user.Password, dbContext);

if(loggedUser.GetType() == typeof(Librarian))
{
    Console.WriteLine("Here will be the operations available to Librarian");
}
else if (loggedUser.GetType() == typeof(Rentor))
{
    Console.WriteLine("Here will be the operations available to Rentor");
}





var operations = new BookOperations();
var OK = 1;
while (OK == 1)
{
    Console.WriteLine("1.Show available books");
    Console.WriteLine("2.Search book");
    Console.WriteLine("0.Exit application!");

    double userinput;

    while (!double.TryParse(Console.ReadLine(), out userinput))
    {
        Console.Write("This is not valid input. Please enter an integer value shown above: \n");
    }

    switch (userinput)
    {
        case 1:
            operations.ShowBooks();
            break;
        case 2:
            operations.SearchBook();
            break;
        case 0:
            OK = 0;
            break;

    }
}