using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    internal class Book
    {

        internal string LibraryBookCode { get; set; } = string.Empty; //Tine evidenta cartilor din biblioteca(cui au fost imprumutate etc)
        internal string Name { get; set; } = string.Empty;
        internal string Author { get; set; } = string.Empty;
        internal string ISBN { get; set; } = string.Empty; //ISBN per book + author + publisher(dupa ISBN pot calcula stocul)
        internal double RentalPrice { get; set; }
        internal DateTime RentalDate { get; set; }  

    }
}
