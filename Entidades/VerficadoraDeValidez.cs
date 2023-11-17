using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase hecha especialmente para acceder rapidamente a metodos de parseo o verificacion de
    /// datos, como si cumple con un maximo de longitud.
    /// </summary>
    public class VerficadoraDeValidez : IVerificador
    {
        private event DelegadoVerificarString EventoVerificarLargo;
        public VerficadoraDeValidez() { this.EventoVerificarLargo += this.VerificarLargoString; }

        /// <summary>
        /// Metodo que intenta parsear un string a un dato generico
        /// </summary>
        /// <typeparam name="T">el tipo de dato al que el usuario desea parsear</typeparam>
        /// <param name="dato">el dato que se desea transformar</param>
        /// <returns>El dato en su nuevo tipo de dato o una excepcion</returns>
        /// <exception cref="FormatException">Devuelve una excepcion que contiene 
        /// el dato que no se pudo transformar</exception>
        public T Parsear<T>(string dato) where T : struct 
        {
            try
            {
                T resultado = (T)Convert.ChangeType(dato, typeof(T));
                return resultado;
            }
            catch { throw new FormatException(dato); }
        }

        /// <summary>
        /// Verifica si el string tiene un minimo de caracteres
        /// </summary>
        /// <param name="dato">el dato a chequear</param>
        /// <param name="largoMinimo">el minimo de caracteres</param>
        /// <returns>booleano que determina el resultado de la operacion</returns>
        public bool VerificarLargoString(string dato, int largoMinimo) 
        {
            bool resultado = false;
            if (dato.Length >= largoMinimo) resultado = true;
            return resultado; 
        }


        /// <summary>
        /// Sobrecarga. Verifica si el string se encuentra dentro de un rango de caracteres
        /// </summary>
        /// <param name="dato">el dato a chequear</param>
        /// <param name="largoMinimo">el minimo de caracteres</param>
        /// <param name="largoMaximo">el maximo de caracteres</param>
        /// <returns>booleano que determina el resultado de la operacion</returns>
        public bool VerificarLargoString(string dato, int largoMinimo, int largoMaximo)
        {
            bool resultado = false;
            if (this.EventoVerificarLargo.Invoke(dato, largoMinimo) && dato.Length <= largoMaximo)
                resultado = true;
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
    }
}
