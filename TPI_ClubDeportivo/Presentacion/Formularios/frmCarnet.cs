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
using TPI_ClubDeportivo.Entidades;
using TPI_ClubDeportivo.Interfaces;

namespace TPI_ClubDeportivo.Presentacion.Formularios
{
    public partial class frmCarnet : Form
    {
        public frmCarnet()

        {
            InitializeComponent();

        }

        // Salir del frmCarnet al formulario propietario, si no tiene oculta frmCarnet
        private void btnSalirCarnet_Click(object sender, EventArgs e)
        {
            
            if (this.Owner != null)
            {
                this.Owner.Show();  // Mostramos frmPrincipal
            }
            this.Hide();  // Ocultamos frmCarnet No cerrarlo
        }

     
        // Buscar cliente y cargar datos en el formulario
        public void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "SELECT c.*, s.IdSocio " +
                        "FROM Cliente c " +
                        "LEFT JOIN Socio s ON c.IdCliente = s.IdCliente " +
                        "WHERE c.TDocC = @TipoDocumento AND c.DocC = @DNI";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();

                comando.Parameters.AddWithValue("@TipoDocumento", cboTipoDoc.SelectedItem.ToString());
                comando.Parameters.AddWithValue("@DNI", txtDocumento.Text);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtNombreCarnet.Text = reader["NombreC"].ToString();
                    txtApellidoCarnet.Text = reader["ApellidoC"].ToString();

                    if (reader["EsSocio"].ToString() == "1")
                    {
                        txtCategoria.Text = "Socio";
                        lblNroSocio.Visible = true;
                        txtNroSocio.Visible = true;
                        txtNroSocio.Text = reader["IdSocio"].ToString();
                    }
                    else
                    {
                        txtCategoria.Text = "No Socio";
                        lblNroSocio.Visible = false;
                        txtNroSocio.Visible = false;
                    }


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

        // Imprimir en un pdf el carnet
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

       // Captura imagen del formulario y ajusta la escala
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
