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
using TPI_ClubDeportivo.Presentacion.Formularios;

namespace TPI_ClubDeportivo
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0; // Para que al iniciar el form de registro muestre DNI en el tipo por defecto.
        }

        // Salir de frmRegistro a frmPrincipal
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();  // Mostrá el formulario principal (dueño).
            this.Close();       // Cerrá el formulario actual.
        }

        // Registra en la base de datos al cliente 
        // Si es socio registra en la base de datos 
        // Carga los datos en pagar para realizar el pago
        private void btnRegistrar_Click(object sender, EventArgs e)
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
                cliente.SetEsSocio(radSocio.Checked);
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
                        MessageBox.Show("Se almacenó con éxito con el código Nro " + respuesta, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        if (cliente.EsSocio) // Verificar si el cliente es socio
                        {
                            E_Socio socio = new E_Socio();
                            socio.SetIdCliente(codigo);  // Asigna el código del cliente como IdCliente
                            socio.SetIdSocio(cliente);  // Asigna el código del socio como IdSocio

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

                        
                        // Abre el formulario de pago y pasa los datos automáticamente
                        frmPagar pagoForm = new frmPagar();
                        pagoForm.cargarDatosDePago(cliente); // Pasar los datos del cliente y el código
                        

                        this.Hide();
                        
                        pagoForm.Show(); // Muestra el formulario de pago

                        // Asegura que el formulario de pago esté por delante del formulario de registro
                        pagoForm.BringToFront();

                        LimpiarCampos();

                        
                    }
                }
            }
        }
                 
        // Limpiamos los campos para un nuevo ingreso        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Método para limpiar campos 
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
