using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPI_ClubDeportivo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /* __________________ VARIABLES tipo INTERNAL ______________________
         Serán accesibles desde el ensamblado en el cual están declarados
         y tampoco se pueden utilizar en el interior de una función.
        ____________________________________________________________________ 
        */

        internal String? rol;
        internal String? usuario;

        //private void frmPrincipal_Load(object sender, EventArgs e)
        //{
        //    // Verificar si los valores de usuario y rol no son nulos antes de asignarlos al label
        //    if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(rol))
        //    {
        //        lblIngreso.Text = $"USUARIO: {usuario} ({rol})";
        //    }
        //    else
        //    {
        //        lblIngreso.Text = "USUARIO: Información no disponible";
        //    }
        //}

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblIngreso.Text = $"USUARIO: {usuario} ({rol})";
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            /* Notifica a todos los surtidores de mensajes que deben terminar
               y a continuación, cierra todas las ventanas de la aplicación.
            ------------------------------------------------------------------
            */

            Application.Exit();
        }

        // Abre el formulario de inscripción
        private void btnInscribir_Click(Object sender, EventArgs e)
        {
            FrmRegistro inscripcion = new FrmRegistro();
            inscripcion.Owner = this;  // Establecer frmPrincipal como dueño
            inscripcion.Show();
            this.Hide();
        }
    }
}
