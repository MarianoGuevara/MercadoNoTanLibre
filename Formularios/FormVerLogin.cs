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
    /// Esta clase ve los login previos en toda la app; solo para administradores
    /// </summary>
    public partial class FormVerLogin : Form
    {
        /// <summary>
        /// Constructor. Setea configuraciones basicas de popiedades y controles
        /// </summary>
        public FormVerLogin()
        {
            InitializeComponent();
            this.rbInfo.ReadOnly = true;
            this.lblInfo.Text = "LOGINS (solo administradores)";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ActualizarPantalla();
        }

        /// <summary>
        /// Si existe un archivo determinado, devuelve el texto deserializado
        /// </summary>
        /// <returns></returns>
        private string DeserializarUsers()
        {
            string retorno = "no hay logins";
            if (File.Exists(Environment.CurrentDirectory + "/usuarios.log"))
            {
                using (StreamReader lector = new StreamReader(Environment.CurrentDirectory + "/usuarios.log"))
                {
                    retorno = lector.ReadToEnd();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Asigna el string deserializado con los login como valor del richbox 
        /// </summary>
        private void ActualizarPantalla()
        {
            this.rbInfo.Text = "";
            this.rbInfo.Text = this.DeserializarUsers();
        }
    }
}