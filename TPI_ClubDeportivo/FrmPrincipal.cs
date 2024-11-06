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

        // Función para centar un label en el formulario

        private void CenterLabelInForm(Label label)
        {
            label.Left = (this.ClientSize.Width - label.Width) / 2;

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblRol.Text = $"* {rol} *";
            CenterLabelInForm(lblRol);
            lblUsuario.Text = usuario;
            CenterLabelInForm(lblUsuario);
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

        private void btnAsignarCurso_Click(object sender, EventArgs e)
        {
            frmInscribirActividad asignar = new frmInscribirActividad();
            asignar.Owner = this;
            asignar.Show();
            this.Hide();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            frmPagar pagar = new frmPagar();
            pagar.Owner = this;
            pagar.Show();
            this.Hide();
        }
    }
}
