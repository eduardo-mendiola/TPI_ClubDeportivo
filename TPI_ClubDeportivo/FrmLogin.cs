using TPI_ClubDeportivo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Datos;


namespace TPI_ClubDeportivo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            /* Este evento se ejecuta cuando llega el foco. */
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            /* Este evento se ejecuta cuando se va el foco */
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.UseSystemPasswordChar = false;
            }
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable tablaLogin = new DataTable(); // es la que recibe los datos desde el formulario.
            D_Usuarios dato = new D_Usuarios(); // variable que contiene todas las caracteristicas de la clase.
            tablaLogin = dato.Log_Usu(txtUser.Text, txtPass.Text);
            if (tablaLogin.Rows.Count > 0)
            {
                // ____ Quiere decir que el resultado tiene 1 fila por lo que el usuario EXISTE ___
                // _____ Informamos con un mensaje al usuario _____
                MessageBox.Show("Ingreso exitoso", "MENSAJES DEL SISTEMA",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                /* 
                ____________________________________________________________________
                Una vez que tenemos la conexion establecida PASAMOS al formulario 
                PRINCIPAL.
                Se debe "Instanciar" un objeto de la clase formulario principal.
                ____________________________________________________________________ 
                */
                FrmPrincipal Principal = new FrmPrincipal();
                /* 
                ____________________________________________________________________
                La siguiente linea permite tomar el dominio de la primera columna 
                de la primera fila del resultado de la ejecucion de la query.
                ____________________________________________________________________ 
                */
                Principal.rol = Convert.ToString(tablaLogin.Rows[0][0]);
                Principal.usuario = Convert.ToString(txtUser.Text);
                Principal.Show(); // se llama al formulario principal
                this.Hide(); // se oculta el formulario del login
            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrecto");
            }
        }
    }
}



