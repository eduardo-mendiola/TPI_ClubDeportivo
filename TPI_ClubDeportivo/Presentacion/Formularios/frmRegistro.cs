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
using TPI_ClubDeportivo.Entidades;

namespace TPI_ClubDeportivo
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

 
        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0; // Para que al iniciar el form de registro muestre DNI en el tipo por defecto.
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();  // Mostrá el formulario principal (dueño).
            this.Close();       // Cerrá el formulario actual.
        }

        //private void btnIngresar_Click(object sender, EventArgs e)
        //{
        //    if (txtNombre.Text == "" || txtApellido.Text == "" || cboTipo.Text == "" || txtDocumento.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
        //    {
        //        MessageBox.Show("Debe completar datos requeridos (*) ", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        String respuesta;
        //        E_Cliente cliente = new E_Cliente();

        //        cliente.SetNombre(txtNombre.Text);
        //        cliente.SetApellido(txtApellido.Text);
        //        cliente.SetTipoDoc(cboTipo.Text);
        //        cliente.SetDoc(txtDocumento.Text);
        //        cliente.SetFechaNacimiento(dtpFechaNacimiento.Value);
        //        cliente.SetTel(txtTelefono.Text);
        //        cliente.SetDomicilio(txtDomicilio.Text);
        //        cliente.SetEmail(txtEmail.Text);
        //        cliente.SetEsSocio(radSocio.Checked);
        //        cliente.SetAptoFisico(chkAptoFisico.Checked);

        //        // Instaciamos para usar el método dentro de clientes
        //        D_Cliente clienteReg = new D_Cliente();

        //        respuesta = clienteReg.Nuevo_Cliente(cliente);

        //        bool esnumero = int.TryParse(respuesta, out int codigo);


        //        if (esnumero)
        //        {
        //            if (codigo == 1)
        //            {
        //                MessageBox.Show("CLIENTE YA EXISTE", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Se almacenó con éxito con el código Nro " + respuesta, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //                LimpiarCampos();
        //            }
        //        }
        //    }
        //}




        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || cboTipo.Text == "" || txtDocumento.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Debe completar datos requeridos (*) ", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String respuesta;
                E_Cliente cliente = new E_Cliente();

                cliente.SetNombre(txtNombre.Text);
                cliente.SetApellido(txtApellido.Text);
                cliente.SetTipoDoc(cboTipo.Text);
                cliente.SetDoc(txtDocumento.Text);
                cliente.SetFechaNacimiento(dtpFechaNacimiento.Value);
                cliente.SetTel(txtTelefono.Text);
                cliente.SetDomicilio(txtDomicilio.Text);
                cliente.SetEmail(txtEmail.Text);
                cliente.SetEsSocio(radSocio.Checked); // Revisar si es socio
                cliente.SetAptoFisico(chkAptoFisico.Checked);

                D_Cliente clienteReg = new D_Cliente();
                respuesta = clienteReg.Nuevo_Cliente(cliente);

                bool esNumero = int.TryParse(respuesta, out int codigo);

                if (esNumero)
                {
                    if (codigo == 1)
                    {
                        MessageBox.Show("CLIENTE YA EXISTE", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Cliente registrado exitosamente, continuar con socio si corresponde
                        MessageBox.Show("Se almacenó con éxito con el código Nro " + respuesta, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        if (cliente.EsSocio) // Verificar si el cliente es socio
                        {
                            E_Socio socio = new E_Socio();
                            socio.SetIdCliente(codigo);  // Asigna el código del cliente como IdCliente
                            socio.GetValorCuota();       // Asigna el valor de la cuota

                            D_Socio socioReg = new D_Socio();
                            String respuestaSocio = socioReg.Nuevo_Socio(socio);

                            if (int.TryParse(respuestaSocio, out int resultadoSocio) && resultadoSocio > 0)
                            {
                                MessageBox.Show("Socio registrado exitosamente", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al registrar socio: " + respuestaSocio, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        LimpiarCampos();
                    }
                }
            }
        }





        /* =============================================
         * Limpiamos los objetos para un nuevo ingreso
         * =============================================
         */
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            cboTipo.SelectedIndex = 0;
            dtpFechaNacimiento.Value = DateTime.Today;
            txtTelefono.Text = "";
            txtDomicilio.Text = "";
            txtEmail.Text = "";
            radSocio.Checked = true;
            chkAptoFisico.Checked = false;
            txtNombre.Focus();
        }

       
    }
}
