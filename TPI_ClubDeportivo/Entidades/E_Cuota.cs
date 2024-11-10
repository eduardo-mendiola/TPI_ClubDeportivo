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
                string query = "SELECT  cm.IdPago, cm.FechaGeneracion, cm.FechaVencimiento, s.IdSocio, " +
                               "c.NombreC, c.ApellidoC, c.TDocC, c.DocC, cm.Monto, cm.EstadoPago " +
                               "FROM CuotaMensual AS cm " +
                               "INNER JOIN Socio AS s ON cm.IdSocio = s.IdSocio " +
                               "INNER JOIN Cliente AS c ON s.IdCliente = c.IdCliente " +
                               "WHERE cm.FechaVencimiento = CURDATE();"; 

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

                        dataGridView.Rows[renglon].Cells[0].Value = reader.GetInt32(0);  // IdPago
                        dataGridView.Rows[renglon].Cells[1].Value = reader.GetDateTime(1); // FechaGeneracion
                        dataGridView.Rows[renglon].Cells[2].Value = reader.GetDateTime(2); // FechaVencimiento
                        dataGridView.Rows[renglon].Cells[3].Value = reader.GetString(3);  // IdSocio
                        dataGridView.Rows[renglon].Cells[4].Value = reader.GetString(4);  // NombreC
                        dataGridView.Rows[renglon].Cells[5].Value = reader.GetString(5);  // ApellidoC
                        dataGridView.Rows[renglon].Cells[6].Value = reader.GetString(6);  // TDocC
                        dataGridView.Rows[renglon].Cells[7].Value = reader.GetString(7);  // DocC
                        dataGridView.Rows[renglon].Cells[8].Value = reader.GetFloat(8);   // Monto
                        dataGridView.Rows[renglon].Cells[9].Value = reader.GetBoolean(9) ? "Pago" : "Impago"; // EstadoPago

                    }
                }
                else
                {
                    MessageBox.Show("No hay deudas que vencen hoy.");
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
