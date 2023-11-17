using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Entidades
{
    public class NexoBaseDatos : IConversorImplicito<ETipoProducto>, ICrud<ObjetoEnVenta>
    {
        private static string stringConector;
        private SqlConnection conexionSql;
        private SqlCommand comunicadorSql;
        
        static NexoBaseDatos()
        {
            NexoBaseDatos.stringConector = Properties.Resources.StringConector;
        }
        /// <summary>
        /// Constructor. Pasa previamente por el estatico. Ambos inicializan atributos.
        /// </summary>
        public NexoBaseDatos()
        {
            this.conexionSql = new SqlConnection(NexoBaseDatos.stringConector);
        }

        /// <summary>
        /// Metodo que intenta agregar a una base de dato un objeto. Si no puede, lanza excepcion.
        /// Implementacion de interfaz CRUD
        /// </summary>
        /// <param name="objetoDelCrud">Objeto a agregar</param>
        public void Agregar(ObjetoEnVenta objetoDelCrud)
        {
            try
            {
                this.AgregarEditarObjeto(objetoDelCrud, "Agregar");
            }
            catch { throw; }
        }
        public void Editar(ObjetoEnVenta objetoEditCrud, int indice)
        {
            throw new ExcepcionSobrecargaInvalida("Imposible usar esta sobrecarga en la base de datos; indice inexistente");
        }
        /// <summary>
        /// Implementacion de interfaz CRUD. Intenta editar un objeto de una base de datos
        /// </summary>
        /// <param name="objetoEditCrud">el nuevo objeto que reemplazara al anterior</param>
        /// /// <param name="original">el antiguo objeto que sera reemplazado</param>
        public void Editar(ObjetoEnVenta objetoEditCrud, ObjetoEnVenta original)
        {
            try
            {
                this.AgregarEditarObjeto(objetoEditCrud, "Editar", original);
            }
            catch { throw; }
        }

        /// <summary>
        /// Implementacion de interfaz CRUD. Intenta eliminar un objeto de una base de datos
        /// </summary>
        /// <param name="objetoDelCrud">el objeto a eliminar</param>
        public void Eliminar(ObjetoEnVenta objetoDelCrud)
        {
            try
            {
                this.EliminarObjeto(objetoDelCrud);
            }
            catch { throw; }
        }
        /// <summary>
        /// Metodo que implementa la logica para agregar o editar un objeto
        /// </summary>
        /// <param name="objeto">Es el objeto a agregar</param>
        /// <param name="accion">O agregar, o editar</param>
        /// <param name="original">El objeto original. Es opcional, solo en caso de editar</param>
        /// <exception cref="ExcepcionErrorConBaseDatos">Si no pudo, lanza excepcion</exception>
        private void AgregarEditarObjeto(ObjetoEnVenta objeto, string accion, ObjetoEnVenta original=null)
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

        /// <summary>
        /// La logica de eliminar un objeto.
        /// </summary>
        /// <param name="objeto">Objeto a eliminar</param>
        /// <exception cref="ExcepcionErrorConBaseDatos">si no puede, lanza excepcion</exception>
        private void EliminarObjeto(ObjetoEnVenta objeto)
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
                    string tipoElectrodomestico = ((Electrodomestico)objeto).DeEnumParaString(((Electrodomestico)objeto).TipoElectodomestico);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoElectrodomestico", tipoElectrodomestico);
                    this.comunicadorSql.Parameters.AddWithValue("@marca", ((Electrodomestico)objeto).Marca);

                    this.comunicadorSql.CommandText = "delete from Electrodomestico" +
                    " where tipoProducto=@tipoProducto and precio=@precio and tipoElectrodomestico=@tipoElectrodomestico";
                }
                else if (objeto is Ropa)
                {
                    tipoProductoEspecifico = ((Ropa)objeto).DeEnumParaString(((Ropa)objeto).TipoRopa);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoRopa", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@color", ((Ropa)objeto).Color);

                    this.comunicadorSql.CommandText = "delete from Ropa" +
                    " where tipoProducto=@tipoProducto and precio=@precio and tipoRopa=@tipoRopa";
                }
                else if (objeto is Alimento)
                {
                    tipoProductoEspecifico = ((Alimento)objeto).DeEnumParaString(((Alimento)objeto).TipoAlimento);
                    this.comunicadorSql.Parameters.AddWithValue("@tipoAlimento", tipoProductoEspecifico);
                    this.comunicadorSql.Parameters.AddWithValue("@kcal", ((Alimento)objeto).Kcal);

                    this.comunicadorSql.CommandText = "delete from Alimento" +
                    " where tipoProducto=@tipoProducto and precio=@precio and tipoAlimento=@tipoAlimento";
                }
                int filasModificadas = this.comunicadorSql.ExecuteNonQuery();
            }
            catch { throw new ExcepcionErrorConBaseDatos("Error eliminando objeto de base de datos"); }
            finally
            {
                if (this.conexionSql.State == System.Data.ConnectionState.Open)
                {
                    this.conexionSql.Close();
                }
            }
        }

        /// <summary>
        /// Metodo que deserializa todos los objetos de la base de datos y los transforma en
        /// una lista de la jerarquia
        /// </summary>
        /// <returns>Lista deserializada</returns>
        /// <exception cref="ExcepcionErrorConBaseDatos">si no puede, lanza excepcion</exception>
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

        /// <summary>
        /// Metodo que deserializa una tabla de una base de datos de objeto en venta
        /// </summary>
        /// <param name="producto">String que indica qué tabla se deserializará</param>
        /// <returns>La lista con los objetos de la tabla especifica</returns>
        /// <exception cref="ExcepcionErrorConBaseDatos">si no puede, lanza excepcion</exception>
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

        /// <summary>
        /// Implementacion de la interfaz conversor. Pasa de EnumTipoProducto a string 
        /// </summary>
        /// <param name="obj">Enum a cambiar</param>
        /// <returns>string cambiado en base al enum</returns>
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

        /// <summary>
        /// Implementacion de la interfaz conversor. Pasa de string a enum correspondiente
        /// </summary>
        /// <param name="obj">string a analizar</param>
        /// <returns>El enum en base al string</returns>
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