using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Entidades;

namespace TPI_ClubDeportivo.Datos
{
    internal class InscripcionActividad
    {
        public String Nueva_Inscripcion(E_InscribirEnActividad inscripcion)
        {
            String? salida;

            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("InsActividad", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("NumCliente", MySqlDbType.Int32).Value = inscripcion.IdCliente;
                comando.Parameters.Add("IdEdi", MySqlDbType.Int32).Value = inscripcion.IdActividad;

                MySqlParameter ParCodigo = new MySqlParameter();
                ParCodigo.ParameterName = "rta";
                ParCodigo.MySqlDbType = MySqlDbType.Int32;
                ParCodigo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParCodigo);
                sqlCon.Open();
                comando.ExecuteNonQuery();
                salida = Convert.ToString(ParCodigo.Value);
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }

            // Como proceso final
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return salida;
        }
    }
}
