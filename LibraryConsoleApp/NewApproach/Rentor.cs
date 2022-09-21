using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.NewApproach
{
    internal class Rentor:User
    {
        internal string RentorBrand { get; set; } = string.Empty;
        internal List<Book> RentedBooks { get; set; } = null!;


    }



}
