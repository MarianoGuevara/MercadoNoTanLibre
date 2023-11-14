using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase padre abstracta de la jerarquia; de ella heredarán los objetos
    /// que sí podrán ser instanciados en la aplicación. Representa las caracteristicas 
    /// báscias de un objeto que estará en el catálogo de la app.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Electrodomestico))]
    [XmlInclude(typeof(Alimento))]
    [XmlInclude(typeof(Ropa))]
    public abstract class ObjetoEnVenta
    {
        private ETipoProducto tipoProducto;
        private double precio;
        private short durabilidad;
        public string Descripcion { get; set; }

        private event DelegadoMostrar EventoMuestra;
        private event DelegadoIgualdad EventoIgualdad;

        public ETipoProducto TipoProducto
        {
            get { return this.tipoProducto; } 
            set { this.tipoProducto = value;}
        }
        public double Precio 
        {
            get { return this.precio; }
            set {this.precio = value ; }
        }
        public short DurabilidadAproximada 
        {
            get { return this.durabilidad; } 
            set { this.durabilidad = value ;}
        }

        /// <summary>
        /// Constructor de la clase padre. Como la clase no se puede instanciar, la idea
        /// es que sea llamado por los hijos. Da valor a los atributos propios del objeto
        /// </summary>
        /// <param name="tipoProducto">Asigna valor al tipo de producto</param>
        /// <param name="precio">Asigna valor  al precio</param>
        /// <param name="durabilidad">Asigna valor a la dirabilidad</param>
        protected ObjetoEnVenta(ETipoProducto tipoProducto, double precio, short durabilidad)
        {
            this.Descripcion = string.Empty;
            this.tipoProducto = tipoProducto;
            this.precio = precio;
            this.durabilidad = durabilidad;

            this.EventoMuestra += new DelegadoMostrar(this.DatosProducto);
            this.EventoIgualdad += new DelegadoIgualdad(this.MostrarIgualdad);
        }
        /// <summary>
        /// Constructor vacío. Hecho para que la serialización a xml sea posible
        /// </summary>
        public ObjetoEnVenta():this(ETipoProducto.Ropa, 1,1) { }
        public static bool operator ==(ObjetoEnVenta o1, ObjetoEnVenta o2)
        {
            bool retorno = false;
            if (o1 is null && o2 is null) retorno = true;
            else if (o1 is not null && o2 is not null)
            {
                retorno = o1.tipoProducto == o2.tipoProducto && o1.precio == o2.precio;
            }
            return retorno;
        }
        public static bool operator !=(ObjetoEnVenta o1, ObjetoEnVenta o2)
        {
            return !(o1 == o2);
        }
        public override bool Equals(object? obj) { return this.EventoIgualdad.Invoke(obj); }

        /// <summary>
        /// Llama a la sobrecarga de ==. Si un objeto es del tipo correcto, lo castea y compara
        /// </summary>
        /// <param name="obj">El objeto que sera comparado</param>
        /// <returns>booleano que dice el resultado de la operacion</returns>
        private bool MostrarIgualdad(object? obj)
        {
            bool retorno = false;
            if (obj is ObjetoEnVenta) retorno = this == (ObjetoEnVenta)obj;
            return retorno;
        }

        protected virtual string MostrarProducto() { return this.EventoMuestra.Invoke(); }
        private string DatosProducto() { return $"{this.TipoProducto} - Precio: {this.precio} - Durabilidad {this.durabilidad}"; }
        public abstract string DescripcionProducto();
        public abstract string DescripcionProducto(bool venta);

        /// <summary>
        /// Compara la propiedad precio de 2 objetos a vender
        /// </summary>
        /// <param name="o1">Objeto 1 a comparar</param>
        /// <param name="o2">Objeto 2 a comparar</param>
        /// <returns>devuelve un numero según sea mas grande uno u otro</returns>
        public static int OrdenarObjetoPorPrecioAscendente(ObjetoEnVenta o1, ObjetoEnVenta o2)
        {
            int retorno = -1;
            if (o1.Precio == o2.Precio) retorno = 0;
            else if (o1.Precio > o2.Precio) retorno = 1;
            return retorno;
        }

        /// <summary>
        /// Ordena una lista a modo ascendente y la da vuelta a descendente
        /// </summary>
        /// <param name="plataforma">La plataforma sobre la cual se extrerá la lista a comparar</param>
        public static void OrdenarObjetoPorPrecioDescendente(Plataforma plataforma)
        {
            plataforma.ObjetosEnVenta.Sort(ObjetoEnVenta.OrdenarObjetoPorPrecioAscendente);
            Stack<ObjetoEnVenta> s = ObjetoEnVenta.InvertirListaObjetos(plataforma.ObjetosEnVenta);

            plataforma.ObjetosEnVenta.Clear();
            foreach (ObjetoEnVenta o in s)
            {
                plataforma.ObjetosEnVenta.Add(o);
            }
        }

        /// <summary>
        /// Compara 2 objetos por el tipo (alfabeticamente) Para hacerlo los convierte implicitamente
        /// a strings primero
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static int OrdenarObjetoPorTipoAscendente(ObjetoEnVenta o1, ObjetoEnVenta o2)
        {
            int retorno = -1;
            string strObj1 = o1;
            string strObj2 = o2;

            if (strObj1 == strObj2) retorno = 0;
            else if (String.Compare(strObj1, strObj2) == 1) retorno = 1;
            return retorno; 
        }
        public static void OrdenarObjetoPorTipoDescendente(Plataforma plataforma)
        {
            plataforma.ObjetosEnVenta.Sort(ObjetoEnVenta.OrdenarObjetoPorTipoAscendente);
            Stack<ObjetoEnVenta> s = ObjetoEnVenta.InvertirListaObjetos(plataforma.ObjetosEnVenta);

            plataforma.ObjetosEnVenta.Clear();
            foreach (ObjetoEnVenta o in s)
            {
                plataforma.ObjetosEnVenta.Add(o);
            }
        }

        /// <summary>
        /// Metodo que invierte los valores de una lista y los devuelve en tipo stack
        /// </summary>
        /// <param name="lst">lista a ser invertida</param>
        /// <returns></returns>
        private static Stack<ObjetoEnVenta> InvertirListaObjetos(List<ObjetoEnVenta> lst)
        {
            Stack<ObjetoEnVenta> s = new Stack<ObjetoEnVenta>();
            foreach (ObjetoEnVenta o in lst)
            {
                s.Push(o);
            }
            return s;
        }

        /// <summary>
        /// Sobrecarga de conversion implícita. Sobre un objeto, se transforma su tipo a string
        /// </summary>
        /// <param name="obj"></param>
        public static implicit operator string(ObjetoEnVenta obj) 
        {
            string retorno = "Ropa";
            if (obj.tipoProducto == ETipoProducto.Electrodomestico) retorno = "Electrodomestico";
            else if (obj.tipoProducto == ETipoProducto.Alimento) retorno = "Alimento";;
            return retorno;
        }

    }
}