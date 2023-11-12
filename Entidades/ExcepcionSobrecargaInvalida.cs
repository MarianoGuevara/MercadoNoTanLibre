using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionSobrecargaInvalida : Exception
    {
        public ExcepcionSobrecargaInvalida(string msj) : base(msj) { }
    }
}
