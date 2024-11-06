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

namespace TPI_ClubDeportivo
{
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        /*---------------------------------------------------
             Variables para traer LOS DATOS del formulario
              donde se ejecuta la lógica
        ------------------------------------------------------*/

        public string? Alumno_f;
        public string? Actividad_f;
        public float? CostoAct_f;
        public string? TipoPago_f;
        public float Monto_f;
        public int? Numero_f;
        public int? EsSocio_f;
        public string? Forma_f;
        public int CantCuotas_f;
        private float MontoPago;
        public float DescuentoEfectivo = 0.90f;
        public float ValorCuota = 9999.99f;

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            /* ---------------------------------------------------
             *   Ocultamos los botones que no pertenecen al diseño
             *   pero si para la funcionalidad.
             *   Usamos la propiedad VISIBLE y los posibles valores
             *   son True o False.
             -----------------------------------------------------*/

            btnImprimir.Visible = false;

            /*------------------------------------------------------
             *  Creamos los objetos para la impresión.
             *----------------------------------------------------*/

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirForm1);
            pd.Print();

            btnImprimir.Visible = true; // Visualizamos nuevamente el objeto

            /*------------------------------------------------------
             *   Regreso al formulario principal
             *   después del dar aviso
             *-----------------------------------------------------*/

            MessageBox.Show("Operación exiatosa", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);



            // En lugar de crear una nueva instancia de frmPrincipal, mostramos el formulario original (Owner)
            if (this.Owner != null)
            {
                this.Owner.Show();  // Mostramos el formulario original
            }
            this.Close();  // Cerramos el formulario actual
        }

        /*----------------------------------------------------------
         *   Conjunto de sentencias necesarias para el objeto Print
         ----------------------------------------------------------*/

        private void ImprimirForm1(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int ancho = this.Width;
            int alto = this.Height;
            Rectangle bounds = new Rectangle(x, y, ancho, alto);
            Bitmap img = new Bitmap(ancho, alto);
            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            /*---------------------------------------------------
             *    Asignación de los valores a los datos que muestra
             *    cada etiqueta del diseño del comprobante de pago
             *----------------------------------------------------*/

            MontoPago = MathF.Round((Monto_f / CantCuotas_f),2);

            lblAlumno.Text = Alumno_f;
            lblActCuota.Text = Actividad_f;
            lblCostoAct.Text = Convert.ToString(CostoAct_f);
            lblMensual.Text = Convert.ToString(ValorCuota);
            lblTipoPago.Text = Forma_f;
            lblCantPagos.Text = Convert.ToString(CantCuotas_f);
            lblMontoPago.Text = Convert.ToString(MontoPago);
            lblMontoTotal.Text = Convert.ToString(Monto_f);
            lblDescuento.Text = (Forma_f == "Efectivo") ? Convert.ToString(DescuentoEfectivo) : "No Aplica" ;

            if (EsSocio_f == 1)
            {
                pnlActividad.Visible = false;
                lblSocio.Text = "Es Socio";
            }
            else
            {
                pnlCuotaMensual.Visible = false;
                lblSocio.Text = "No es Socio";
            }

            // Se obtiene la fecha actual
            lblDFecha.Text = DateTime.UtcNow.ToShortDateString();
        }
    }
}
