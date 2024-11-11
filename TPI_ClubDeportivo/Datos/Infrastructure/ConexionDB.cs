using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Datos.Infrastructure
{
    public class ConexionDB
    {
        // Definición de variables privadas para almacenar la configuración de conexión
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;
        private static ConexionDB? con = null; // Variable estática para la instancia de conexión

        // Constructor de la clase Conexion
        private ConexionDB()
        {
            bool correcto = false;
            int mensaje;

            // Valores predeterminados sugeridos
            string T_servidor = "localhost"; // Servidor sugerido
            string T_puerto = "3306"; // Puerto sugerido para MySQL
            string T_usuario = "root"; // Usuario sugerido
            string T_clave = "root"; // Contraseña sugerida 

            while (!correcto)
            {
                // Muestra los valores predeterminados en cada campo
                T_servidor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Servidor", "DATOS DE INSTALACIÓN MySQL", T_servidor);
                T_puerto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Puerto", "DATOS DE INSTALACIÓN MySQL", T_puerto);
                T_usuario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Usuario", "DATOS DE INSTALACIÓN MySQL", T_usuario);
                T_clave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Clave", "DATOS DE INSTALACIÓN MySQL", T_clave);

                mensaje = (int)MessageBox.Show("Su Ingreso: SERVIDOR = " + T_servidor + " PUERTO= " + T_puerto + " USUARIO: " 
                    + T_usuario + " CLAVE: " + T_clave, "AVISO DEL SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (mensaje == 6)  // Si el usuario confirma
                {
                    // Intentamos validar la conexión
                    if (ValidarConexion(T_servidor, T_puerto, T_usuario, T_clave))
                    {
                        correcto = true; // Si la validación fue exitosa, terminamos el loop
                    }
                    else
                    {
                        MessageBox.Show("Error de conexión. Verifique los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese nuevamente los datos");
                }

            }


            this.baseDatos = "ClubDeportivo";
            this.servidor = T_servidor;
            this.puerto = T_puerto;
            this.usuario = T_usuario;
            this.clave = T_clave;
        }

        // Método para Validad la conexion
        private bool ValidarConexion(string servidor, string puerto, string usuario, string clave)
        {
            string cadenaConexion = $"datasource={servidor};port={puerto};username={usuario};password={clave};";
            using (var conexionPrueba = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexionPrueba.Open();
                    return true;
                }
                catch
                {
                    return false; // Si ocurre un error en la conexión, devolvemos false
                }
            }
        }


        // Método para crear una conexión a la base de datos
        public MySqlConnection CrearConexion()
        {
            // Instanciamos una conexión
            MySqlConnection? cadena = new MySqlConnection();

            // El bloque try permite controlar errores
            try
            {
                // Construir la cadena de conexión utilizando las propiedades definidas
                cadena.ConnectionString = "datasource=" + this.servidor +
                                          ";port=" + this.puerto +
                                          ";username=" + this.usuario +
                                          ";password=" + this.clave +
                                          ";Database=" + this.baseDatos;
            }
            catch (Exception ex) // Captura cualquier excepción que ocurra
            {
                cadena = null; // Asigna null a la conexión en caso de error
                throw; // Relanza la excepción para manejarla en un nivel superior
            }
            return cadena; // Retorna la cadena de conexión
        }

        // Método para obtener la instancia única de la clase Conexion
        public static ConexionDB getInstancia()
        {
            if (con == null) // Verifica si la conexión no ha sido creada
            {
                con = new ConexionDB(); // Si no existe, se crea una nueva instancia
            }
            return con; // Retorna la instancia de conexión (puede ser nueva o existente)
        }
    }
}
