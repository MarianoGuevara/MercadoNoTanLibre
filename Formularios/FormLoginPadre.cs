using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// La clase padre de los formularios de registro de usuarios/productos
    /// </summary>
    public partial class FormLoginPadre : Form
    {
        /// <summary>
        /// Constructor. Inicia el formulario en el centro y sin ícono
        /// </summary>

        public FormLoginPadre()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowIcon = false;
        }

        /// <summary>
        /// Verifica si, con los datos de los 2 lugares para ingresar datos (correo y contraseña),
        /// Se puede crear un usuario válido
        /// </summary>
        /// <returns> Un booleano indicando si es valido o no el usuario potencial </returns>
        protected virtual bool VerificarUsuario()
        {
            VerficadoraDeValidez verificador = new VerficadoraDeValidez();

            return verificador.VerificarMail(this.txtMail.Text) &&
                   verificador.VerificarLargoString(this.txtPassword.Text, 5);

        }
    }
}