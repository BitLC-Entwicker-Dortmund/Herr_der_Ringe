using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herr_der_Ringe {
    class Program {
        static void Main ( string [ ] args ) {
            Hobbit h = new Hobbit ( ) { Name = "Frodo" };         
            h.ProblemHandler += h.OnProblemeGeloest;
            h.Lebe ( );

            Console.Read ( );
        }
    }
}
