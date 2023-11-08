using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IVerificador
    {
        bool CrearObjeto();
        bool VerificarLargoString(int largoMinimo);
        bool Parseador<T>(string str) where T : struct ;
    }
}
