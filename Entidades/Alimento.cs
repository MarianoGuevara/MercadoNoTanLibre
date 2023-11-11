using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase alimento. Hija de ObjetoEnVenta. Es uno de los objetos que se instanciarán
    /// Heredando las caracteristicas de su padre, y teniendo las suyas propias
    /// </summary>
    public sealed class Alimento : ObjetoEnVenta, IConversorImplicito<ETipoAlimento>
    {
        private ETipoAlimento tipoAlimento;
        private int kcal;

        public ETipoAlimento TipoAlimento 
        {
            get { return this.tipoAlimento; } 
            set { this.tipoAlimento = value;}
        }
        public int Kcal 
        {
            get { return this.kcal; } 
            set { this.kcal = value;}
        }

        /// <summary>
        /// Sobrecarga de constructores; Llamando al constructor padre para no repetir codigo, y 
        /// luego a los propios de la clase, se permite instanciar el objetos dando distintas 
        /// cantidades y ordenes de parámetros
        /// </summary>
        public Alimento(ETipoProducto tipoProducto, double precio, short durabilidad,
                        ETipoAlimento tipoAlimento, int kcal)

                        : base(tipoProducto, precio, durabilidad)
        {
            this.tipoAlimento = tipoAlimento;
            this.kcal = kcal;
        }
        public Alimento(ETipoProducto tipoProducto, double precio,
                        short durabilidad, ETipoAlimento tipoAlimento)

                        : this(tipoProducto, precio, durabilidad,
                        tipoAlimento, 500)
        { }
        public Alimento(ETipoAlimento tipoAlimento) : this(ETipoProducto.Alimento, 100, 1, tipoAlimento) { }
        public Alimento() : this(ETipoAlimento.Fruta) { }

        /// <summary>
        /// Compara si un alimento es igual a otro llamando al == del padre y agregandole
        /// una caracteristica mas
        /// </summary>
        public static bool operator ==(Alimento a, Alimento b)
        {
            return (ObjetoEnVenta)a == b && a.tipoAlimento == b.tipoAlimento;
        }
        public static bool operator !=(Alimento a, Alimento b)
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
            if (obj is Alimento)
            {
                retorno = (Alimento)obj == this && base.Equals(obj);
            }
            return retorno;
        }

        /// <summary>
        /// Muestra todas las caracteristicas del objeto, llamando al MostrarProducto del padre,
        /// que muestra las básicas... a eso, le agrega las propias de alimento
        /// </summary>
        /// <returns>string con los datos</returns>
        protected override string MostrarProducto()
        {
            return base.MostrarProducto() + $" - {this.tipoAlimento} - kcal: {this.kcal}";
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
            return $"¿Desea comprar el Alimento actual?\n '{this.Descripcion}' \n precio: {this.Precio} \n Kcals: {this.kcal}";
        }
        public override string DescripcionProducto(bool venta)
        {
            return $"ALIMENTO YA COMPRADO | " + this.ToString();
        }

        public string DeEnumParaString(ETipoAlimento obj)
        {
            string retorno = string.Empty;
            switch (obj)
            {
                case ETipoAlimento.Fruta:
                    retorno = "Fruta";
                    break;
                case ETipoAlimento.Verdura:
                    retorno = "Verdura";
                    break;
                case ETipoAlimento.Carne:
                    retorno = "Carne";
                    break;
            }
            return retorno;
        }

        public ETipoAlimento DeStringParaEnum(string obj)
        {
            ETipoAlimento eTipoElectro = ETipoAlimento.Carne;
            switch (obj)
            {
                case "Carne":
                    eTipoElectro = ETipoAlimento.Carne;
                    break;
                case "Fruta":
                    eTipoElectro = ETipoAlimento.Fruta;
                    break;
                case "Verdura":
                    eTipoElectro = ETipoAlimento.Verdura;
                    break;
            }
            return eTipoElectro;
        }


    }
}