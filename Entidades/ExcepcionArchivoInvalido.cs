using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que representa un error especifico; cualquier tipo de problema con 
    /// serializacion de archivos
    /// </summary>
    public class ExcepcionArchivoInvalido : Exception
    {
        public ExcepcionArchivoInvalido(string msj) : base(msj) { }
    }
}
