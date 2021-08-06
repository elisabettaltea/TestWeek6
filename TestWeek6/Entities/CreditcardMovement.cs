using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class CreditcardMovement : Movimento
    {
        public string NumeroCarta { get; set; }
        public TipoCarta Tipo { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", [Numero della carta] {NumeroCarta}, [Tipo di carta] {Tipo}";
        }
    }
}
