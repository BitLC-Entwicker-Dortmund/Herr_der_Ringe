using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Herr_der_Ringe {

    delegate void ErlebnisHandler ( );

    class Hobbit {
        public string Name { get; set; }
        private Dictionary<string , bool> praegendeErlebnisse = new Dictionary<string , bool> ( );
        private int Anzahl = 0;
        // Hobbit fertigt Ring selbständig an ...
        private Ring MeinSchatz = new Ring ( ); 
        // Eventhandler bereitstellen
        public event ErlebnisHandler ProblemHandler;

        // Konstruktor - Erlebnisse werden benannt, Probleme jedoch nicht gelöst!
        public Hobbit ( ) {
            praegendeErlebnisse.Add ( "ErstesErlebnis" , false );
            praegendeErlebnisse.Add ( "ZweitesErlebnis" , false );
            praegendeErlebnisse.Add ( "DrittesErlebnis" , false );
        }

        // Löse Problem und halte das fest ...
        public void SchliesseErlebnisAb ( string erlebnis) {
            if ( praegendeErlebnisse [ erlebnis ] == false ) {
                praegendeErlebnisse[erlebnis] = true;
                Anzahl++;
            }            
        }

        // wird aufgerufen wenn das Problemhandler Event eintritt!
        public void OnProblemeGeloest ( ) {
            Console.WriteLine ("Alle drei Abenteurer bestanden!");
            Console.WriteLine ( "Auf dem Weg zum Schicksalsberg ...");
            Thread.Sleep ( 5000 );
            Console.WriteLine ( "Ring entsorgen ...");
            MeinSchatz.IsDa = false;
            Thread.Sleep ( 5000 );
            Console.WriteLine ("Ring in Magma auflösen!");
            MeinSchatz = null;
            Thread.Sleep (5000 );
            Console.WriteLine ( "Der Ring ist weg ...");
        }

        // sehr lineares Leben eines Hobbits
        public void Lebe ( ) {
            Console.WriteLine ( "Das goldene Problem besteht!");
            SchliesseErlebnisAb ( "ErstesErlebnis" );
            Console.WriteLine ("lebe weiter nach erstem Problem");
            SchliesseErlebnisAb ( "ZweitesErlebnis" );
            Console.WriteLine ( "lebe weiter nach zweitem Problem" );
            SchliesseErlebnisAb ( "DrittesErlebnis" );
            Console.WriteLine ("das Letze Problem ist gelöst ...");

            if ( this.Anzahl < 3  ) {
                Console.WriteLine ( "Irgendein Problem gibt es immer ...");
            }
            else {
                ProblemHandler ( );
                Console.WriteLine ( "Problemhandler aufgerufen");
            }
            Console.WriteLine ( "lebe lädiert weiter" );
        }
    }
}
