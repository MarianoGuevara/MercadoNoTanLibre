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
    /// Clase formulario que hereda del formulario ver logins. Aca, en vez de ver los login,
    /// se ve la info de todos los usuarios registrados. Es para todos, no solo administradores
    /// </summary>
    public partial class FormVerUsuarios : FormVerLogin
    {
        private Plataforma plataforma;

        /// <summary>
        /// Actualiza la pantalla segun el atributo plataforma, que es recibido por parametro
        /// </summary>
        /// <param name="plataforma">representa la plataforma sobre la cual se quieren ver
        /// los user que tiene registrados</param>
        public FormVerUsuarios(Plataforma plataforma)
        {
            InitializeComponent();
            this.lblInfo.Text = "USUARIOS REGISTRADOS EN LA APP";
            this.plataforma = plataforma;
            this.ActualizarUsuarios();
        }

        /// <summary>
        /// Vacía el texto del richbox, y, por cada usuario, muestra su info en el rb
        /// </summary>
        private void ActualizarUsuarios()
        {
            this.rbInfo.Text = "";
            foreach (Usuario user in this.plataforma.Usuarios)
            {
                this.rbInfo.Text += user.ToString() + "\n";
            }
        }
    }
}
