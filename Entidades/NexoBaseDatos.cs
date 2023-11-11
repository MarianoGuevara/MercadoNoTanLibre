using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Entidades
{
    public class NexoBaseDatos : IConversorImplicito<ETipoProducto>
    {
        private static string stringConector;
        private SqlConnection conexionSql;
        private SqlCommand comunicadorSql;
        static NexoBaseDatos()
        {
            NexoBaseDatos.stringConector = Properties.Resources.StringConector;
        }
        public NexoBaseDatos()
        {
            this.conexionSql = new SqlConnection(NexoBaseDatos.stringConector);
        }

        public void AgregarObjeto(ObjetoEnVenta objeto)
        {
            try
            {
                this.conexionSql.Open();

                this.comunicadorSql = new SqlCommand();

                this.comunicadorSql.CommandType = System.Data.CommandType.Text;
                this.comunicadorSql.Connection = this.conexionSql;

                string tipo = this.DeEnumParaString(objeto.TipoProducto);
                this.comunicadorSql.Parameters.AddWithValue("@tipoProducto", tipo);
                this.comunicadorSql.Parameters.AddWithValue("@precio", objeto.Precio);
                this.comunicadorSql.Parameters.AddWithValue("@durabilidad", objeto.DurabilidadAproximada);
                this.comunicadorSql.Parameters.AddWithValue("@Descripcion", objeto.Descripcion);

                string tipoProductoEspecifico = string.Empty;
                if (objeto is Electrodomestico)
                {
                    tipoProductoEspecifico = ((Electrodomestico)objeto).DeEnumParaString(((Electrodomestico)objeto).TipoElectodomestico);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoElectrodomestico", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@marca", ((Electrodomestico)objeto).Marca);

                    this.comunicadorSql.CommandText = "insert into Electrodomestico (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoElectrodomestico,marca) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoElectrodomestico,@marca)";
                }
                else if (objeto is Ropa)
                {
                    tipoProductoEspecifico = ((Ropa)objeto).DeEnumParaString(((Ropa)objeto).TipoRopa);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoRopa", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@color", ((Ropa)objeto).Color);

                    this.comunicadorSql.CommandText = "insert into Ropa (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoRopa,color) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoRopa,@color)";
                }
                else if (objeto is Alimento)
                {
                    tipoProductoEspecifico = ((Alimento)objeto).DeEnumParaString(((Alimento)objeto).TipoAlimento);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoAlimento", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@kcal", ((Alimento)objeto).Kcal);

                    this.comunicadorSql.CommandText = "insert into Alimento (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoAlimento,kcal) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoAlimento,@kcal)";
                }
                int filasModificadas = this.comunicadorSql.ExecuteNonQuery();

            }
            catch { throw new ExcepcionErrorConBaseDatos("Error agregando objeto a base de datos") ; }
            finally
            {
                if (this.conexionSql.State == System.Data.ConnectionState.Open)
                {
                    this.conexionSql.Close();
                }
            }
        }

        public List<ObjetoEnVenta> DeserializarProductosEspecifico(string producto)
        {
            List<ObjetoEnVenta> lista = new List<ObjetoEnVenta>();
            if (producto == "E") this.comunicadorSql.CommandText = "select * from Electrodomestico";
            else if (producto == "R") this.comunicadorSql.CommandText = "select * from Ropa";
            else if (producto == "A") this.comunicadorSql.CommandText = "select * from Alimento";
            else throw new ExcepcionErrorConBaseDatos("Error; tabla inexistente");

            SqlDataReader lector = this.comunicadorSql.ExecuteReader();

            while (lector.Read())
            {
                ETipoProducto tipoProducto = this.DeStringParaEnum((string)lector["tipoProducto"]);
                double precio = (double)lector["precio"];
                short durabilidad = (short)lector["durabilidad"];
                string Descripcion = (string)lector["Descripcion"];

                switch (producto)
                {
                    case "E":
                        Electrodomestico e = new Electrodomestico();
                        ETipoElecto tipoElectrodomestico = e.DeStringParaEnum((string)lector["tipoElectrodomestico"]);
                        string marca = (string)lector["marca"];

                        Electrodomestico e2 = new Electrodomestico(tipoProducto, precio, 
                                                durabilidad, tipoElectrodomestico, marca);
                        lista.Add(e2);
                        break;
                    case "R":
                        Ropa r = new Ropa();
                        ETipoRopa tipoRopa = r.DeStringParaEnum((string)lector["tipoRopa"]);
                        string color = (string)lector["color"];

                        Ropa e2 = new Ropa(tipoProducto, precio,
                                                durabilidad, tipoElectrodomestico, marca);
                        lista.Add(e2);
                        break;
                    case "A":
                        double sueldo = (double)lector["sueldo"];
                        Trabajador t = new Trabajador(nombre, edad, tipoUsuario, contrasena,
                                                      codigoTrabajador, sueldo);
                        break;
                }

            }
            return lista;
        }

        public List<ObjetoEnVenta> DeserializarBaseDeDatos()
        {
            List<ObjetoEnVenta> lista = new List<ObjetoEnVenta>();
            try
            {
                this.comunicadorSql = new SqlCommand();
                this.comunicadorSql.CommandType = System.Data.CommandType.Text;
                this.comunicadorSql.Connection = this.conexionSql;
                this.conexionSql.Open();


                return lista;
            }
            catch { throw new ExcepcionErrorConBaseDatos("Error al traer el catalogo desde la base de datos"); }

        }



        public string DeEnumParaString(ETipoProducto tipo)
        {
            string retorno = string.Empty;
            switch (tipo)
            {
                case ETipoProducto.Ropa:
                    retorno = "Ropa";
                    break;
                case ETipoProducto.Electrodomestico:
                    retorno = "Electrodomestico";
                    break;
                case ETipoProducto.Alimento:
                    retorno = "Alimento";
                    break;
            }
            return retorno;
        }

        public ETipoProducto DeStringParaEnum(string obj)
        {
            ETipoProducto eTipo = ETipoProducto.Ropa;
            switch (obj)
            {
                case "Ropa":
                    eTipo = ETipoProducto.Ropa;
                    break;
                case "Electrodomestico":
                    eTipo = ETipoProducto.Electrodomestico;
                    break;
                case "Alimento":
                    eTipo = ETipoProducto.Alimento;
                    break;
            }
            return eTipo;
        }
    }
}
