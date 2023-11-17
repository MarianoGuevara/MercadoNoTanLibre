using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Excepcion que representa un error especifico; se intenta utilizar una sobrecarga de 
    /// un metodo que no es apta en la clase del momento
    /// </summary>
    public class ExcepcionSobrecargaInvalida : Exception
    {
        public ExcepcionSobrecargaInvalida(string msj) : base(msj) { }
    }
}
