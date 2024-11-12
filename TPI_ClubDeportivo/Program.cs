using MySql.Data.MySqlClient;
using System.Data;
using TPI_ClubDeportivo;
using TPI_ClubDeportivo.Datos.Infrastructure;

namespace TPI_ClubDeportivo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //ApplicationConfiguration.Initialize();
            //Application.Run(new FrmLogin());

            // Inicio de la aplicación con la configuración de la base de datos 
            ApplicationConfiguration.Initialize();

            try
            {
                // Intenta inicializar la conexión a la base de datos.
                ConexionDB.getInstancia();

                // Si la conexión es exitosa, procede a abrir el formulario de login.
                Application.Run(new FrmLogin());
            }
            catch (InvalidOperationException ex)
            {
                // Si la configuración es cancelada, muestra el mensaje y cierra la aplicación.
                MessageBox.Show(ex.Message, "Configuración cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // Cierra la aplicación si la configuración es cancelada.
            }
            catch (Exception ex)
            {
                // Si falla la conexión, muestra un mensaje de error y cierra la aplicación.
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Cierra la aplicación si hay un error en la conexión.
            }


        }
    }
}