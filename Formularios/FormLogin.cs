using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using Entidades;
using System.Collections.Generic;
using static System.Windows.Forms.Design.AxImporter;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// La clase del login, que hereda del formulario del login padre. El usuario inicia sesión aqui.
    /// </summary>
    public partial class FormLogin : FormLoginPadre, ISerializadora<List<Usuario>>
    {
        private static string pathJson;
        private static string pathLog;
        private static Plataforma plataforma;
        /// <summary>
        /// Constructor estático. Inicializa los atributos estáticos
        /// </summary>
        /// 
        static FormLogin()
        {
            FormLogin.pathJson = Environment.CurrentDirectory + "/MOCK_DATA.json";
            FormLogin.pathLog = Environment.CurrentDirectory + "/usuarios.log";
            FormLogin.plataforma = new Plataforma("GamesFactory");
        }

        /// <summary>
        /// Constructor. Asigna valores iniciales a propiedades de controles
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
            this.Text = "Inicio de sesión";
            this.btn1.Text = "ACCEDER";
            this.btn2.Text = "REGISTRARSE";
        }

        /// <summary>
        /// Verifica si los datos ingresador por el usuario, y, si es asi, inicia sesión y
        /// muestra la app principal y oculta el fomulario actual
        /// </summary>
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.VerificarUsuario())
                {
                    Usuario usuario = new Usuario("", "", base.txtPassword.Text, base.txtMail.Text, 1, "vendedor");
                    if ((FormLogin.plataforma == usuario) != -1)
                    {
                        usuario = FormLogin.plataforma.Usuarios[FormLogin.plataforma == usuario];

                        FormVerLogin fvLogin = new FormVerLogin(FormLogin.pathLog);
                        fvLogin.Serializar(usuario.MostrarUserLogin(), FormLogin.pathLog);

                        MessageBox.Show($"Usuario valido, bienvenido '{usuario.nombre}'");

                        this.Limpiar();
                        this.Hide();
                        FormAppMain fa = new FormAppMain(usuario, FormLogin.plataforma);
                        fa.ShowDialog();
                        if (fa.DialogResult == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            this.Show();
                        }
                    }
                    else
                    {
                        throw new ExcepcionDatosInvalidos("Los datos del ingreso no coinciden con ningun miembro de la plataforma");
                    }
                }
                else throw new ExcepcionDatosInvalidos("Datos en formato invalido");
            }
            catch (ExcepcionDatosInvalidos ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Si se presiona el boton 'registrar', se instancia el formulario de registro 
        /// </summary>
        private void btn2_Click(object sender, EventArgs e)
        {
            FormRegistros fr = new FormRegistros(FormLogin.plataforma);
            fr.ShowDialog();
            try
            {
                this.Serializar(FormLogin.plataforma.Usuarios, FormLogin.pathJson);
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                FormLogin.plataforma.Usuarios = this.Deserializar(FormLogin.pathJson);
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Serializar(FormLogin.plataforma.Usuarios, FormLogin.pathJson);
                DialogResult rta = MessageBox.Show("Seguro que desea cerrar la aplicación?"
                    , "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rta == DialogResult.Yes)
                {
                    MessageBox.Show("Gracias por usar la app!");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    e.Cancel = true;

                }
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Intenta serializar la lista de usuarios de la plataforma en un path especifico, a json
        /// </summary>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        public void Serializar(List<Usuario> aSerializar, string ruta)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                using (StreamWriter escritor = new StreamWriter(ruta))
                {
                    string objJson = JsonSerializer.Serialize(aSerializar, options);
                    escritor.WriteLine(objJson);
                }
            }
            catch 
            {
                throw new ExcepcionArchivoInvalido("Imposible serializar los usuarios");
            }
        }

        /// <summary>
        /// Deserializa una lista de usuarios de un path específico y se la asigna a la lista
        /// de la plataforma actual
        /// </summary>
        /// <returns>booleano representando si se pudo realizar la accion o no</returns>
        public List<Usuario> Deserializar(string ruta)
        {
            try
            {
                using (StreamReader lector = new StreamReader(FormLogin.pathJson))
                {
                    string objLector = lector.ReadToEnd();
                    return (List<Usuario>)JsonSerializer.Deserialize(objLector, typeof(List<Usuario>));
                }
            }
            catch { throw new ExcepcionArchivoInvalido("Imposible deserializar los usuarios"); }
        }

        /// <summary>
        /// Vacía las 2 propiedades de texto de los controles correspondientes
        /// </summary>
        private void Limpiar()
        {
            this.txtMail.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }
    }
}