using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Entidades;
using TPI_ClubDeportivo.Interfaces;
using TPI_ClubDeportivo.Presentacion.Formularios;

namespace TPI_ClubDeportivo
{
    public partial class frmPagar : Form
    {
        public frmPagar()
        {
            InitializeComponent();
        }


        public frmFactura doc = new frmFactura();

        private void frmPagar_Load(object sender, EventArgs e)
        {
            cboCuotasTarjeta.SelectedIndex = 0;
            //cboTipoDocCPagos.SelectedIndex = 0;

        }


        // Salir de frmPagar a frmPrincipal     
        private void btnbtnVolverPagar_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show(); // Muestra el formulario propietario
                this.Close();       // Cierra el formulario actual
            }
            else
            {
                // Redirige al formulario principal
                Form principalForm = Application.OpenForms["frmPrincipal"];
                if (principalForm != null)
                {
                    principalForm.Show(); // Muestra el formulario principal
                }
                this.Close(); // Cierra el formulario actual
            }
        }

        // Abre el frmFactura
        private void btnComprobante_Click(object sender, EventArgs e)
        {
            doc.Owner = this;  // Asigna el Owner del formulario actual
            doc.Show();
            this.Hide();
        }

        // Intercambia la seleción de los checks
        private void optTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            cboCuotasTarjeta.Enabled = true;
        }

        private void optEfvo_CheckedChanged(object sender, EventArgs e)
        {
            cboCuotasTarjeta.Enabled = false;
        }

        // Realizar el pago registrando en la BD según sea socio o no socio
        private void btnPagar_Click(object sender, EventArgs e)
        {

            // Verifica que la grilla tenga filas y que la celda no esté vacía
            if (dtgvDeudas.Rows.Count > 0 && dtgvDeudas.Rows[0].Cells[0].Value != null)
            {
                // Realiza la comparación de los dos valores como enteros
                if (string.IsNullOrWhiteSpace(txtIdPago.Text) || Convert.ToInt32(txtIdPago.Text) != (int)dtgvDeudas.Rows[0].Cells[0].Value)
                {
                    MessageBox.Show("Id de Pago Incorrecto", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    MySqlConnection sqlCon = new MySqlConnection();
                    try
                    {
                        int Pagado_f;
                        bool MembresiaCliente;
                        string query;
                        sqlCon = ConexionDB.getInstancia().CrearConexion();

                        // Verifica si el cliente es socio o no socio
                        E_Cliente NuevoCliente = new E_Cliente();
                        MembresiaCliente = NuevoCliente.VerificarEsSocio(cboTipoDocCPagos.Text, txtDocumento.Text);

                        if (MembresiaCliente)
                        {
                            // Query para Socio
                            query = "SELECT cm.IdPago, cm.IdSocio, CONCAT(c.NombreC, ' ', c.ApellidoC), c.EsSocio, " +
                                    "cm.Monto, cm.EstadoPago " +
                                    "FROM CuotaMensual cm " +
                                    "INNER JOIN Socio AS s ON s.IdSocio = cm.IdSocio " +
                                    "INNER JOIN Cliente AS c ON c.IdCliente = s.IdCliente " +
                                    "WHERE cm.IdPago = @IdReg";

                        }
                        else
                        {
                            // Query para No Socio
                            query = "SELECT i.IdInscripcionAct, a.NombreActividad, CONCAT(c.NombreC, ' ', c.ApellidoC), c.EsSocio, " +
                                    "a.CostoDiario, i.Pagado " +
                                    "FROM InscripcionAct AS i " +
                                    "INNER JOIN Edicion AS e ON i.IdEdicion = e.IdEdicion " +
                                    "INNER JOIN Actividad  AS a ON a.Nactividad = e.Nactividad " +
                                    "INNER JOIN Cliente AS c ON c.TDocC = i.TipoDocCliente AND c.DocC = i.DocCliente " +
                                    "WHERE i.IdInscripcionAct = @IdReg";
                        }


                        MySqlCommand comando = new MySqlCommand(query, sqlCon);
                        comando.Parameters.AddWithValue("@IdReg", txtIdPago.Text); // Definimos el parámetro.

                        comando.CommandType = CommandType.Text;
                        sqlCon.Open();
                        MySqlDataReader reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read(); // En este caso sabemos que si tiene datos es UNA SOLA FILA

                            doc.Numero_f = reader.GetInt32(0);
                            doc.Actividad_f = reader.GetString(1);
                            doc.Alumno_f = reader.GetString(2);
                            doc.EsSocio_f = reader.GetInt16(3);
                            doc.CostoAct_f = reader.GetFloat(4);
                            doc.Monto_f = reader.GetFloat(4);
                            doc.CantCuotas_f = int.Parse(cboCuotasTarjeta.Text);
                            Pagado_f = reader.GetInt16(5);

                            // Evaluamos que opción es la seleccionada
                            if (optEfvo.Checked)
                            {
                                System.Diagnostics.Debug.WriteLine($"Monto después de descuento: {doc.Monto_f}");
                                doc.Forma_f = "Efectivo";
                                doc.Monto_f = Math.Round((doc.Monto_f * 0.9), 2);
                                System.Diagnostics.Debug.WriteLine($"Monto después de descuento: {doc.Monto_f}");
                            }
                            else
                            {
                                doc.Forma_f = "Tarjeta";
                                doc.Monto_f = Math.Round(doc.Monto_f, 2);
                            }

                            btnComprobante.Enabled = true;
                            btnImprimirCarnet.Enabled = true;

                            if (Pagado_f == 1)
                            {
                                MessageBox.Show("La factura ya está paga", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                IPago clientePago;
                                if (doc.EsSocio_f == 1)
                                {
                                    clientePago = new E_Socio();
                                }
                                else
                                {
                                    clientePago = new E_NoSocio();
                                }

                                clientePago.RealizarPago(txtIdPago.Text);

                                MessageBox.Show("Pago realizado exitosamente", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            txtIdPago.Text = "";

                            // Debugging
                            System.Diagnostics.Debug.WriteLine(query);
                            System.Diagnostics.Debug.WriteLine($"{doc.Numero_f} | {doc.Actividad_f} | {doc.Alumno_f} | {doc.Monto_f}");
                        }
                        else
                        {
                            MessageBox.Show("Id de Pago Incorrecto", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "MENSAJE DEL CATCH", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlCon.State == ConnectionState.Open)
                        {
                            sqlCon.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay deudas cargadas", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Buscar deuda de socios y no socios
        private void btnBuscarDeudas_Click(object sender, EventArgs e)
        {
            E_Cliente NuevoCliente = new E_Cliente();
            bool MembresiaCliente = NuevoCliente.VerificarEsSocio(cboTipoDocCPagos.Text, txtDocumento.Text);

            IPago clienteDeuda;
            if (MembresiaCliente)
            {
                clienteDeuda = new E_Socio();
            }
            else
            {
                clienteDeuda = new E_NoSocio();
            }
            clienteDeuda.ObtenerDeuda(dtgvDeudas, cboTipoDocCPagos.Text, txtDocumento.Text);
        }

        // Carga los datos de pago desde el frmRegistro segun se haya registrado como socio o no socio.
        // Si es socio carga el frmPagar y si es no socio abre un frmInscripcionActividad.
        public void cargarDatosDePago(E_Cliente cliente)
        {
            // Cargar los datos del cliente en el formulario de pago
            txtDocumento.Text = cliente.GetDoc();
            cboTipoDocCPagos.Text = cliente.GetTipoDoc();

            // Verificar si el cliente es socio
            E_Cliente NuevoCliente = new E_Cliente();
            bool MembresiaCliente = NuevoCliente.VerificarEsSocio(cliente.GetTipoDoc(), cliente.GetDoc());

            if (!MembresiaCliente)
            {
                MessageBox.Show("El cliente no es socio. Redirigiendo al formulario de inscripción...", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **Abrimos el formulario de inscripción en modo modal**
                frmInscribirEnActividad inscripcionForm = new frmInscribirEnActividad(cliente);
                this.Hide();  // Oculta el formulario actual (frmPagar) para mostrar solo el de inscripción
                DialogResult resultado = inscripcionForm.ShowDialog();  // Abre frmInscribirActividad y espera hasta que se cierre
                this.Show();  // Vuelve a mostrar frmPagar cuando se cierra el formulario de inscripción

                // Después de la inscripción, verificar si el cliente se inscribió
                if (resultado == DialogResult.OK)
                {
                    // Aquí podrías recargar las deudas si ya está listo para pagar
                    IPago clienteDeuda = new E_NoSocio();
                    clienteDeuda.ObtenerDeuda(dtgvDeudas, cliente.GetTipoDoc(), cliente.GetDoc());
                }
            }
            else
            {
                // Si el cliente es socio, continúa cargando sus deudas
                IPago clienteDeuda = new E_Socio();
                clienteDeuda.ObtenerDeuda(dtgvDeudas, cliente.GetTipoDoc(), cliente.GetDoc());
            }

            btnImprimirCarnet.Visible = true;
        }

        // Carga los datos en el formulario frmCarnet y ejecuta el metodo buscar cliente de carnet
        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            // Pasar los datos del cliente al form Carnet
            frmCarnet carnetForm = new frmCarnet();
            carnetForm.cboTipoDoc.Text = cboTipoDocCPagos.Text;
            carnetForm.txtDocumento.Text = txtDocumento.Text;
            // Ejecutar el método btnBuscarCliente_Click como si el botón fuera presionado
            carnetForm.btnBuscarCliente_Click(this, EventArgs.Empty);
            this.Hide();  // Oculta el formulario actual (frmPagar) para mostrar solo el de carnet
            DialogResult resultado = carnetForm.ShowDialog();  // Abre frmCarnet y espera hasta que se cierre
            this.Show();  // Vuelve a mostrar frmPagar cuando se cierra el formulario de carnet
        }
    }
}
