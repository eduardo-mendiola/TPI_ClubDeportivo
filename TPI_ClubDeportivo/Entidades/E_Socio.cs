﻿using MySql.Data.MySqlClient;
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
    internal class E_Socio : E_Cliente, IPago
    {
        public string IdSocio { get; private set; }
        public E_Cuota Cuota { get; private set; }
       
        public bool CuotaMensualPagada { get; private set; }


        public E_Socio() 
        {
            Cuota = new E_Cuota();
        }

        // Setters y Getters
        public double GetValorCuota()
        {
            return this.Cuota.ValorCuota;
        }

        public void SetIdSocio(E_Cliente cliente)
        {
            string ultimosDosDigitos = DateTime.Now.ToString("yy");
            string sufijo = "-" + ultimosDosDigitos;
            string prefijo;

            switch (cliente.TipoDoc)
            {
                case "DNI":
                    prefijo = "1-";
                    break;
                case "PASAPORTE":
                    prefijo = "2-";
                    break;
                case "EXTRANJERO":
                    prefijo = "3-";
                    break;
                default:
                    prefijo = "0-";
                    break;
            }

            IdSocio = prefijo + cliente.Doc + sufijo;
        }

        public string GetIdSocio()
        {
            return this.IdSocio;
        }

        // Realiza el pago y registra el pago en la base de datos
        public void RealizarPago(string IdPago)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "UPDATE CuotaMensual SET EstadoPago = 1 WHERE IdPago = @IdPago";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@IdPago", IdPago);
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
            if (!ClienteExiste(TipoDocPago, Documento))
            {
                MessageBox.Show("El cliente no existe en el sistema.");
                return; // Salir del método si el cliente no existe
            }


            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                dataGridView.Rows.Clear(); // Limpiar la grilla antes de cargar datos

                sqlCon = ConexionDB.getInstancia().CrearConexion();
                string query = "SELECT cm.IdPago, cm.IdSocio, cm.FechaVencimiento, cm.Monto " +
                                       "FROM CuotaMensual AS cm " +
                                       "INNER JOIN Socio AS s ON s.IdSocio = cm.IdSocio " +
                                       "INNER JOIN Cliente AS c ON c.IdCliente = s.IdCliente " +
                                       "WHERE c.TDocC = @TipoDoc AND c.DocC = @Documento AND cm.EstadoPago = 0";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@TipoDoc", TipoDocPago);
                comando.Parameters.AddWithValue("@Documento", Documento);

                sqlCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                // Configura los encabezados de columna solo una vez fuera del bucle
                if (dataGridView.Columns.Count > 1)
                {
                    dataGridView.Columns[1].HeaderText = "ID Socio";
                    dataGridView.Columns[2].HeaderText = "Fecha Vencimiento";
                }

                // Procesa todas las filas encontradas
                while (reader.Read())
                {
                    int renglon = dataGridView.Rows.Add();
                    dataGridView.Rows[renglon].Cells[0].Value = reader.GetInt32(0);  // IdPago
                    dataGridView.Rows[renglon].Cells[1].Value = reader.GetString(1);  // IdSocio
                    dataGridView.Rows[renglon].Cells[2].Value = reader.GetDateTime(2).ToString("dd/MM/yyyy"); // FechaVencimiento
                    dataGridView.Rows[renglon].Cells[3].Value = reader.GetDecimal(3);  // CostoDiario
                }

                // Mensaje si no hay filas en la consulta
                if (!reader.HasRows)
                {
                    MessageBox.Show("El cliente no registra deudas.", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close();
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
