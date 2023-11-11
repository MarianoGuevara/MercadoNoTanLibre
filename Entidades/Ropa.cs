using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase ropa. Hija de ObjetoEnVenta. Es uno de los objetos que se instanciarán
    /// Heredando las caracteristicas de su padre, y teniendo las suyas propias
    /// </summary>
    public sealed class Ropa : ObjetoEnVenta, IConversorImplicito<ETipoRopa>
    {
        private ETipoRopa tipoRopa;
        private string color;

        public ETipoRopa TipoRopa 
        { 
            get { return this.tipoRopa; }
            set {this.tipoRopa = value; }
        }
        public string Color 
        { 
            get { return this.color; } 
            set {this.color = value;}
        }

        /// <summary>
        /// Sobrecarga de constructores; Llamando al constructor padre para no repetir codigo, y 
        /// luego a los propios de la clase, se permite instanciar el objetos dando distintas 
        /// cantidades y ordenes de parámetros
        /// </summary>
        public Ropa(ETipoProducto tipoProducto, double precio, short durabilidad,
                                ETipoRopa tipoRopa, string color)

                                : base(tipoProducto, precio, durabilidad)
        {
            this.tipoRopa = tipoRopa;
            this.color = color;
        }
        public Ropa(ETipoProducto tipoProducto, double precio,
                                short durabilidad, ETipoRopa tipoRopa)

                                : this(tipoProducto, precio, durabilidad,
                                tipoRopa, "verde")
        { }
        public Ropa(ETipoRopa tipoAlimento) : this(ETipoProducto.Ropa, 100, 1, tipoAlimento) { }
        public Ropa() : this(ETipoRopa.Zapatos) { }

        /// <summary>
        /// Compara si un alimento es igual a otro llamando al == del padre y agregandole
        /// una caracteristica mas
        /// </summary>
        public static bool operator ==(Ropa a, Ropa b)
        {
            return (ObjetoEnVenta)a == b && a.tipoRopa == b.tipoRopa;
        }
        public static bool operator !=(Ropa a, Ropa b)
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
            if (obj is Ropa)
            {
                retorno = (Ropa)obj == this && base.Equals(obj);
            }
            return retorno;
        }

        /// <summary>
        /// Muestra todas las caracteristicas del objeto, llamando al MostrarProducto del padre,
        /// que muestra las básicas... a eso, le agrega las propias de ropa
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarProducto()
        {
            return base.MostrarProducto() + $" - {this.tipoRopa} - Color: {this.color}";
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
            return $"¿Desea comprar la Ropa actual?\n '{this.Descripcion}' \n precio: {this.Precio} \n Color: {this.Color}";
        }
        public override string DescripcionProducto(bool venta)
        {
            return $"ROPA YA COMPRADA | " + this.ToString();
        }

        public string DeEnumParaString(ETipoRopa obj)
        {
            string retorno = string.Empty;
            switch (obj)
            {
                case ETipoRopa.Pantalon:
                    retorno = "Pantalon";
                    break;
                case ETipoRopa.Zapatos:
                    retorno = "Zapatos";
                    break;
                case ETipoRopa.Remera:
                    retorno = "Remera";
                    break;
            }
            return retorno;
        }

        public ETipoRopa DeStringParaEnum(string obj)
        {
            ETipoRopa eTipoElectro = ETipoRopa.Pantalon;
            switch (obj)
            {
                case "Pantalon":
                    eTipoElectro = ETipoRopa.Pantalon;
                    break;
                case "Zapatos":
                    eTipoElectro = ETipoRopa.Zapatos;
                    break;
                case "Remera":
                    eTipoElectro = ETipoRopa.Remera;
                    break;
            }
            return eTipoElectro;
        }


    }
}