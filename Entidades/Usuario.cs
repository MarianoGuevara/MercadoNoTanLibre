using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase usuario. Representa la persona que está tratando de ingresar a la plataforma
    /// </summary>
    public sealed class Usuario
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public short legajo { get; set; }
        public string clave {get;}
        public string correo {get;}
        public string perfil {get;}

        /// <summary>
        /// Constructor. Da valor a todos los atributos propios de un usuario por parámetro
        /// </summary>
        public Usuario(string nombre, string apellido, string clave, string correo, short legajo, string perfil)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.legajo = legajo;
            this.clave = clave;
            this.correo = correo;
            this.perfil = perfil;
        }
        public override string ToString()
        {
            return $"{this.nombre},{this.apellido}-{this.correo}-{this.legajo}-{this.perfil}";
        }

        /// <summary>
        /// Muestra los datos de un usuario, ademas de la fecha exacta en la que se logueó
        /// </summary>
        /// <returns></returns>
        public string MostrarUserLogin()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.ToString());
            sb.Append($"-({DateTime.Now.Year}/{DateTime.Now.Month}/");
            sb.Append($"{DateTime.Now.Day}[{DateTime.Now.Hour}:{DateTime.Now.Minute},{DateTime.Now.Millisecond}])");
            return sb.ToString();
        }
        public static bool operator ==(Usuario a, Usuario b)
        {
            return a.correo == b.correo && a.clave == b.clave;
        }
        public static bool operator !=(Usuario a, Usuario b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Si el parametro es de tipo usuario, compara a ver si son iguales, llamando a la 
        /// sobrecarga del ==
        /// </summary>
        /// <param name="obj">Objeto a comparar con el usuario actual</param>
        /// <returns>booleano con el resultado de la operación</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Usuario) return this == (Usuario)obj;
            else return false;
        }
    }
}