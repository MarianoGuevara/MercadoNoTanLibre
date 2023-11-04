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
        /// Verifica, con expresiones regulares, si un string es valido para ser un correo o no 
        /// </summary>
        /// <param name="input"> Se espera un string a analizar </param>
        /// <returns> Devuelve un booleano indicando si es valido o no  </returns>
        private bool VerificarMail(string input)
        {
            bool retorno = true;
            string matcheo = Regex.Match(input, @"[A-Z|a-z|0-9]+@[a-z|A-Z]+.com").ToString();
            if (matcheo.Length == 0)
            {
                matcheo = Regex.Match(input, @"[A-Z|a-z|0-9]+@[a-z|A-Z]+.com.[a-z|A-Z]+").ToString();
                if (matcheo.Length == 0) retorno = false;
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si, con los datos de los 2 lugares para ingresar datos (correo y contraseña),
        /// Se puede crear un usuario válido
        /// </summary>
        /// <returns> Un booleano indicando si es valido o no el usuario potencial </returns>
        protected virtual bool VerificarUsuario()
        {
            return this.VerificarMail(this.txtMail.Text) && this.txtPassword.Text != String.Empty;
        }
    }
}