using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionErrorConBaseDatos : Exception
    {
        public ExcepcionErrorConBaseDatos(string msj) : base(msj) { }
    }
}
