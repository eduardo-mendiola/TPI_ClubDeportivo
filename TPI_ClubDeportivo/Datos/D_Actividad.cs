using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Entidades;

namespace TPI_ClubDeportivo.Datos
{
    internal class D_Actividad
    {
        public String Nueva_Inscripcion(E_Actividad inscripcion)
        {
            String? salida;

            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("InsActividad", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("TipoDoc", MySqlDbType.VarChar).Value = inscripcion.TipoDoc;
                comando.Parameters.Add("NumDocCliente", MySqlDbType.VarChar).Value = inscripcion.DocCliente;
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
