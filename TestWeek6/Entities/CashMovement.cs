using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class CashMovement : Movimento
    {
        public string Esecutore { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", [Esecutore] {Esecutore}";
        }
    }
}
