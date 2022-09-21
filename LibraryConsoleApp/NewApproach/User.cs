using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.NewApproach
{
    internal class User
    {
        internal string Name { get; set; } = string.Empty;
        internal int Age { get; set; }
        internal string UserName { get; set; } = string.Empty;
        internal string Password { get; set; } = string.Empty;


        public Object Login(string username, string password, MockDbContext dbContext)
        {
            var user = dbContext.users.Where(u => u.UserName == username).FirstOrDefault();
            if (user is not null && user.Password == password)
            {
                return user;
            }


            return new Exception("Username or password incorrect!");
        }




    }

}