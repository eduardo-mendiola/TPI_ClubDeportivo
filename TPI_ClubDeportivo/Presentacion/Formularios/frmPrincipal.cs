using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Presentacion.Formularios;

namespace TPI_ClubDeportivo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /* 
        _____________________ VARIABLES tipo INTERNAL ______________________
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

        // Sale del sistema
        private void btnSalir_Click(object sender, EventArgs e)
        {
            /* 
            ------------------------------------------------------------------
             Notifica a todos los surtidores de mensajes que deben terminar
             y a continuación, cierra todas las ventanas de la aplicación.
            ------------------------------------------------------------------
            */

            Application.Exit();
        }

        // Abre el formulario para registrar clientes socios y no socios
        private void btnRegistrarCliente_Click(Object sender, EventArgs e)
        {
            FrmRegistro inscripcionPrincipal = new FrmRegistro();
            inscripcionPrincipal.Owner = this;  // Establecer frmPrincipal como dueño
            inscripcionPrincipal.Show();
            this.Hide();
        }

        // Abre el formulario de inscripción a actividades para cliente socio y no socios
        private void btnIscribirActividad_Click(object sender, EventArgs e)
        {
            frmInscribirEnActividad inscripcionPrincipal = new frmInscribirEnActividad();
            inscripcionPrincipal.Owner = this;  // Establecer frmPrincipal como dueño
            inscripcionPrincipal.AbiertoDesdePrincipal = true;  // Indicar que se abrió desde frmPrincipal
            inscripcionPrincipal.Show();
            this.Hide();
        }

        // Abre el formulario de pago de cuotas y actividades para cliente socio y no socios
        private void btnPagar_Click(object sender, EventArgs e)
        {
            frmPagar pagar = new frmPagar();
            pagar.Owner = this;
            pagar.Show();
            this.Hide();
        }

        // Abre el formulario de para ver las cuotas que vencen en el día de hoy
        private void bntVisualizarVencimientos_Click(object sender, EventArgs e)
        {
            frmVisualizarVencimientos listarVencimientos = new frmVisualizarVencimientos();
            listarVencimientos.Owner = this;
            listarVencimientos.Show();
            this.Hide();
        }

        // Abre el formulario de para ver las actividades registradas en la base de datos
        private void btnListarActividades_Click(object sender, EventArgs e)
        {
            frmListarActividades listarActividades = new frmListarActividades();
            listarActividades.Owner = this;
            listarActividades.Show();
            this.Hide();
        }

        private void btnEmitirCarnet_Click(object sender, EventArgs e)
        {
            frmCarnet carnet = new frmCarnet();
            carnet.Owner = this;
            carnet.Show();
            this.Hide();
        }
    }
}
