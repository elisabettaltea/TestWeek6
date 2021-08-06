using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class ImportoNonValidoException : Exception
    {
        public decimal ImportoNonValido { get; set; }

        public ImportoNonValidoException()
        {
        }

        public ImportoNonValidoException(string message) : base(message)
        {
        }

        public ImportoNonValidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImportoNonValidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
