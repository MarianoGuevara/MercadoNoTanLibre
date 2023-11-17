using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que representa un error especifico; cualquier tipo de problema con formato de
    /// datos; parseo, longitud, etc.
    /// </summary>
    public class ExcepcionDatosInvalidos : Exception
    {
        public ExcepcionDatosInvalidos(string msj) : base(msj) { }
    }
}