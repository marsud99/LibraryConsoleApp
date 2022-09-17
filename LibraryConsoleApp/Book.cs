using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    internal class Book
    {   
        internal string LibraryBookCode { get; set; }  //Tine evidenta cartilor din biblioteca(cui au fost imprumutate etc)
        internal string Name { get; set; }
        internal string Author { get; set; }
        internal string ISBN { get; set; } //ISBN per book + author + publisher(dupa ISBN pot calcula stocul)
        internal double RentalPrice { get; set; }
        internal DateTime RentalDate { get; set; }  

    }
}
