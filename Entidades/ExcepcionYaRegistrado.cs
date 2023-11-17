using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que representa un error especifico; objeto ya existente en la lista
    /// </summary>
    public class ExcepcionYaRegistrado : Exception
    {
        public ExcepcionYaRegistrado(string msj) : base(msj) { }
    }
}
