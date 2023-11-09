using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que representa la plataforma, es decir, la appa principal, con su lista de objetos
    /// tanto en venta como ya vendidos, con sus usuarios registrados, etc
    /// </summary>
    public sealed class Plataforma : ICrud<ObjetoEnVenta>
    {
        private List<Usuario> usuarios;
        private List<ObjetoEnVenta> objetosEnVenta;
        private List<ObjetoEnVenta> objetosVendidos;
        private string nombrePlataforma;
        public List<Usuario> Usuarios 
        {
            get { return this.usuarios; } 
            set { this.usuarios = value; }
        }
        public List<ObjetoEnVenta> ObjetosEnVenta 
        { 
            get { return this.objetosEnVenta; } 
            set { this.objetosEnVenta = value; }
        }
        public List<ObjetoEnVenta> ObjetosVendidos
        {
            get { return this.objetosVendidos; }
            set { this.objetosVendidos = value; }
        }
        public string NombrePlataforma { get { return this.nombrePlataforma; } }
        public int CantidadUsuarios { get { return usuarios.Count; } }
        
        /// <summary>
        /// Constructores. Inicializa las listas y atributos.
        /// </summary>
        public Plataforma() 
        {
            this.usuarios = new List<Usuario>(); 
            this.objetosEnVenta = new List<ObjetoEnVenta>();
            this.objetosVendidos = new List<ObjetoEnVenta>();
            this.nombrePlataforma = "SIN NOMBRE";
        }
        public Plataforma(string nombre) : this() { this.nombrePlataforma = nombre; }

        /// <summary>
        /// Compara si un usuario está registrado en la plataforma, recorriendo toda la
        /// lista de users y llamando a la sobrecarga == entre 2 users.
        /// </summary>
        /// <param name="p">La plataforma que contiene usuarios</param>
        /// <param name="user">El usuario que quiere verse si está registrado o no</param>
        /// <returns>entero con el indice del usuario si existe, y un -1 si no existe</returns>
        public static int operator ==(Plataforma p, Usuario user)
        {
            int retorno = -1;
            for (int i = 0; i <= p.usuarios.Count - 1; i++)
            {
                if (p.usuarios[i].Equals(user)) retorno = i;
            }
            return retorno;
        }
        /// <summary>
        /// Si un usuario no está, devuelve -1, y si está, su indice
        /// </summary>
        /// <param name="p"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int operator !=(Plataforma p, Usuario user)
        {
            int retorno = -1;
            if ((p == user) != -1) retorno = p == user;
            return retorno;
        }

        /// <summary>
        /// Si un usuario no está en la aplicación, lo agrega a la lista de usuario
        /// </summary>
        /// <param name="p"></param>
        /// <param name="u"></param>
        /// <returns>La plataforma con o sin modificacion</returns>
        public static Plataforma operator +(Plataforma p, Usuario u)
        {
            if ((p != u) == -1) p.usuarios.Add(u);
            return p;
        }

        /// <summary>
        /// Muestra los datos de todos los objetos, sumado al string YA COMPRADO
        /// </summary>
        /// <returns></returns>
        public string MostrarObjetosVendidos()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ObjetoEnVenta objeto in this.objetosVendidos)
            {
                sb.AppendLine(objeto.DescripcionProducto(true) + "\n");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Compara si un objeto está en la plataforma o no, llamando al equals correspondiente
        /// </summary>
        /// <param name="p">plataforma con objetos</param>
        /// <param name="o">objeto a comparar en cuestión</param>
        /// <returns>booleano con el resultado de la operacion</returns>
        public static bool operator ==(Plataforma p, ObjetoEnVenta o)
        {
            bool retorno = false;
            foreach (ObjetoEnVenta o2 in p.objetosEnVenta)
            {
                if (o.Equals(o2)) retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Plataforma p, ObjetoEnVenta o)
        {
            return !(p == o);
        }

        /// <summary>
        /// Si un objeto en venta no está en la plataforma, lo agrega a la lista de objetos
        /// </summary>
        /// <param name="p">plataforma con objetos</param>
        /// <param name="o">objeto a comparar en cuestión</param>
        /// <returns>La plataforma, con o sin modificación</returns>
        public static Plataforma operator +(Plataforma p, ObjetoEnVenta o)
        {
            if (p != o) p.objetosEnVenta.Add(o);
            return p;
        }
        public static Plataforma operator -(Plataforma p, ObjetoEnVenta o)
        {
            if (p == o) p.objetosEnVenta.Remove(o);
            return p;
        }
        public void Agregar(ObjetoEnVenta o)
        {
            Plataforma p = new Plataforma();
            p = this; // le pongo p = this porque this es solo lectura y no me deja hacerle +=
            p += o;
        }

        public void Eliminar(ObjetoEnVenta o)
        {
            Plataforma p = new Plataforma();
            p = this;
            p -= o;
        }
        public void Editar(ObjetoEnVenta o, int indiceListaCrud)
        {
            this.ObjetosEnVenta[indiceListaCrud] = o;
        }

        //public void Leer()
        //{
            
        //}

    }
}