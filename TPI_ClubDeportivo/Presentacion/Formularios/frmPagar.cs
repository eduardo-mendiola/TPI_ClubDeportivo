using MySql.Data.MySqlClient;
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

namespace TPI_ClubDeportivo
{
    public partial class frmPagar : Form
    {


        public frmFactura doc = new frmFactura();


        private void frmPagar_Load(object sender, EventArgs e)
        {
            cboCuotasTarjeta.SelectedIndex = 0;
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
                String query;
                int Pagado_f;
                sqlCon = ConexionDB.getInstancia().CrearConexion();

                /*
                 ------------------------------------------------------------------
                Consulta simple que proyecta los datos necesarios para rellenar el 
                documento.
                En este caso se trata del comprobante de pago del curso.
                -------------------------------------------------------------------
                 */


                query = ("SELECT IdInscripcion, NombreActividad, CONCAT(NombreC, ' ', ApellidoC), c.EsSocio, a.CostoDiario, i.Pagado " +
                         "FROM Inscripcion i " +
                         "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
                         "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
                         "INNER JOIN Cliente c on c.Idcliente = i.Idcliente " +
                         "WHERE i.IdInscripcion = " + txtIdPago.Text); // <<<----- Usamos el dato ingresado por el usuario.


                MySqlCommand comando = new MySqlCommand(query, sqlCon);

                // Usamos la consulta y la conexion. 

                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                MySqlDataReader reader; // El DataReader almacena TODAS las filas.-

                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read(); // En este caso sabemos que si tiene datos es UNA SOLA FILA

                    doc.Numero_f = reader.GetInt32(0);
                    doc.Actividad_f = reader.GetString(1);
                    doc.Alumno_f = reader.GetString(2);
                    doc.EsSocio_f = reader.GetInt16(3);
                    doc.CostoAct_f = reader.GetFloat(4);
                    doc.Monto_f = (doc.EsSocio_f == 1) ? doc.ValorCuota : reader.GetFloat(4);
                    doc.CantCuotas_f = int.Parse(cboCuotasTarjeta.Text);
                    Pagado_f = reader.GetInt16(5);

                    if (optEfvo.Checked == true) // Evaluamos que opción es la seleccionada
                    {
                        doc.Forma_f = "Efectivo";
                        doc.Monto_f = MathF.Round((doc.Monto_f * doc.DescuentoEfectivo), 2);
                    }
                    else
                    {
                        doc.Forma_f = "Tarjeta";
                    }
                    btnComprobante.Enabled = true;

                    if (Pagado_f == 1)
                    {
                        MessageBox.Show("La factura ya esta paga", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        RegistrarPago(txtIdPago.Text);
                        MessageBox.Show("Pago realizado exitosamente", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    txtIdPago.Text = "";
                    

                    // Despues borrar, es solo para ver si se estan cargando los valores
                    System.Diagnostics.Debug.WriteLine(query);
                    System.Diagnostics.Debug.WriteLine($"{doc.Numero_f} | {doc.Actividad_f} | {doc.Alumno_f} | {doc.Monto_f} ");


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

      
        private void RegistrarPago(string IdPago)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "UPDATE Inscripcion SET Pagado = 1 WHERE IdInscripcion = @IdInscripcion";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@IdInscripcion", IdPago);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();

                // Ejecuta el comando para realizar el UPDATE
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("No se encontró ninguna inscripción con el ID proporcionado.", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        //        string query;
        //        int EsSocio;

        //        sqlCon = Conexion.getInstancia().CrearConexion();
        //        query = "SELECT i.IdInscripcion, a.NombreActividad, i.FechaInscripcion, a.CostoDiario, c.EsSocio " +
        //                "FROM Inscripcion i " +
        //                "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
        //                "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
        //                "INNER JOIN Cliente c ON c.Idcliente = i.Idcliente " +
        //                "WHERE c.DocC = " + txtDocumento.Text + " AND i.Pagado = 0";

        //        MySqlCommand comando = new MySqlCommand(query, sqlCon);
        //        comando.CommandType = CommandType.Text;
        //        sqlCon.Open();

        //        MySqlDataReader reader;
        //        reader = comando.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            EsSocio = reader.GetInt32(4);

        //            if (EsSocio == 0)
        //            {
        //                while (reader.Read())
        //                {
        //                    int renglon = dtgvDeudas.Rows.Add();
        //                    dtgvDeudas.Rows[renglon].Cells[0].Value = reader.GetInt32(0);
        //                    dtgvDeudas.Rows[renglon].Cells[1].Value = reader.GetString(1);
        //                    dtgvDeudas.Rows[renglon].Cells[2].Value = reader.GetDateTime(2);
        //                    dtgvDeudas.Rows[renglon].Cells[3].Value = reader.GetFloat(3);

        //                }
        //            }
        //            else
        //            {
        //                while (reader.Read())
        //                {
        //                    int renglon = dtgvDeudas.Rows.Add();
        //                    dtgvDeudas.Rows[renglon].Cells[0].Value = reader.GetInt32(0);
        //                    dtgvDeudas.Rows[renglon].Cells[1].Value = "Cuota Mensual";
        //                    dtgvDeudas.Rows[renglon].Cells[2].Value = reader.GetDateTime(2);
        //                    dtgvDeudas.Rows[renglon].Cells[3].Value = doc.ValorCuota;

        //                }
        //            }

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
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                dtgvDeudas.Rows.Clear();

                string query;
                int EsSocio;

                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "SELECT i.IdInscripcion, a.NombreActividad, i.FechaInscripcion, a.CostoDiario, c.EsSocio " +
                        "FROM Inscripcion i " +
                        "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
                        "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
                        "INNER JOIN Cliente c ON c.Idcliente = i.Idcliente " +
                        "WHERE c.DocC = " + txtDocumento.Text + " AND i.Pagado = 0";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read(); // Mover a la primera fila
                    EsSocio = reader.GetInt32(4);

                    // Recorre todas las filas
                    do
                    {
                        int renglon = dtgvDeudas.Rows.Add();
                        dtgvDeudas.Rows[renglon].Cells[0].Value = reader.GetInt32(0); // IdInscripcion
                        dtgvDeudas.Rows[renglon].Cells[2].Value = reader.GetDateTime(2); // FechaInscripcion

                        if (EsSocio == 0)
                        {
                            // No es socio, se muestra el costo de la actividad
                            dtgvDeudas.Columns[1].HeaderText = "Actividad";
                            dtgvDeudas.Rows[renglon].Cells[1].Value = reader.GetString(1); // NombreActividad
                            dtgvDeudas.Rows[renglon].Cells[3].Value = reader.GetFloat(3); // CostoDiario
                        }
                        else
                        {
                            // Es socio, se muestra la cuota mensual
                            dtgvDeudas.Columns[1].HeaderText = "Cuota";
                            dtgvDeudas.Rows[renglon].Cells[1].Value = "Mensual";
                            dtgvDeudas.Rows[renglon].Cells[3].Value = doc.ValorCuota;
                        }

                    } while (reader.Read());
                }
                else
                {
                    MessageBox.Show("EL CLIENTE NO REGISTRA DEUDAS");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
}
