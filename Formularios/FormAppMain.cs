using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.DataFormats;

namespace Formularios
{
    /// <summary>
    /// La clase que representa el formulario principal de la aplicacion; el CRUD y otras funcionalidades
    /// </summary>
    public partial class FormAppMain : Form, ISerializadora<List<ObjetoEnVenta>>
    {
        //private static string pathXmlCatalogo = Environment.CurrentDirectory + "/catalogo.xml";
        private static string pathXmlventasPrevias = Environment.CurrentDirectory + "/ventasPrevias.xml";
        private Usuario userActual;
        private Plataforma plataforma;
        private CancellationToken cancelarFlujo;
        private CancellationTokenSource fuenteDeCancelacion;

        /// <summary>
        /// Constructor. Inicializa atributos y propiedades de controles como es conveniente. 
        /// Ademas, deserializa los archivos xml.
        /// </summary>
        /// <param name="userLogueado"> Representa el atributo userActual, que es el usuario
        /// que está logueado en la app.</param>
        /// <param name="plataforma">La plataforma que contiene el catálogo, usuarios, objetos
        /// en venta.</param>
        public FormAppMain(Usuario userLogueado, Plataforma plataforma)
        {
            InitializeComponent();
            this.Text = "Mercado (no tan) Libre";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userActual = userLogueado;
            this.lblUserInfo.Text = $"Usuario '{this.userActual.nombre}', {this.userActual.perfil} ({DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year})";
            this.plataforma = plataforma;
            this.lblVerLogins.Enabled = false;
            this.fuenteDeCancelacion = new CancellationTokenSource();
            this.cancelarFlujo = this.fuenteDeCancelacion.Token;


            switch (this.userActual.perfil)
            {
                case "administrador":
                    this.lblVerLogins.Enabled = true;
                    break;
                case "supervisor":
                    this.lblComprar.Enabled = false;
                    break;
                case "vendedor":
                    this.lblVenderProducto.Enabled = false;
                    this.lblEditarProducto.Enabled = false;
                    this.lblComprar.Enabled = false;
                    break;
            }

            try
            {
                if (File.Exists(FormAppMain.pathXmlventasPrevias))
                {
                    this.plataforma.ObjetosVendidos = this.Deserializar(FormAppMain.pathXmlventasPrevias);
                }

                NexoBaseDatos n = new NexoBaseDatos();
                this.plataforma.ObjetosEnVenta = n.DeserializarBaseDeDatos();
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionErrorConBaseDatos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.txtInfoProducto2.MultiSelect = false;
            this.txtInfoProducto2.View = View.Details;
            this.txtInfoProducto2.Columns.Add("", this.txtInfoProducto2.Width); // si no genero 1 columna, no se generan las filas
            this.ActualizarCatalogo();
        }

        /// <summary>
        /// Actualiza el listview principal con los objetos a vender que haya y sus respectivas imagenes
        /// </summary>
        private void ActualizarCatalogo()
        {
            ImageList listaImagenes = new ImageList();
            this.txtInfoProducto2.LargeImageList = listaImagenes;

            listaImagenes.ImageSize = new Size(100, 100);
            listaImagenes.Images.Add("img1", Image.FromFile(Environment.CurrentDirectory + "/recursos/electrodomestico.jpg"));
            listaImagenes.Images.Add("img2", Image.FromFile(Environment.CurrentDirectory + "/recursos/alimento.jpg"));
            listaImagenes.Images.Add("img3", Image.FromFile(Environment.CurrentDirectory + "/recursos/ropa.jpg"));

            this.txtInfoProducto2.SmallImageList = listaImagenes;

            this.txtInfoProducto2.Items.Clear();
            foreach (ObjetoEnVenta objeto in this.plataforma.ObjetosEnVenta)
            {
                this.txtInfoProducto2.Items.Add(objeto.ToString(), (int)objeto.TipoProducto);
            }
        }

        /// <summary>
        /// Actualiza el listview principal con los objetos a vender que haya y sus respectivas imagenes
        /// </summary>
        private void ActualizarContenidoSlider()
        {
            string fto = string.Empty;
            Random random = new Random();

            switch (random.Next(0, 3))
            {
                case 0:
                    fto = "/recursos/electroPromo2.jpg.png";
                    break;
                case 1:
                    fto = "/recursos/ropaOferta2.png";
                    break;
                case 2:
                    fto = "/recursos/alimentoOferta.png";
                    break;
            }
            this.pbOfertas.Image = Image.FromFile(Environment.CurrentDirectory + fto);
            this.pbOfertas.SizeMode = PictureBoxSizeMode.Zoom; // normaliza tamaños.
        }

        private void FormAppMain_Load(object sender, EventArgs e)
        {
            Task taskFecha = Task.Run(() => this.BucleTiempoHora());
            Task taskSlider = Task.Run(() => this.BucleTiempoSlider());
        }

        private void FormAppMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.fuenteDeCancelacion.Cancel();

            DialogResult rta = MessageBox.Show("Seguro que desea cerrar sesión?"
                        , "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rta == DialogResult.Yes) DialogResult = DialogResult.OK;
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Instancia un formulario al cual se le pasa un string con los objetos ya vendidos 
        /// de la plataforma. En el formulario se pueden visualizar estos objetos
        /// </summary>
        private void lblVerComprasPrevias_Click(object sender, EventArgs e)
        {
            FormComprasPrevias fcp = new FormComprasPrevias(this.plataforma.MostrarObjetosVendidos());
            fcp.ShowDialog();
        }
        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Instancia un formulario para ver todos los login de la app, si el user es administrador
        /// </summary>
        private void lblVerLogins_Click(object sender, EventArgs e)
        {
            FormVerLogin fv = new FormVerLogin();
            fv.ShowDialog();
        }

        /// <summary>
        /// Instancia un formulario para ver todos los miembros de la app
        /// </summary>
        private void lblVerMiembrosApp_Click(object sender, EventArgs e)
        {
            FormVerUsuarios fu = new FormVerUsuarios(this.plataforma);
            fu.ShowDialog();
        }

        /// <summary>
        /// Si un user no es vendedor y está seleccionando un producto valido del catalogo, 
        /// se instancia un formulario que permite su edición
        /// </summary>
        private void lblEditarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInfoProducto2.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = this.txtInfoProducto2.SelectedItems[0]; // Obtiene el objeto que se selecciono, pero en tipo ListViewItem
                    int selectedIndex = this.txtInfoProducto2.Items.IndexOf(selectedItem);

                    FormGenerarObjetoVenta fv = new FormGenerarObjetoVenta(this.plataforma.ObjetosEnVenta[selectedIndex]);
                    fv.ShowDialog();
                    if (fv.DialogResult == DialogResult.OK)
                    {
                        if (this.plataforma.DescripcionUnica(fv.ObjetoVender, this.plataforma.ObjetosEnVenta[selectedIndex]) == false)
                        {
                            NexoBaseDatos n = new NexoBaseDatos();
                            n.Editar(fv.ObjetoVender, this.plataforma.ObjetosEnVenta[selectedIndex]);

                            this.plataforma.Editar(fv.ObjetoVender, selectedIndex);

                            this.ActualizarCatalogo();
                        }
                        else MessageBox.Show("la descripcion debe ser unica e irrepetible", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ExcepcionErrorConBaseDatos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Si hay un elemento del catálogo seleccionado, se elimina de la plataforma, y se 
        /// agrega a los objetos ya vendidos, preguntando si está seguro el user de realizar
        /// esta operacion.
        /// </summary>
        private void lblComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInfoProducto2.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = this.txtInfoProducto2.SelectedItems[0]; // Obtiene el objeto que se selecciono, pero en tipo ListViewItem
                    int selectedIndex = this.txtInfoProducto2.Items.IndexOf(selectedItem);

                    DialogResult rta = MessageBox.Show(this.plataforma.ObjetosEnVenta[selectedIndex].DescripcionProducto(), "Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta == DialogResult.Yes)
                    {
                        this.plataforma.ObjetosVendidos.Add(this.plataforma.ObjetosEnVenta[selectedIndex]);
                        this.Serializar(this.plataforma.ObjetosVendidos, FormAppMain.pathXmlventasPrevias);

                        NexoBaseDatos n = new NexoBaseDatos();
                        n.Eliminar(this.plataforma.ObjetosEnVenta[selectedIndex]);

                        this.plataforma.Eliminar(this.plataforma.ObjetosEnVenta[selectedIndex]);
                        this.txtInfoProducto2.Items.Remove(selectedItem);
                    }
                }
                this.ActualizarCatalogo();
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionErrorConBaseDatos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Instancia un formulario para generar un objeto a vender. Una vez este es valido, se
        /// agrega al catálogo
        /// </summary>
        private void lblVenderProducto_Click(object sender, EventArgs e)
        {
            try
            {
                FormGenerarObjetoVenta fv = new FormGenerarObjetoVenta();
                fv.ShowDialog();
                if (fv.DialogResult == DialogResult.OK && fv.ObjetoVender is not null)
                {
                    if (this.plataforma == fv.ObjetoVender) MessageBox.Show("El producto ya se encuentra a la venta");
                    else if (this.plataforma.DescripcionUnica(fv.ObjetoVender) == false)
                    {
                        this.plataforma.Agregar(fv.ObjetoVender); // this.plataforma += fv.ObjetoVender;
                        NexoBaseDatos n = new NexoBaseDatos();
                        n.Agregar(fv.ObjetoVender);
                    }
                    else MessageBox.Show("Todos los productos deben tener una descripcion propia y unica.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarCatalogo();
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionErrorConBaseDatos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionSobrecargaInvalida ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ordena la lista de objetos en venta de la plataforma actual, según el precio, ascendente
        /// </summary>
        private void lblOrdenarPrecioAsc_Click(object sender, EventArgs e)
        {
            this.plataforma.ObjetosEnVenta.Sort(ObjetoEnVenta.OrdenarObjetoPorPrecioAscendente);
            this.ActualizarCatalogo();
        }

        /// <summary>
        /// Ordena la lista de objetos en venta de la plataforma actual, según el precio, descendente
        /// </summary>
        private void lblOrdenarPrecioDesc_Click(object sender, EventArgs e)
        {
            ObjetoEnVenta.OrdenarObjetoPorPrecioDescendente(this.plataforma);
            this.ActualizarCatalogo();
        }
        /// <summary>
        /// Ordena la lista de objetos en venta de la plataforma actual, según el tipo, ascendente
        /// </summary>
        private void lblOrdenarTipoAsc_Click(object sender, EventArgs e)
        {
            this.plataforma.ObjetosEnVenta.Sort(ObjetoEnVenta.OrdenarObjetoPorTipoAscendente);
            this.ActualizarCatalogo();
        }
        /// <summary>
        /// Ordena la lista de objetos en venta de la plataforma actual, según el tipo, descendente
        /// </summary>
        private void lblOrdenarTipoDesc_Click(object sender, EventArgs e)
        {
            ObjetoEnVenta.OrdenarObjetoPorTipoDescendente(this.plataforma);
            this.ActualizarCatalogo();
        }

        /// <summary>
        /// Asigna una 'animación' a un control label y regresa el mismo a la normalidad
        /// </summary>
        /// <param name="label">El label sobre el cual se aplicará la acción </param>
        /// <param name="hover">Booleano que dice si se quiere o no animar el label </param>
        private void AsignarHover(Label label, bool hover = false)
        {
            if (hover)
            {
                FontFamily f = new FontFamily("Segoe UI");
                label.Font = new Font(f, 10.5F, FontStyle.Bold);
            }
            else
            {
                FontFamily f = new FontFamily("Segoe UI");
                label.Font = new Font(f, 10F, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Si cualquier control del formulario es un label, llama al metodo para animarlo,
        /// cuando el mouse le pase por encima
        /// </summary>
        private void FormAppMain_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AsignarHover(label, true);
            }
        }

        /// <summary>
        /// Si cualquier control del formulario es un label, llama al metodo para devolverlo
        /// a la normalidad, cuando el mouse deje de pasarle por encima
        /// </summary>
        private void FormAppMain_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                AsignarHover(label);
            }
        }

        private void ActualizarFecha(DateTime fecha)
        {
            if (this.lblHora.InvokeRequired)
            {
                DelegadoFecha d = new DelegadoFecha(ActualizarFecha);
                object[] arrayParametro = { fecha };

                this.lblHora.Invoke(d, fecha);
            }
            else this.lblHora.Text = fecha.ToString();
        }

        private void ActualizarSlider()
        {
            if (this.lblHora.InvokeRequired)
            {
                DelegadoSinParam d = new DelegadoSinParam(ActualizarSlider);
                this.lblHora.Invoke(d);
            }
            else this.ActualizarContenidoSlider();
        }

        private void BucleTiempoHora()
        {
            do
            {
                if (this.cancelarFlujo.IsCancellationRequested) break;

                this.ActualizarFecha(DateTime.Now);
                Thread.Sleep(1000);

            } while (true);
        }

        private void BucleTiempoSlider()
        {
            do
            {
                if (this.cancelarFlujo.IsCancellationRequested) break;

                this.ActualizarSlider();
                Thread.Sleep(5000);

            } while (true);
        }

        /// <summary>
        /// Serializa una lista de objetos a xml
        /// </summary>
        /// <param name="path">La ruta del archivo a serializar</param>
        /// <param name="catalogo">Un booleano que representa si se está serializando el
        /// catálogo o los objetos YA vendidos previamente</param>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        public void Serializar(List<ObjetoEnVenta> aSerializar, string ruta)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<ObjetoEnVenta>));
                    serializador.Serialize(escritor, aSerializar);
                }
            }
            catch
            {
                throw new ExcepcionArchivoInvalido("Imposible serializar los objetos ya vendidos");
            }
        }

        /// <summary>
        /// Serializa un xml a una lista de objetos
        /// </summary>
        /// <param name="path">La ruta del archivo a serializar</param>
        /// <param name="catalogo">Un booleano que representa si se está serializando el
        /// catálogo o los objetos YA vendidos previamente</param>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        public List<ObjetoEnVenta> Deserializar(string ruta)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(ruta))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<ObjetoEnVenta>));
                    return (List<ObjetoEnVenta>)serializador.Deserialize(lector);
                }
            }
            catch
            {
                throw new ExcepcionArchivoInvalido("Imposible deserializar los objetos ya vendidos");
            }
        }

    }
}