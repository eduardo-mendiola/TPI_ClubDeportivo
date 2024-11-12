using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Interfaces;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_NoSocio : IPago
    {

        public E_Cliente cliente { get; private set; }

        public E_NoSocio()
        {
            cliente = new E_Cliente();
        }

        // Realiza el pago y registra el pago en la base de datos
        public void RealizarPago(string IdPago)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "UPDATE InscripcionAct SET Pagado = 1 WHERE IdInscripcionAct = @IdInscripcionAct";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@IdInscripcionAct", IdPago);
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

        // Trae los datos de la bd del cliente, verifica si tiene deudas y carga los datos en una grilla
        public void ObtenerDeuda(DataGridView dataGridView, string TipoDocPago, string Documento)
        {
            // Verificar si el cliente existe
            if (!cliente.ClienteExiste(TipoDocPago, Documento))
            {
                MessageBox.Show("El cliente no existe en el sistema.");
                return; // Salir del método si el cliente no existe
            }

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                dataGridView.Rows.Clear();

                sqlCon = ConexionDB.getInstancia().CrearConexion();
                string query = "SELECT i.IdInscripcionAct, a.NombreActividad, i.FechaInscripcion, a.CostoDiario " +
                               "FROM InscripcionAct i " +
                               "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
                               "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
                               "INNER JOIN Cliente c ON c.TDocC = i.TipoDocCliente AND c.DocC = i.DocCliente " +
                               "WHERE c.TDocC = @TipoDoc AND c.DocC = @Documento AND i.Pagado = 0";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@TipoDoc", TipoDocPago);
                comando.Parameters.AddWithValue("@Documento", Documento);

                sqlCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                if (dataGridView.Columns.Count > 1)
                {
                    dataGridView.Columns[1].HeaderText = "Actividad";
                }

                bool hayDeudas = false;
                while (reader.Read())
                {
                    hayDeudas = true;
                    int renglon = dataGridView.Rows.Add();
                    dataGridView.Rows[renglon].Cells[0].Value = reader.GetInt32(0);  // IdInscripcionAct
                    dataGridView.Rows[renglon].Cells[1].Value = reader.GetString(1); // NombreActividad
                    dataGridView.Rows[renglon].Cells[2].Value = reader.GetDateTime(2); // FechaInscripcion
                    dataGridView.Rows[renglon].Cells[3].Value = reader.GetDecimal(3);  // CostoDiario
                }

                // Mensaje si no hay deudas
                if (!hayDeudas)
                {
                    MessageBox.Show("El cliente no registra deudas.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las deudas del cliente: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }


    }
}
