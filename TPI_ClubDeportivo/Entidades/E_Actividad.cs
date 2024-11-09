using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos;
using TPI_ClubDeportivo.Datos.Infrastructure;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_Actividad
    {
        public int IdActividad { get; private set; }
        public string? TipoDoc { get; private set; }
        public string? DocCliente { get; private set; }

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
                    MessageBox.Show("Error al procesar la inscripción. Respuesta inesperada: " + respuesta, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No hay cupos disponibles en la actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
