﻿using Entidades;
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
    public partial class FormAppMain : Form
    {
        private static string pathXmlCatalogo = Environment.CurrentDirectory + "/catalogo.xml";
        private static string pathXmlventasPrevias = Environment.CurrentDirectory + "/ventasPrevias.xml";
        private Usuario userActual;
        private Plataforma plataforma;

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

            if (File.Exists(FormAppMain.pathXmlCatalogo)) this.DeserializarXml(FormAppMain.pathXmlCatalogo);
            if (File.Exists(FormAppMain.pathXmlventasPrevias)) this.DeserializarXml(FormAppMain.pathXmlventasPrevias, false);

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
        /// Serializa una lista de objetos a xml
        /// </summary>
        /// <param name="path">La ruta del archivo a serializar</param>
        /// <param name="catalogo">Un booleano que representa si se está serializando el
        /// catálogo o los objetos YA vendidos previamente</param>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        private bool SerializarXml(string path, bool catalogo = true)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(path, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<ObjetoEnVenta>));

                    if (catalogo) serializador.Serialize(escritor, this.plataforma.ObjetosEnVenta);
                    else serializador.Serialize(escritor, this.plataforma.ObjetosVendidos);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Serializa un xml a una lista de objetos
        /// </summary>
        /// <param name="path">La ruta del archivo a serializar</param>
        /// <param name="catalogo">Un booleano que representa si se está serializando el
        /// catálogo o los objetos YA vendidos previamente</param>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        private bool DeserializarXml(string path, bool catalogo = true)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(path))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<ObjetoEnVenta>));

                    if (catalogo) this.plataforma.ObjetosEnVenta = (List<ObjetoEnVenta>)serializador.Deserialize(lector);
                    else this.plataforma.ObjetosVendidos = (List<ObjetoEnVenta>)serializador.Deserialize(lector);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        private void FormAppMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult rta = MessageBox.Show("Seguro que desea cerrar sesión?"
                            ,"", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rta == DialogResult.Yes) DialogResult = DialogResult.OK;
            else
            {
                this.SerializarXml(FormAppMain.pathXmlCatalogo);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Si un user no es vendedor y está seleccionando un producto valido del catalogo, 
        /// se instancia un formulario que permite su edición
        /// </summary>
        private void lblEditarProducto_Click(object sender, EventArgs e)
        {
            if (this.userActual.perfil == "administrador" || this.userActual.perfil == "supervisor")
            {
                if (this.txtInfoProducto2.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = this.txtInfoProducto2.SelectedItems[0]; // Obtiene el objeto que se selecciono, pero en tipo ListViewItem
                    int selectedIndex = this.txtInfoProducto2.Items.IndexOf(selectedItem);

                    FormGenerarObjetoVenta fv = new FormGenerarObjetoVenta(this.plataforma.ObjetosEnVenta[selectedIndex]);
                    fv.ShowDialog();
                    if (fv.DialogResult == DialogResult.OK)
                    {
                        //this.plataforma.ObjetosEnVenta[selectedIndex] = fv.ObjetoVender;
                        this.plataforma.Editar(fv.ObjetoVender, selectedIndex);
                        this.ActualizarCatalogo();
                    }
                }
            }
            else MessageBox.Show("La edicion de un producto no esta disponible para vendedores");
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

        /// <summary>
        /// Si hay un elemento del catálogo seleccionado, se elimina de la plataforma, y se 
        /// agrega a los objetos ya vendidos, preguntando si está seguro el user de realizar
        /// esta operacion.
        /// </summary>
        private void lblComprar_Click(object sender, EventArgs e)
        {
            if (this.txtInfoProducto2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = this.txtInfoProducto2.SelectedItems[0]; // Obtiene el objeto que se selecciono, pero en tipo ListViewItem
                int selectedIndex = this.txtInfoProducto2.Items.IndexOf(selectedItem);
                DialogResult rta = MessageBox.Show(this.plataforma.ObjetosEnVenta[selectedIndex].DescripcionProducto(), "Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta == DialogResult.Yes)
                {
                    this.plataforma.ObjetosVendidos.Add(this.plataforma.ObjetosEnVenta[selectedIndex]);
                    this.SerializarXml(FormAppMain.pathXmlventasPrevias, false);
                    //this.plataforma -= this.plataforma.ObjetosEnVenta[selectedIndex];
                    this.plataforma.Eliminar(this.plataforma.ObjetosEnVenta[selectedIndex]);
                    this.txtInfoProducto2.Items.Remove(selectedItem);
                }
            }
            this.ActualizarCatalogo();
        }

        /// <summary>
        /// Instancia un formulario para ver todos los login de la app, si el user es administrador
        /// </summary>
        private void lblVerLogins_Click(object sender, EventArgs e)
        {
            if (userActual.perfil == "administrador")
            {
                FormVerLogin fv = new FormVerLogin();
                fv.ShowDialog();
            }
            else MessageBox.Show("Debes ser un usuario de tipo administrador para poder" +
                                 " visualizar esta funcion");
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
        /// Instancia un formulario para generar un objeto a vender. Una vez este es valido, se
        /// agrega al catálogo
        /// </summary>
        private void lblVenderProducto_Click(object sender, EventArgs e)
        {
            FormGenerarObjetoVenta fv = new FormGenerarObjetoVenta();
            fv.ShowDialog();
            if (fv.DialogResult == DialogResult.OK && fv.ObjetoVender is not null)
            {
                if (this.plataforma == fv.ObjetoVender) MessageBox.Show("El producto ya se encuentra a la venta");
                else this.plataforma.Agregar(fv.ObjetoVender); // this.plataforma += fv.ObjetoVender;
                this.SerializarXml(FormAppMain.pathXmlCatalogo);
            }
            this.ActualizarCatalogo();
        }
    }
}