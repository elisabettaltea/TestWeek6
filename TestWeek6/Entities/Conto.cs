using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class Conto
    {
        public int NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        //si potrebbe creare una classe Banca con la proprietà Nome di tipo stringa, ma visto che ci serve solo il nome della banca si può utilizzare una stringa
        public decimal Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
        public IList<Movimento> Movimenti { get; set; } = new List<Movimento>();

        internal void ModificaSaldo(bool isVersamento, decimal importo)
        {
            if (isVersamento)
                Saldo += importo;
            else if (importo > Saldo)
                throw new ImportoNonValidoException("Non è possibile prelevare una cifra superiore al saldo!") { ImportoNonValido = importo };
            else
                Saldo -= importo;
        }
    }
}
