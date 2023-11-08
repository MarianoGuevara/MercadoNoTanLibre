using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionDatosInvalidos : Exception
    {
        public ExcepcionDatosInvalidos(string msj) : base(msj) { }
    }
}