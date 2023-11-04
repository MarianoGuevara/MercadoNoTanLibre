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
    /// Clase formulario que hereda del formulario para ver los login de la app.
    /// Esta recibe un string que representa las compras previas, el cual se asinará
    /// al richbox que se mostrará en pantalla
    /// </summary>
    public partial class FormComprasPrevias : FormVerLogin
    {
        /// <summary>
        /// Constructor. Recibe un texto que se asignará al rickbox correspondiente
        /// </summary>
        /// <param name="comprasAnteriores"></param>
        public FormComprasPrevias(string comprasAnteriores)
        {
            InitializeComponent();
            this.rbInfo.Text = comprasAnteriores;
        }
    }
}
