using TPI_ClubDeportivo.Datos;
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
    internal class Clientes
    {
        public String Nuevo_Cliente(E_Cliente cliente)
        {
            String? salida;

            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("NuevoCliente", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("Nom", MySqlDbType.VarChar).Value = cliente.NombreC;
                comando.Parameters.Add("Ape", MySqlDbType.VarChar).Value = cliente.ApellidoC;
                comando.Parameters.Add("Tip", MySqlDbType.VarChar).Value = cliente.TDocC;
                comando.Parameters.Add("Doc", MySqlDbType.VarChar).Value = cliente.DocC;
                comando.Parameters.Add("FechaNac", MySqlDbType.DateTime).Value = cliente.FechaNacimientoC;
                comando.Parameters.Add("Tel", MySqlDbType.VarChar).Value = cliente.TelC;
                comando.Parameters.Add("Domicilio", MySqlDbType.VarChar).Value = cliente.DomicilioC;
                comando.Parameters.Add("Email", MySqlDbType.VarChar).Value = cliente.EmailC;
                comando.Parameters.Add("EsSocio", MySqlDbType.Int32).Value = cliente.EsSocio ? 1 : 0;


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
