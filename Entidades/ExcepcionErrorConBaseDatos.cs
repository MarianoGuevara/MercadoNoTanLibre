using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que representa un error especifico; cualquier tipo de problema con base de datos
    /// </summary>
    public class ExcepcionErrorConBaseDatos : Exception
    {
        public ExcepcionErrorConBaseDatos(string msj) : base(msj) { }
    }
}
