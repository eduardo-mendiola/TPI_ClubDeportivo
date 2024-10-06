using MySql.Data.MySqlClient; // Librería para interactuar con MySQL
using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace TPI_ClubDeportivo.Datos 
{
    internal class Usuarios 
    {
        // Método que retorna un DataTable con la información de usuario tras un intento de inicio de sesión
        /*
         Una DataTable es una clase en .NET que representa una tabla en memoria. Es parte del espacio de nombres 
         System.Data y se utiliza comúnmente para almacenar y manipular datos en aplicaciones que trabajan con 
         bases de datos.
         */
        public DataTable Log_Usu(string L_Usu, string P_Usu)
        {
            MySqlDataReader resultado; // Variable para leer los resultados de la consulta
            DataTable tabla = new DataTable(); // DataTable para almacenar los resultados de la consulta
            MySqlConnection sqlCon = new MySqlConnection(); // Inicialización de la conexión a la base de datos

            try
            {
                // Obtener la conexión usando el método de la clase Conexion
                sqlCon = Conexion.getInstancia().CrearConexion();

                // Crear un comando SQL que ejecutará el procedimiento almacenado 'ingresoLogin'
                MySqlCommand comando = new MySqlCommand("ingresoLogin", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure // Especificar que es un procedimiento almacenado
                };

                // Definir los parámetros para el procedimiento almacenado
                comando.Parameters.Add("Usu", MySqlDbType.VarChar).Value = L_Usu; // Agregar el parámetro de usuario
                comando.Parameters.Add("Pass", MySqlDbType.VarChar).Value = P_Usu; // Agregar el parámetro de contraseña

                // Abrir la conexión a la base de datos
                sqlCon.Open();

                // Ejecutar el comando y almacenar el resultado en 'resultado'
                resultado = comando.ExecuteReader();

                // Cargar el resultado del DataReader en el DataTable
                tabla.Load(resultado); // Llenar el DataTable con los datos devueltos por el procedimiento almacenado

                // De esta forma, este método se asocia con el procedimiento almacenado en MySQL

                return tabla; // Retornar el DataTable con los resultados
            }
            catch (Exception ex) // Manejo de excepciones
            {
                throw; // Relanzar la excepción para ser manejada en un nivel superior
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close(); // Cerrar la conexión para liberar recursos
                }
            }
        }
    }
}
