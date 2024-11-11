using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos;
using TPI_ClubDeportivo.Datos.Infrastructure;

namespace TPI_ClubDeportivo.Entidades
{
    public class E_Actividad
    {
        public int IdActividad { get; private set; }
        public string? TipoDoc { get; private set; }
        public string? DocCliente { get; private set; }

        public E_Cliente cliente { get; private set; }


        public E_Actividad()
        {
            cliente = new E_Cliente();
        }

        public void SetIdActividad(int idActividad)
        {
            IdActividad = idActividad;
        }

        public void SetDocCliente(string DocCliente)
        {
            this.DocCliente = DocCliente;
        }

        public void SetTipoDoc(string TipoDoc)
        {
            this.TipoDoc = TipoDoc;
        }

        public bool VerificarDisponibilidad(int CodAct)
        {
            bool Respuesta = false;
            try
            {
                using (MySqlConnection sqlCon = ConexionDB.getInstancia().CrearConexion())
                {
                    sqlCon.Open();
                    string query = "SELECT MaxParticipantes, CantInscriptos " +
                                   "FROM Actividad a " +
                                   "INNER JOIN Edicion e ON a.NActividad = e.NActividad " +
                                   "WHERE e.IdEdicion = @CodAct";

                    MySqlCommand comando = new MySqlCommand(query, sqlCon);
                    comando.Parameters.AddWithValue("@CodAct", CodAct);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int maxParticipantes = reader.GetInt32(0);
                            int cantInscriptos = reader.GetInt32(1);
                            int cupoDisponible = maxParticipantes - cantInscriptos;

                            // Comprueba si hay cupo disponible
                            Respuesta = cupoDisponible > 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo obtener el cupo disponible de la actividad.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar el cupo disponible: " + ex.Message);
            }
            return Respuesta;
        }

        public bool InscribirEnActividad(string TipoDoc, string Doc, string IdActividad)
        {
            if (string.IsNullOrEmpty(TipoDoc) || string.IsNullOrEmpty(Doc) || string.IsNullOrEmpty(IdActividad))
            {
                MessageBox.Show("Debe completar todos los datos requeridos", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }

            // Verificar si el cliente existe
            if (!cliente.ClienteExiste(TipoDoc, Doc))
            {
                MessageBox.Show("El cliente no existe en el sistema.");
                return false; // Salir del método si el cliente no existe
            }

            // Verifica si IdActividad es un número válido
            if (!int.TryParse(IdActividad, out int idActividad))
            {
                MessageBox.Show("El ID de la actividad debe ser un número válido.", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            string respuesta;
            E_Actividad inscripcion = new E_Actividad();

            inscripcion.SetTipoDoc(TipoDoc);
            inscripcion.SetDocCliente(Doc);
            inscripcion.SetIdActividad(idActividad);

            if (VerificarDisponibilidad(idActividad))
            {
                D_Actividad inscribir = new D_Actividad();
                respuesta = inscribir.Nueva_Inscripcion(inscripcion);

                if (int.TryParse(respuesta, out int codigo))
                {
                    if (codigo == 1)
                    {
                        MessageBox.Show("El cliente ya está inscrito en la actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Se inscribió con éxito el cliente con documento: " + TipoDoc + ": " + Doc + " a la Actividad ID: " + IdActividad, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Error al procesar la inscripción. Verifique que los datos ingresados sean correctos.", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No hay cupos disponibles en la actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void ListarActividadesRegistradas(DataGridView dataGridView)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                // Limpiar las filas previas de la grilla
                dataGridView.Rows.Clear();
                int EsSocio;

                sqlCon = ConexionDB.getInstancia().CrearConexion();

                // Ajustar la consulta para filtrar las cuotas que vencen hoy
                string query = "SELECT e.IdEdicion, a.NombreActividad, a.DuracionMinutos, a.MaxParticipantes, a.CantInscriptos, a.CostoDiario, " +
                               "e.Fecha, e.HorarioActividad, e.DiasActividad, CONCAT(i.NombreInst, ' ', i.ApellidoInst) AS ApellidoInstructor " +
                               "FROM Actividad AS a " +
                               "INNER JOIN Edicion AS e ON a.NActividad = e.NActividad " +
                               "INNER JOIN Instructor AS i ON e.Instructor = i.NInstructor " +
                               "ORDER BY a.NombreActividad, e.Fecha, e.HorarioActividad;";

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

                        dataGridView.Rows[renglon].Cells[0].Value = reader.GetInt32(0);  // IdEdicion
                        dataGridView.Rows[renglon].Cells[1].Value = reader.GetString(1);  // NombreActividad
                        dataGridView.Rows[renglon].Cells[2].Value = reader.GetInt32(2);  // DuracionMinutos
                        dataGridView.Rows[renglon].Cells[3].Value = reader.GetInt32(3);  // MaxParticipantes
                        // Si la cantidad de inscritos es igual al máximo
                        if (reader.GetInt32(4) == reader.GetInt32(3))
                        {
                            dataGridView.Rows[renglon].Cells[4].Value = "COMP.";
                        }
                        else
                        {
                            dataGridView.Rows[renglon].Cells[4].Value = reader.GetInt32(4);  // CantInscriptos
                        }
                        dataGridView.Rows[renglon].Cells[5].Value = reader.GetFloat(5);   // CostoDiario
                        dataGridView.Rows[renglon].Cells[6].Value = reader.GetDateTime(6); // Fecha
                        dataGridView.Rows[renglon].Cells[7].Value = reader.GetTimeSpan(7).ToString(@"hh\:mm"); // HorarioActividad
                        dataGridView.Rows[renglon].Cells[8].Value = reader.GetString(8);  // DiasActividad
                        dataGridView.Rows[renglon].Cells[9].Value = reader.GetString(9);  // ApellidoInstructor

                    }
                }
                else
                {
                    MessageBox.Show("No hay ACTIVIDADES registradas.");
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
