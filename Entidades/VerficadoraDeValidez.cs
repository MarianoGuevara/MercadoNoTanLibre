using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class VerficadoraDeValidez : IVerificador
    {
        public T Parsear<T>(string dato) where T : struct 
        {
            try
            {
                T resultado = (T)Convert.ChangeType(dato, typeof(T));
                return resultado;
            }
            catch { throw; }
        }
        public bool VerificarLargoString(string dato, int largoMinimo) 
        {
            bool resultado = false;
            if (dato.Length >= largoMinimo) resultado = true;
            return resultado; 
        }
        /// <summary>
        /// Verifica, con expresiones regulares, si un string es valido para ser un correo o no 
        /// </summary>
        /// <param name="input"> Se espera un string a analizar </param>
        /// <returns> Devuelve un booleano indicando si es valido o no  </returns>
        public bool VerificarMail(string input)
        {
            bool retorno = true;
            string matcheo = Regex.Match(input, @"[A-Z|a-z|0-9]+@[a-z|A-Z]+.com").ToString();
            if (matcheo.Length == 0)
            {
                matcheo = Regex.Match(input, @"[A-Z|a-z|0-9]+@[a-z|A-Z]+.com.[a-z|A-Z]+").ToString();
                if (matcheo.Length == 0) retorno = false;
            }
            return retorno;
        }

        //abstract  bool CrearObjeto() { return false; }
    }
}
