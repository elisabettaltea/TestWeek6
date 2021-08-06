using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public abstract class Movimento
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public bool IsVersamento { get; set; } //se è true è un versamento, se è false è un prelievo

        public override string ToString()
        {
            string daStampare;
            if (IsVersamento == true)
                daStampare = "_Versamento_ ";
            else
                daStampare = "_Prelievo_ ";
            return daStampare + $"[Importo] {Importo}, [Data del movimento] {DataMovimento.ToString("dd/MM/yyyy")}";
        }
    }
}
