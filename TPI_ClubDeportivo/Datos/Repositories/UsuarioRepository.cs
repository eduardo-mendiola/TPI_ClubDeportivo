using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Datos.Interfaces;

namespace TPI_ClubDeportivo.Datos.Repositories
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        // Método que obtiene el usuario basado en el nombre y contraseña
        public DataTable ObtenerUsuarioPorCredenciales(string nombreUsuario, string password)
        {
            MySqlDataReader resultado;
            DataTable tabla = new DataTable();
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                // Obtener la conexión usando el método de la clase ConexionDB.
                sqlCon = ConexionDB.getInstancia().CrearConexion();

                // Crear un comando SQL que ejecutará el procedimiento almacenado 'ingresoLogin'.
                MySqlCommand comando = new MySqlCommand("ingresoLogin", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure // Especificar que es un procedimiento almacenado.
                };

                // Definir los parámetros para el procedimiento almacenado.
                comando.Parameters.Add("Usu", MySqlDbType.VarChar).Value = nombreUsuario;
                comando.Parameters.Add("Pass", MySqlDbType.VarChar).Value = password;

                // Abrir la conexión a la base de datos.
                sqlCon.Open();

                // Ejecutar el comando y almacenar el resultado en 'resultado'.
                resultado = comando.ExecuteReader();

                // Cargar el resultado del DataReader en el DataTable.
                tabla.Load(resultado);

                return tabla; // Retornar el DataTable con los resultados.
            }
            catch (Exception ex)
            {
                // Aquí podrías hacer un log del error antes de relanzarlo si es necesario.
                throw new Exception("Error al obtener el usuario por credenciales.", ex);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close(); // Cerrar la conexión para liberar recursos.
                }
            }
        }
    }
}
