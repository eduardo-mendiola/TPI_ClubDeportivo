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

            // Inicio de la aplicaci�n con la configuraci�n de la base de datos 
            ApplicationConfiguration.Initialize();

            try
            {
                // Intenta inicializar la conexi�n a la base de datos.
                ConexionDB.getInstancia();

                // Si la conexi�n es exitosa, procede a abrir el formulario de login.
                Application.Run(new FrmLogin());
            }
            catch (InvalidOperationException ex)
            {
                // Si la configuraci�n es cancelada, muestra el mensaje y cierra la aplicaci�n.
                MessageBox.Show(ex.Message, "Configuraci�n cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit(); // Cierra la aplicaci�n si la configuraci�n es cancelada.
            }
            catch (Exception ex)
            {
                // Si falla la conexi�n, muestra un mensaje de error y cierra la aplicaci�n.
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Cierra la aplicaci�n si hay un error en la conexi�n.
            }


        }
    }
}