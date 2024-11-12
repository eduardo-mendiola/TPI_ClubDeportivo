using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Datos.Infrastructure;

namespace TPI_ClubDeportivo.Presentacion.Formularios
{
    public partial class frmCarnet : Form
    {
        private string numeroCliente;
        public frmCarnet()

        {
            InitializeComponent();

        }

        private void btnSalirCarnet_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

     
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "select * from cliente WHERE (TDocC = @TipoDocumento AND DocC = @DNI)";
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();

                comando.Parameters.AddWithValue("@TipoDocumento", cboTipoDoc.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@DNI", txtDni.Text);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtNombreCarnet.Text = reader["NombreC"].ToString();
                    txtApellidoCarnet.Text = reader["ApellidoC"].ToString();
                    txtCategoria.Text = (reader["EsSocio"].ToString() == "1") ? "Socio" : "No Socio";
                    if (reader["AptoFisico"].ToString() == "1")
                    {
                        txtAptoFisico.Text = "Entregado";
                    }
                    else
                    {
                        txtAptoFisico.Text = "Adeuda";
                    }
                    txtFechaAlta.Text = Convert.ToDateTime(reader["FechaRegistro"]).ToString("dd/MM/yyy");
                    DateTime fechaAlta = Convert.ToDateTime(txtFechaAlta.Text);
                    DateTime fechaVencimiento = fechaAlta.AddMonths(6);
                    txtVencimiento.Text = fechaVencimiento.ToString("dd/MM/yyyy");
                }
                else
                {
                    MessageBox.Show("No se encontraron los datos del Cliente");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            /* ---------------------------------------------------
             *   Ocultamos los botones que no pertenecen al diseño
             *   pero si para la funcionalidad.
             *   Usamos la propiedad VISIBLE y los posibles valores
             *   son True o False.
             -----------------------------------------------------*/

            btnImprimirCarnet.Visible = false;
            btnBuscarCliente.Visible = false;
            btnSalirCarnet.Visible = false;

            /*------------------------------------------------------
             *  Creamos los objetos para la impresión.
             *----------------------------------------------------*/

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirFormCarnet);
            pd.Print();

            btnImprimirCarnet.Visible = true; // Visualizamos nuevamente el objeto

            /*------------------------------------------------------
             *   Regreso al formulario principal
             *   después del dar aviso
             *-----------------------------------------------------*/

            MessageBox.Show("Operación exiatosa", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Mostrar frmPagar y ocultar frmFactura
            if (this.Owner != null)
            {
                this.Owner.Show();  // Mostramos frmPrincipal
            }
            this.Hide();  // Ocultamos frmFactura No cerrarlo
        }

        /*----------------------------------------------------------
         *   Conjunto de sentencias necesarias para el objeto Print
         ----------------------------------------------------------*/
        //private void ImprimirFormCarnet(object o, PrintPageEventArgs e)
        //{
        //    int x = SystemInformation.WorkingArea.X;
        //    int y = SystemInformation.WorkingArea.Y;
        //    int ancho = this.Width;
        //    int alto = this.Height;
        //    Rectangle bounds = new Rectangle(x, y, ancho, alto);
        //    Bitmap img = new Bitmap(ancho, alto);
        //    this.DrawToBitmap(img, bounds);
        //    Point p = new Point(100, 100);
        //    e.Graphics.DrawImage(img, p);
        //}


        //private void ImprimirFormCarnet(object o, PrintPageEventArgs e)
        //{
        //    int anchoOriginal = this.Width;
        //    int altoOriginal = this.Height;

        //    // Crear una captura del formulario con el tamaño original
        //    Bitmap img = new Bitmap(anchoOriginal, altoOriginal);
        //    Rectangle bounds = new Rectangle(0, 0, anchoOriginal, altoOriginal);
        //    this.DrawToBitmap(img, bounds);

        //    // Definir el tamaño de la tarjeta en píxeles para una escala aproximada
        //    int tarjetaAnchoPx = 270;  // Ancho en píxeles aproximado para una tarjeta de crédito (85.6 mm)
        //    int tarjetaAltoPx = 170;   // Alto en píxeles aproximado para una tarjeta de crédito (54 mm)

        //    // Escalar la imagen al tamaño deseado de una tarjeta de crédito
        //    Bitmap imgRedimensionada = new Bitmap(img, new Size(tarjetaAnchoPx, tarjetaAltoPx));

        //    // Dibuja la imagen redimensionada en la posición deseada
        //    Point posicion = new Point(100, 100); // Ajusta según donde quieras colocar la tarjeta en la hoja
        //    e.Graphics.DrawImage(imgRedimensionada, posicion);
        //}

        private void ImprimirFormCarnet(object o, PrintPageEventArgs e)
        {
            // Factor de escala 
            double factorEscala = 0.5; // Ajusta de la escala

            // Tamaño original del formulario
            int anchoOriginal = this.Width;
            int altoOriginal = this.Height;

            // Crear una captura del formulario con el tamaño original
            Bitmap img = new Bitmap(anchoOriginal, altoOriginal);
            Rectangle bounds = new Rectangle(0, 0, anchoOriginal, altoOriginal);
            this.DrawToBitmap(img, bounds);

            // Aplicar el factor de escala
            int anchoEscalado = (int)(anchoOriginal * factorEscala);
            int altoEscalado = (int)(altoOriginal * factorEscala);

            // Crear la imagen redimensionada con el nuevo tamaño escalado
            Bitmap imgRedimensionada = new Bitmap(img, new Size(anchoEscalado, altoEscalado));

            // Dibuja la imagen redimensionada en la posición deseada
            Point posicion = new Point(100, 100); // Ajusta según donde quieras colocar la imagen en la hoja
            e.Graphics.DrawImage(imgRedimensionada, posicion);
        }

        
    }

}
