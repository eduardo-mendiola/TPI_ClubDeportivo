using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using System;
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

namespace TPI_ClubDeportivo
{
    public partial class frmPagar : Form
    {


        public frmFactura doc = new frmFactura();


        private void frmPagar_Load(object sender, EventArgs e)
        {
            cboCuotasTarjeta.SelectedIndex = 0;
            cboTipoDocCPagos.SelectedIndex = 0;
        }

        public frmPagar()
        {
            InitializeComponent();
        }

        private void btnVolverInsAct_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            doc.Owner = this.Owner;  // Asigna el Owner del formulario actual
            doc.Show();
            this.Hide();
        }

        private void optTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            cboCuotasTarjeta.Enabled = true;
        }

        private void optEfvo_CheckedChanged(object sender, EventArgs e)
        {
            cboCuotasTarjeta.Enabled = false;
        }

       

        private void btnPagar_Click(object sender, EventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                int Pagado_f;
                bool MembresiaCliente;
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();

                E_Cliente NuevoCliente = new E_Cliente();
                MembresiaCliente = NuevoCliente.VerificarEsSocio(cboTipoDocCPagos.Text, txtDocumento.Text);
                
                if (MembresiaCliente)
                {
                    query = "SELECT cm.IdPago, cm.IdSocio, CONCAT(c.NombreC, ' ', c.ApellidoC), c.EsSocio, " +
                            "cm.Monto, cm.EstadoPago " +
                            "FROM CuotaMensual cm " +
                            "INNER JOIN Socio AS s ON s.IdSocio = cm.IdSocio " +
                            "INNER JOIN Cliente AS c ON c.IdCliente = s.IdCliente " +
                            "WHERE cm.IdPago = @IdReg"; // Usamos parámetro para evitar inyección SQL.

                    /*
                     "SELECT cm.IdPago, cm.IdSocio, cm.FechaVencimiento, cm.Monto " +
                               "FROM CuotaMensual AS cm " +
                               "INNER JOIN Socio AS s ON s.IdSocio = cm.IdSocio " +
                               "INNER JOIN Cliente AS c ON c.IdCliente = s.IdCliente " +
                               "WHERE c.TDocC = @TipoDoc AND c.DocC = @Documento AND cm.EstadoPago = 0";
                     */
                }
                else
                {
                    query = "SELECT i.IdInscripcion, a.NombreActividad, CONCAT(c.NombreC, ' ', c.ApellidoC), c.EsSocio, " +
                            "a.CostoDiario, i.Pagado " +
                            "FROM Inscripcion i " +
                            "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
                            "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
                            "INNER JOIN Cliente c ON c.TDocC = i.TipoDocCliente AND c.DocC = i.DocCliente " +
                            "WHERE i.IdInscripcion = @IdReg"; // Usamos parámetro para evitar inyección SQL.
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
                    MessageBox.Show("Documento de Cliente inexistente", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //private void btnBuscarDeudas_Click(object sender, EventArgs e)
        //{
        //    MySqlConnection sqlCon = new MySqlConnection();
        //    try
        //    {
        //        dtgvDeudas.Rows.Clear();
        //        int EsSocio;

        //        sqlCon = ConexionDB.getInstancia().CrearConexion();
        //        string query = "SELECT i.IdInscripcion, a.NombreActividad, i.FechaInscripcion, a.CostoDiario, c.EsSocio " +
        //                       "FROM Inscripcion i " +
        //                       "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
        //                       "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
        //                       "INNER JOIN Cliente c ON c.TDocC = i.TipoDocCliente AND c.DocC = i.DocCliente " +
        //                       "WHERE c.TDocC = @TipoDoc AND c.DocC = @Documento AND i.Pagado = 0";

        //        // Usar parámetros para los valores
        //        MySqlCommand comando = new MySqlCommand(query, sqlCon);
        //        comando.CommandType = CommandType.Text;

        //        // Definir los parámetros con sus valores
        //        comando.Parameters.AddWithValue("@TipoDoc", cboTipoDocCPagos.Text);
        //        comando.Parameters.AddWithValue("@Documento", txtDocumento.Text);

        //        sqlCon.Open();
        //        MySqlDataReader reader = comando.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            reader.Read(); // Mover a la primera fila
        //            EsSocio = reader.GetInt32(4);

        //            // Recorre todas las filas
        //            do
        //            {
        //                int renglon = dtgvDeudas.Rows.Add();
        //                dtgvDeudas.Rows[renglon].Cells[0].Value = reader.GetInt32(0); // IdInscripcion
        //                dtgvDeudas.Rows[renglon].Cells[2].Value = reader.GetDateTime(2); // FechaInscripcion

        //                if (EsSocio == 0)
        //                {
        //                    // No es socio, se muestra el costo de la actividad
        //                    dtgvDeudas.Columns[1].HeaderText = "Actividad";
        //                    dtgvDeudas.Rows[renglon].Cells[1].Value = reader.GetString(1); // NombreActividad
        //                    dtgvDeudas.Rows[renglon].Cells[3].Value = reader.GetFloat(3); // CostoDiario
        //                }
        //                else
        //                {
        //                    // Es socio, se muestra la cuota mensual
        //                    dtgvDeudas.Columns[1].HeaderText = "Cuota";
        //                    dtgvDeudas.Rows[renglon].Cells[1].Value = "Mensual";
        //                    dtgvDeudas.Rows[renglon].Cells[3].Value = doc.ValorCuota;
        //                }

        //            } while (reader.Read());
        //        }
        //        else
        //        {
        //            MessageBox.Show("EL CLIENTE NO REGISTRA DEUDAS");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //        {
        //            sqlCon.Close();
        //        }
        //    }
        //}

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


    }
}
