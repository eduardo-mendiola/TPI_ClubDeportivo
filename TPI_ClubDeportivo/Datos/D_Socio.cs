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
    internal class D_Socio
    {
        public String Nuevo_Socio(E_Socio socio)
        {
            String? salida;

            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("RegCuotaSocio", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("P_IdCliente", MySqlDbType.VarChar).Value = socio.GetIdCliente();
                comando.Parameters.Add("P_IdSocio", MySqlDbType.VarChar).Value = socio.GetIdSocio();
                comando.Parameters.Add("Monto", MySqlDbType.Float).Value = socio.Cuota.GetValorCuota();
                

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
