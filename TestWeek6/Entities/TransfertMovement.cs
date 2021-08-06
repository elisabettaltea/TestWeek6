using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class TransfertMovement : Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }
        //si potrebbe creare una classe Banca con la proprietà Nome di tipo stringa, ma visto che ci serve solo il nome della banca si può utilizzare una stringa

        public override string ToString()
        {
            return base.ToString() + $", [Banca di origine] {BancaOrigine}, [Banca di destinazione] {BancaDestinazione}";
        }
    }
}
