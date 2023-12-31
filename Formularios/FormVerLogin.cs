﻿using Entidades;
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
    /// Esta clase ve los login previos en toda la app; solo para administradores. Implementa la interfaz
    /// de serializacion
    /// </summary>
    public partial class FormVerLogin : Form, ISerializadora<string>
    {
        /// <summary>
        /// Constructor. Setea configuraciones basicas de popiedades y controles
        /// </summary>
        public FormVerLogin(string rutaSerializacion)
        {
            InitializeComponent();
            this.rbInfo.ReadOnly = true;
            this.lblInfo.Text = "LOGINS (solo administradores)";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ActualizarPantalla(rutaSerializacion);
        }
        public FormVerLogin() : this(Environment.CurrentDirectory + "/usuarios.log") { }

        /// <summary>
        /// Si existe un archivo determinado, devuelve el texto deserializado. Implementacion
        /// de interfaz 
        /// </summary>
        /// <returns></returns>
        public string Deserializar(string ruta)
        {
            string retorno = "no hay logins";
            if (File.Exists(ruta))
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    retorno = lector.ReadToEnd();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Serializa un string en una ruta específica. Implementacion
        /// de interfaz 
        /// </summary>
        public void Serializar(string aSerializar, string ruta)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta, true))
                {
                    escritor.WriteLine(aSerializar);
                }
            }
            catch { throw new ExcepcionArchivoInvalido("La serializacion del archivo de vista de logins es imposible; verifique ruta"); }
        }

        /// <summary>
        /// Asigna el string deserializado con los login como valor del richbox 
        /// </summary>
        private void ActualizarPantalla(string rutaSerializacion)
        {
            this.rbInfo.Text = "";
            this.rbInfo.Text = this.Deserializar(rutaSerializacion);
        }
    }
}