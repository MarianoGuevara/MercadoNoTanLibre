using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase electrodomestico. Hija de ObjetoEnVenta. Es uno de los objetos que se instanciarán
    /// Heredando las caracteristicas de su padre, y teniendo las suyas propias
    /// </summary>
    public sealed class Electrodomestico : ObjetoEnVenta
    {
        private ETipoElecto tipoElectrodomestico;
        private string marca;

        public ETipoElecto TipoElectodomestico 
        {
            get { return this.tipoElectrodomestico; } 
            set { this.tipoElectrodomestico = value; }
        }
        public string Marca
        {
            get { return this.marca; } 
            set { this.marca = value; }
        }
        /// <summary>
        /// Sobrecarga de constructores; Llamando al constructor padre para no repetir codigo, y 
        /// luego a los propios de la clase, se permite instanciar el objetos dando distintas 
        /// cantidades y ordenes de parámetros
        /// </summary>
        public Electrodomestico(ETipoProducto tipoProducto, double precio, short durabilidad,
                                ETipoElecto tipoElectodomestico, string marca)

                                :base(tipoProducto,precio,durabilidad)
        {
            this.tipoElectrodomestico = tipoElectodomestico;
            this.marca = marca;
        }
        public Electrodomestico(ETipoProducto tipoProducto, double precio, 
                                short durabilidad, ETipoElecto tipoElectodomestico)
                                
                                :this(tipoProducto,precio,durabilidad, 
                                tipoElectodomestico, "SIN MARCA") { }

        public Electrodomestico(ETipoElecto tipoElectodomestico) :this(ETipoProducto.Electrodomestico, 100, 1, tipoElectodomestico) { }
        public Electrodomestico() : this(ETipoElecto.Lavaropa) { }

        /// <summary>
        /// Compara si un alimento es igual a otro llamando al == del padre y agregandole
        /// una caracteristica mas
        /// </summary>
        public static bool operator ==(Electrodomestico a, Electrodomestico b)
        {
            return (ObjetoEnVenta)a == b && a.tipoElectrodomestico == b.tipoElectrodomestico;
        }
        public static bool operator !=(Electrodomestico a, Electrodomestico b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Compara si un alimento es igual a otro, haciendo uso del equals del padre y 
        /// de su propia sobrecarga
        /// </summary>
        /// <param name="obj">objeto a ser comparado</param>
        /// <returns>booleano que dice el resultado de la operacion</returns>
        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Electrodomestico)
            {
                retorno = (Electrodomestico)obj == this && base.Equals(obj);
            }
            return retorno;
        }

        /// <summary>
        /// Muestra todas las caracteristicas del objeto, llamando al MostrarProducto del padre,
        /// que muestra las básicas... a eso, le agrega las propias de electrodomestico
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarProducto()
        {
            return base.MostrarProducto() + $" - {this.tipoElectrodomestico} - Marca: {this.marca}";
        }
        public override string ToString()
        {
            return this.MostrarProducto();
        }

        /// <summary>
        /// Muestra el detalle del objeto a ser vendido, en el momento antes de la compra
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string DescripcionProducto()
        {
            return $"¿Desea comprar el Electrodomestico actual?\n '{this.Descripcion}' \n precio: {this.Precio} \n Marca: {this.Marca}";
        }
        public override string DescripcionProducto(bool venta)
        {
            return $"ELECTRODOMESTICO YA COMPRADO | " + this.ToString();
        }
    }
}