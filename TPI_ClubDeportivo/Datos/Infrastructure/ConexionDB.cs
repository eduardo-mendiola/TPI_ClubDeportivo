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
        private static ConexionDB? _instancia = null; // Variable estática para la instancia de conexión

        private ConexionDB()
        {
            bool correcto = false;
            int mensaje;
            string T_servidor = "localhost";
            string T_puerto = "3306";
            string T_usuario = "root";
            string T_clave = "root";

            string MensajeEncabezado = "CLUB DEPORTIVO  -  DATOS DE INSTALACIÓN MySQL";
            string MensajeCancelacion = "La configuración fue cancelada por el usuario.";

            while (!correcto)
            {
                // Pedir datos al usuario
                T_servidor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Servidor", MensajeEncabezado, T_servidor);
                if (string.IsNullOrEmpty(T_servidor))
                {
                    throw new InvalidOperationException(MensajeCancelacion); // Lanza excepción si se cancela
                }

                T_puerto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Puerto", MensajeEncabezado, T_puerto);
                if (string.IsNullOrEmpty(T_puerto))
                {
                    throw new InvalidOperationException(MensajeCancelacion);
                }

                T_usuario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Usuario", MensajeEncabezado, T_usuario);
                if (string.IsNullOrEmpty(T_usuario))
                {
                    throw new InvalidOperationException(MensajeCancelacion);
                }

                T_clave = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Clave", MensajeEncabezado, T_clave);
                if (string.IsNullOrEmpty(T_clave))
                {
                    throw new InvalidOperationException(MensajeCancelacion);
                }

                // Confirmación de los datos ingresados
                mensaje = (int)MessageBox.Show("Su Ingreso: SERVIDOR = " + T_servidor + " PUERTO= " + T_puerto + " USUARIO: "
                    + T_usuario + " CLAVE: " + T_clave, "AVISO DEL SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mensaje == (int)DialogResult.Yes)
                {
                    if (ValidarConexion(T_servidor, T_puerto, T_usuario, T_clave))
                    {
                        correcto = true;
                    }
                    else
                    {
                        MessageBox.Show("Error de conexión. Verifique los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult confirmExit = MessageBox.Show("¿Desea cancelar la configuración de la conexión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmExit == DialogResult.Yes)
                    {
                        throw new InvalidOperationException("La conexión fue cancelada por el usuario."); // Lanza excepción si se cancela
                    }
                }
            }

            // Asignar valores a las variables si todo está bien
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
            if (_instancia == null)
            {
                _instancia = new ConexionDB();
            }
            return _instancia;
        }

    }
}
