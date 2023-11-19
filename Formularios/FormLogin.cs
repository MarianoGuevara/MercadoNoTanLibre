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
    /// Implementa la interfaz serializadora
    /// </summary>
    public partial class FormLogin : FormLoginPadre, ISerializadora<List<Usuario>>
    {
        private static string pathJson;
        private static string pathLog;
        private static Plataforma plataforma;
        private event DelegadoSinParam EventoLimpiar;
        private CancellationToken cancelarFlujo;
        private CancellationTokenSource fuenteDeCancelacion;
        private int ms;
        private int ss;
        private bool finCronometro;

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

            this.EventoLimpiar += new DelegadoSinParam(this.LimpiarInputs);

            this.fuenteDeCancelacion = new CancellationTokenSource();
            this.cancelarFlujo = this.fuenteDeCancelacion.Token;

            this.finCronometro = false;
            this.ms = 1;
            this.ss = 45;
            this.lblTiempo.Text = $"{this.ms} : {this.ss}";
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

                        this.Cerrar(false);

                        this.LimpiarInputs();
                        this.Hide();

                        FormAppMain fa = new FormAppMain(usuario, FormLogin.plataforma);
                        fa.ShowDialog();
                        if (fa.DialogResult == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            this.Show();

                            this.fuenteDeCancelacion = new CancellationTokenSource();
                            this.cancelarFlujo = this.fuenteDeCancelacion.Token;

                            this.ms = 1;
                            this.ss = 45;
                            this.lblTiempo.Text = $"{this.ms} : {this.ss}";
                            Task taskTiempo = Task.Run(() => this.CronometroRegresivo());
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else throw new ExcepcionDatosInvalidos("Datos en formato invalido");
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionDatosInvalidos)
            {
                this.EventoLimpiar += new DelegadoSinParam(this.InformarErrorInvalido);
                this.EventoLimpiar.Invoke();
                this.EventoLimpiar -= new DelegadoSinParam(this.InformarErrorInvalido);
            }
            catch (Exception) 
            {
                this.EventoLimpiar += new DelegadoSinParam(this.InformarErrorCoincidente);
                this.EventoLimpiar.Invoke();
                this.EventoLimpiar -= new DelegadoSinParam(this.InformarErrorCoincidente);
            }
        }
        private void InformarErrorInvalido() { MessageBox.Show("Datos en formato invalido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
        private void InformarErrorCoincidente() { MessageBox.Show("Los datos del ingreso no coinciden con ningun miembro de la plataforma", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private void LimpiarInputs()
        {
            this.txtMail.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        /// <summary>
        /// Si se presiona el boton 'registrar', se instancia el formulario de registro 
        /// </summary>
        private void btn2_Click(object sender, EventArgs e)
        {
            this.Cerrar(false);

            FormRegistros fr = new FormRegistros(FormLogin.plataforma);
            fr.ShowDialog();

            this.fuenteDeCancelacion = new CancellationTokenSource();
            this.cancelarFlujo = this.fuenteDeCancelacion.Token;

            this.ms = 1;
            this.ss = 45;
            this.lblTiempo.Text = $"{this.ms} : {this.ss}";
            Task taskTiempo = Task.Run(() => this.CronometroRegresivo());

            try
            {
                this.Serializar(FormLogin.plataforma.Usuarios, FormLogin.pathJson);
            }
            catch (ExcepcionArchivoInvalido ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// En bucle, retrocede en un cronometro, dando al usuario un limite para iniciar sesión
        /// </summary>
        /// <param name="minsInicio">limite de minutos para iniciar sesion</param>
        /// <param name="segsInicio">limite de segundos para iniciar sesion</param>
        private void CronometroRegresivo()
        {
            do
            {
                if (this.cancelarFlujo.IsCancellationRequested) break;

                Thread.Sleep(1000);
                this.RetrocederCronometro();

            } while (true);

            if (this.finCronometro==true) this.Cerrar();
        }
        private void Cerrar(bool cerrar=true)
        {
            if (cerrar) this.Close();
            else this.fuenteDeCancelacion.Cancel();
        }

        /// <summary>
        /// Hilo. Retrocede el atributo correspondiente en 1, dando la ilusion de un cronometro
        /// </summary>
        private void RetrocederCronometro()
        {
            if (this.lblTiempo.InvokeRequired)
            {
                DelegadoSinParam d = new DelegadoSinParam(RetrocederCronometro);
                this.lblTiempo.Invoke(d);
            }
            else
            {
                if (this.ss == 0 && this.ms == 0)
                {
                    this.finCronometro = true;
                    this.fuenteDeCancelacion.Cancel();
                }

                if (this.ss == 0)
                {
                    this.ss = 60;
                    this.ms--;
                }

                this.ss--;
                this.lblTiempo.Text = $"{this.ms} : {this.ss}";
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
            Task taskTiempo = Task.Run(() => this.CronometroRegresivo());
        }

        /// <summary>
        /// Verifica, si no es por limite de tiempo, si se quiere cerrar la app...
        /// </summary>
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Serializar(FormLogin.plataforma.Usuarios, FormLogin.pathJson);


                if (this.finCronometro == false)
                {
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
    }
}