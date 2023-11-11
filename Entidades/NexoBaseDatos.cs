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

        public void AgregarEditarObjeto(ObjetoEnVenta objeto, string accion, ObjetoEnVenta original=null)
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

                    if (accion == "Agregar")
                    {
                        this.comunicadorSql.CommandText = "insert into Electrodomestico (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoElectrodomestico,marca) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoElectrodomestico,@marca)";
                    }
                    else
                    {
                        string tipoProductoStringOriginal = this.DeEnumParaString(original.TipoProducto);
                        string tipoElectrodomesticoStringOriginal = ((Electrodomestico)original).DeEnumParaString(((Electrodomestico)original).TipoElectodomestico);

                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoProducto", tipoProductoStringOriginal);
                        this.comunicadorSql.Parameters.AddWithValue("@originalPrecio", original.Precio);
                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoElectrodomestico", tipoElectrodomesticoStringOriginal);

                        this.comunicadorSql.CommandText = "update Electrodomestico set " +
                        "tipoProducto=@tipoProducto ,precio=@precio ,durabilidad=@durabilidad," +
                        "Descripcion=@Descripcion, tipoElectrodomestico=@tipoElectrodomestico," +
                        "marca=@marca where tipoProducto=@originalTipoProducto and precio=@originalPrecio " +
                        "and tipoElectrodomestico=@originalTipoElectrodomestico";
                    }
                }
                else if (objeto is Ropa)
                {
                    tipoProductoEspecifico = ((Ropa)objeto).DeEnumParaString(((Ropa)objeto).TipoRopa);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoRopa", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@color", ((Ropa)objeto).Color);

                    if (accion == "Agregar")
                    {
                        this.comunicadorSql.CommandText = "insert into Ropa (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoRopa,color) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoRopa,@color)";
                    }
                    else
                    {
                        string tipoProductoStringOriginal = this.DeEnumParaString(original.TipoProducto);
                        string tipoRopaStringOriginal = ((Ropa)original).DeEnumParaString(((Ropa)original).TipoRopa);

                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoProducto", tipoProductoStringOriginal);
                        this.comunicadorSql.Parameters.AddWithValue("@originalPrecio", original.Precio);
                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoRopa", tipoRopaStringOriginal);


                        this.comunicadorSql.CommandText = "update Ropa set " +
                        "tipoProducto=@tipoProducto ,precio=@precio ,durabilidad=@durabilidad," +
                        "Descripcion=@Descripcion, tipoRopa=@tipoRopa," +
                        "color=@color where tipoProducto=@originalTipoProducto and precio=@originalPrecio " +
                        $"and tipoRopa=@originalTipoRopa";
                    }
                }
                else if (objeto is Alimento)
                {
                    tipoProductoEspecifico = ((Alimento)objeto).DeEnumParaString(((Alimento)objeto).TipoAlimento);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoAlimento", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@kcal", ((Alimento)objeto).Kcal);

                    if (accion == "Agregar")
                    {
                        this.comunicadorSql.CommandText = "insert into Alimento (tipoProducto,precio,durabilidad," +
                        "Descripcion,tipoAlimento,kcal) values" +
                        "(@tipoProducto,@precio,@durabilidad,@Descripcion,@tipoAlimento,@kcal)";
                    }
                    else
                    {
                        string tipoProductoStringOriginal = this.DeEnumParaString(original.TipoProducto);
                        string tipoAlimentoStringOriginal = ((Alimento)original).DeEnumParaString(((Alimento)original).TipoAlimento);

                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoProducto", tipoProductoStringOriginal);
                        this.comunicadorSql.Parameters.AddWithValue("@originalPrecio", original.Precio);
                        this.comunicadorSql.Parameters.AddWithValue("@originalTipoAlimento", tipoAlimentoStringOriginal);

                        this.comunicadorSql.CommandText = "update Alimento set " +
                        "tipoProducto=@tipoProducto ,precio=@precio ,durabilidad=@durabilidad," +
                        "Descripcion=@Descripcion, tipoAlimento=@tipoAlimento," +
                        "kcal=@kcal where tipoProducto=@originalTipoProducto and precio=@originalPrecio " +
                        "and tipoAlimento=@originalTipoAlimento";
                    }
                }
                int filasModificadas = this.comunicadorSql.ExecuteNonQuery();

            }
            catch { throw new ExcepcionErrorConBaseDatos("Error agregando o editando objeto de base de datos") ; }
            finally
            {
                if (this.conexionSql.State == System.Data.ConnectionState.Open)
                {
                    this.conexionSql.Close();
                }
            }
        }
        public void EliminarObjeto(ObjetoEnVenta objeto)
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



            }
            catch { throw new ExcepcionErrorConBaseDatos("Error agregando objeto a base de datos"); }
            finally
            {
                if (this.conexionSql.State == System.Data.ConnectionState.Open)
                {
                    this.conexionSql.Close();
                }
            }
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


                List<ObjetoEnVenta> listaElecto = this.DeserializarProductosEspecifico("E");
                List<ObjetoEnVenta> listaRopa = this.DeserializarProductosEspecifico("R");
                List<ObjetoEnVenta> listaAlimentos = this.DeserializarProductosEspecifico("A");

                lista = this.UnirListaObjetos(listaElecto, listaRopa);
                lista = this.UnirListaObjetos(lista, listaAlimentos);

                return lista;
            }
            catch { throw new ExcepcionErrorConBaseDatos("Error al traer el catalogo desde la base de datos"); }
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
                        e2.Descripcion = Descripcion;
                        lista.Add(e2);
                        break;
                    case "R":
                        Ropa r = new Ropa();
                        ETipoRopa tipoRopa = r.DeStringParaEnum((string)lector["tipoRopa"]);
                        string color = (string)lector["color"];

                        Ropa r2 = new Ropa(tipoProducto, precio,
                                                durabilidad, tipoRopa, color);
                        r2.Descripcion = Descripcion;
                        lista.Add(r2);
                        break;
                    case "A":
                        Alimento a = new Alimento();
                        ETipoAlimento tipoAlimento = a.DeStringParaEnum((string)lector["tipoAlimento"]);
                        int kcal = (int)lector["kcal"];

                        Alimento a2 = new Alimento(tipoProducto, precio,
                                                durabilidad, tipoAlimento, kcal);
                        a2.Descripcion = Descripcion;
                        lista.Add(a2);
                        break;
                }
            }
            lector.Close();
            return lista;
        }
        private List<ObjetoEnVenta> UnirListaObjetos(List<ObjetoEnVenta> l1, List<ObjetoEnVenta> l2)
        {
            foreach (ObjetoEnVenta o in l2)
            {
                l1.Add(o);
            }
            List<ObjetoEnVenta> lista = l1;
            return lista;
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
