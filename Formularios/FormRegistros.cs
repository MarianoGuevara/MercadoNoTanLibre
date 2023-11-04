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

namespace Formularios
{
    /// <summary>
    /// Clase que representa el formulario en el que se registran usuarios nuevos.
    /// Hereda del formulario padre de los login
    /// </summary>
    public partial class FormRegistros : FormLoginPadre
    {
        private Plataforma plataforma;
        private Usuario user;
        private string mensajeRegistro;
        public Usuario User { get { return this.user; } }

        /// <summary>
        /// Inicializa las propiedades de los controles segun corresponda y recibe
        /// el parametro plataforma, que será igualado al atributo plataforma
        /// </summary>
        /// <param name="plataforma"> la plataforma sobre la cual se registrará al usuario </param>
        public FormRegistros(Plataforma plataforma) // advertencia por user null; quiero que asi sea
        {
            InitializeComponent();
            this.plataforma = plataforma;
            this.btn1.Text = "Registrar";
            this.btn2.Text = "Volver";
            this.cbTipoUser.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbTipoUser.Items.Add("vendedor");
            this.cbTipoUser.Items.Add("administrador");
            this.cbTipoUser.Items.Add("supervisor");
            this.mensajeRegistro = String.Empty;
        }

        /// <summary>
        /// Verifica si un usuario puede ser potencialmente correcto; sobrescritura de metodo
        /// </summary>
        /// <returns>booleano con el resultado de la operacion</returns>
        protected override bool VerificarUsuario()
        {
            return base.VerificarUsuario() && this.txtName.Text != String.Empty &&
                   this.cbTipoUser.SelectedItem != null;
        }

        /// <summary>
        /// Se capturan los input del usuario y, si todo está en orden, crea un usuario con
        /// esos datos y se cierra el formulario
        /// </summary>
        private void btn1_Click(object sender, EventArgs e)
        {
            this.mensajeRegistro = "Algun/os dato/s ingresado/s esta/n en formato incorrecto";
            if (this.VerificarUsuario() && short.TryParse(this.txtLegajo.Text, out _))
            {
                this.user = new Usuario(this.txtName.Text, this.txtApellido.Text,
                                        this.txtPassword.Text, this.txtMail.Text,
                                        short.Parse(this.txtLegajo.Text),
                                        this.ActuarSegunIndice());
                if ((this.plataforma == user) == -1)
                {
                    this.mensajeRegistro = "Usuario registrado con exito";
                    this.DialogResult = DialogResult.OK;
                }
                else this.mensajeRegistro = "Usuario ya existente";

                this.plataforma += this.user;
            }
            MessageBox.Show(this.mensajeRegistro);
        }

        /// <summary>
        /// devuelve un string que representa el tipo de perfil que tendrá el usuario
        /// </summary>
        /// <returns>devuelve un string que representa el tipo de perfil que tendrá el usuario</returns>
        private string ActuarSegunIndice()
        {
            string perfil = string.Empty;
            if (this.cbTipoUser.SelectedIndex != -1)
            {
                switch (this.cbTipoUser.SelectedIndex)
                {
                    case 0:
                        perfil = "vendedor";
                        break;
                    case 1:
                        perfil = "administrador";
                        break;
                    case 2:
                        perfil = "supervisor";
                        break;
                }
            }
            return perfil;
        }
        private void cbTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActuarSegunIndice();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}