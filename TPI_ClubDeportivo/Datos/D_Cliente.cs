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
    internal class D_Cliente
    {
        public String Nuevo_Cliente(E_Cliente cliente)
        {
            String? salida;

            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = D_Conexion.getInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("NuevoCliente", sqlCon);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("Nom", MySqlDbType.VarChar).Value = cliente.Nombre;
                comando.Parameters.Add("Ape", MySqlDbType.VarChar).Value = cliente.Apellido;
                comando.Parameters.Add("Tip", MySqlDbType.VarChar).Value = cliente.TipoDoc;
                comando.Parameters.Add("Doc", MySqlDbType.VarChar).Value = cliente.Doc;
                comando.Parameters.Add("FechaNac", MySqlDbType.DateTime).Value = cliente.FechaNacimiento;
                comando.Parameters.Add("Tel", MySqlDbType.VarChar).Value = cliente.Tel;
                comando.Parameters.Add("Domicilio", MySqlDbType.VarChar).Value = cliente.Domicilio;
                comando.Parameters.Add("Email", MySqlDbType.VarChar).Value = cliente.Email;
                comando.Parameters.Add("EsSocio", MySqlDbType.Int32).Value = cliente.EsSocio ? 1 : 0;
                comando.Parameters.Add("AptoFisico", MySqlDbType.Int32).Value = cliente.AptoFisico ? 1 : 0;


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
