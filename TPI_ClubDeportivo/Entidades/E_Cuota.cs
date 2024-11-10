using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Entidades.Enums;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_Cuota
    {
        public int IdCuota { get; private set; }
        public E_Cliente cliente { get; private set; }
        public TipoDePagoEnum TipoDePago { get; private set; }
        public CantCuotasEnum CantCuotas { get; private set; }
        public double ValorCuota { get; private set; }
        public DateTime fechaPago { get; private set; }
        public DateTime FechaVencimiento {  get; private set; }


        public E_Cuota() 
        { 
            SetValorCuota(); 
        }

        private double SetValorCuota()
        {
            return ValorCuota = 9999.88;
        }

        public double GetValorCuota() { return ValorCuota; }

        public void ListarCuotasVencenHoy(DataGridView dataGridView)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                // Limpiar las filas previas de la grilla
                dataGridView.Rows.Clear();
                int EsSocio;

                sqlCon = ConexionDB.getInstancia().CrearConexion();

                // Ajustar la consulta para filtrar las cuotas que vencen hoy
                string query = "SELECT i.IdInscripcion, a.NombreActividad, i.FechaInscripcion, a.CostoDiario " +
                               "FROM Inscripcion i " +
                               "INNER JOIN Edicion e ON i.IdEdicion = e.IdEdicion " +
                               "INNER JOIN Actividad a ON a.Nactividad = e.Nactividad " +
                               "INNER JOIN Cliente c ON c.TDocC = i.TipoDocCliente AND c.DocC = i.DocCliente " +
                               "WHERE AND i.FechaVencimiento = CURDATE()"; 

                // Usar parámetros para evitar inyecciones SQL
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.CommandType = CommandType.Text;

                sqlCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    // Recorrer todas las filas
                    while (reader.Read())
                    {
                        int renglon = dataGridView.Rows.Add();
                        EsSocio = reader.GetInt32(4); // Leer EsSocio

                        dataGridView.Rows[renglon].Cells[0].Value = reader.GetInt32(0); // IdInscripcion
                        dataGridView.Columns[1].HeaderText = "Actividad";
                        dataGridView.Rows[renglon].Cells[1].Value = reader.GetString(1); // NombreActividad
                        dataGridView.Rows[renglon].Cells[2].Value = reader.GetDateTime(2); // FechaInscripcion
                        dataGridView.Rows[renglon].Cells[3].Value = reader.GetFloat(3); // Valor a pagar

                    }
                }
                else
                {
                    MessageBox.Show("No hay deudas para este cliente.");
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
