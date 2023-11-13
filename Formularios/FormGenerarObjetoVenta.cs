using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Formularios
{
    /// <summary>
    /// Clase formulario que hereda del formulario de login. Aqui se generan los objetos
    /// que aparecerán en el catálogo.
    /// </summary>
    public partial class FormGenerarObjetoVenta : FormLoginPadre
    {
        private ObjetoEnVenta objetoVender;
        private int indiceTipoObjeto;
        private int indiceCaractObjeto;
        public ObjetoEnVenta ObjetoVender { get { return this.objetoVender; } }

        /// <summary>
        /// Constructor. Inicializa propiedades de controles en valores convenientes y agrega
        /// items a combobox
        /// </summary>
        public FormGenerarObjetoVenta() // advierte pq el user sale null, pero x ahora quiero que sea así
        {
            InitializeComponent();
            this.btn1.Text = "VENDER";
            this.btn2.Text = "REGRESAR";
            this.txtMail.PlaceholderText = String.Empty;
            this.txtPassword.PlaceholderText = String.Empty;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCaract2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Items.Add("Electrodomestico");
            this.comboBox1.Items.Add("Alimento");
            this.comboBox1.Items.Add("Ropa");
        }

        /// <summary>
        /// Segundo contructor de la clase que llama al anterior y, segun un parametro,
        /// coloca los atributos de los mismos en pantalla; se llama a este para editar un producto
        /// </summary>
        /// <param name="obj"></param>
        public FormGenerarObjetoVenta(ObjetoEnVenta obj) : this()
        {
            this.txtMail.Text = obj.Precio.ToString();
            this.txtPassword.Text = obj.DurabilidadAproximada.ToString();
            this.comboBox1.SelectedIndex = (int)(obj.TipoProducto);
            this.comboBox1.Enabled = false;
            this.rbDescrpcion.Text = obj.Descripcion;
            if (obj is Electrodomestico)
            {
                this.txtCaract1.Text = ((Electrodomestico)obj).Marca;
                this.cbCaract2.SelectedIndex = (int)(((Electrodomestico)obj).TipoElectodomestico);
            }
            else if (obj is Alimento)
            {
                this.txtCaract1.Text = ((Alimento)obj).Kcal.ToString();
                this.cbCaract2.SelectedIndex = (int)(((Alimento)obj).TipoAlimento);
            }
            else
            {
                this.txtCaract1.Text = ((Ropa)obj).Color;
                this.cbCaract2.SelectedIndex = (int)(((Ropa)obj).TipoRopa);
            }
        }

        /// <summary>
        /// Se revisa si en el combobox correspondiente se seleccionó una opción. 
        /// De ser así, dependiendo de cada una, asigna a algunos txtboxes difernetes caracteristicas
        /// </summary>
        /// <returns></returns>
        private void ActuarSegunSeleccion()
        {
            if (this.comboBox1.SelectedIndex != -1)
            {
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:
                        this.cbCaract2.Items.Clear();
                        this.cbCaract2.Items.Add(ETipoElecto.Ventilador);
                        this.cbCaract2.Items.Add(ETipoElecto.Lavaropa);
                        this.cbCaract2.Items.Add(ETipoElecto.Television);
                        this.lblCaract1.Text = "Marca";
                        this.lblCaract2.Text = "Tipo de electro.";
                        break;
                    case 1:
                        this.cbCaract2.Items.Clear();
                        this.cbCaract2.Items.Add(ETipoAlimento.Fruta);
                        this.cbCaract2.Items.Add(ETipoAlimento.Verdura);
                        this.cbCaract2.Items.Add(ETipoAlimento.Carne);
                        this.lblCaract1.Text = "Kcals";
                        this.lblCaract2.Text = "Tipo de alimento";
                        break;
                    case 2:
                        this.cbCaract2.Items.Clear();
                        this.cbCaract2.Items.Add(ETipoRopa.Zapatos);
                        this.cbCaract2.Items.Add(ETipoRopa.Pantalon);
                        this.cbCaract2.Items.Add(ETipoRopa.Remera);
                        this.lblCaract1.Text = "Color";
                        this.lblCaract2.Text = "Tipo de ropa";
                        break;
                }
            }
            else throw new ExcepcionDatosInvalidos("Indice de 'tipo producto' NO seleccionado...");
        }

        /// <summary>
        /// Crea un objeto de la jerarquia, si todos los campos llenados por el usuario 
        /// son validos. Si es así, cierra el formulario
        /// </summary>
        private void CrearObjeto()
        {
            try
            {
                VerficadoraDeValidez verificador = new VerficadoraDeValidez();

                double precio = verificador.Parsear<double>(this.txtMail.Text);

                if (this.cbCaract2.SelectedIndex != -1 && this.indiceTipoObjeto != -1 &&
                verificador.VerificarLargoString(this.txtCaract1.Text, 1) &&
                verificador.VerificarLargoString(this.rbDescrpcion.Text, 20) &&
                verificador.VerificarLargoString(this.txtPassword.Text, 1, 4) &&
                short.TryParse(this.txtPassword.Text, out _) &&
                this.indiceTipoObjeto != -1 && this.rbDescrpcion.Text.Length < 300)
                {
                    short durabilidad = verificador.Parsear<short>(this.txtPassword.Text);
                    switch (this.indiceTipoObjeto)
                    {
                        case 0:
                            this.objetoVender = new Electrodomestico(ETipoProducto.Electrodomestico,
                                                                    precio, durabilidad,
                                                                    (ETipoElecto)this.indiceCaractObjeto, this.txtCaract1.Text);
                            break;
                        case 1:
                            this.objetoVender = new Alimento(ETipoProducto.Alimento, precio, durabilidad,
                                                            (ETipoAlimento)this.indiceCaractObjeto,
                                                            verificador.Parsear<int>(this.txtCaract1.Text));
                            break;
                        case 2:
                            this.objetoVender = new Ropa(ETipoProducto.Ropa, precio, durabilidad,
                                                        (ETipoRopa)this.indiceCaractObjeto, this.txtCaract1.Text);
                            break;
                    }
                    if (this.objetoVender is not null) this.objetoVender.Descripcion = this.rbDescrpcion.Text;
                    else throw new ExcepcionDatosInvalidos("El objeto no se pudo crear. Por favor, revise todos los datos");
                }
                else throw new ExcepcionDatosInvalidos("Descripcion o atributo propio de objeto muy cortos o incompletos" +
                    "");
            }
            catch (FormatException)
            {
                MessageBox.Show("Algun dato numerico no valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionDatosInvalidos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                if (this.objetoVender is not null) this.DialogResult = DialogResult.OK;
                else this.DialogResult = DialogResult.Cancel;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            this.CrearObjeto();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Asigna al atributo indiceTipoObjeto cuál es el indice seleccionado del combobox,
        /// ya que si no se guarda rápido, este valor se pierde
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indiceTipoObjeto = this.comboBox1.SelectedIndex;
            this.ActuarSegunSeleccion();
        }
        /// <summary>
        /// Asigna al atributo indiceCaractObjeto cuál es el indice seleccionado del combobox,
        /// ya que si no se guarda rápido, este valor se pierde
        /// </summary>
        private void cbCaract2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indiceCaractObjeto = this.cbCaract2.SelectedIndex;
        }
    }
}