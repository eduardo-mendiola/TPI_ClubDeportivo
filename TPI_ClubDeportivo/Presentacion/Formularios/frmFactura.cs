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
using TPI_ClubDeportivo.Entidades;

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
        public double? CostoAct_f;
        public string? TipoPago_f;
        public double Monto_f;
        public int? Numero_f;
        public int? EsSocio_f;
        public string? Forma_f;
        public int CantCuotas_f;
        private double MontoPago;
        public double DescuentoEfectivo = 0.90;
        public double ValorCuota;
        private static int contadorComprobante = 1;

        public void SetValorCuota()
        {
            E_Cuota cuota = new E_Cuota();
            this.ValorCuota = cuota.ValorCuota;
        }

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



            // Mostrar frmPagar y cerrar frmFactura
            if (this.Owner != null)
            {
                this.Owner.Show();  // Mostramos frmPagar
            }
            this.Close();  // Cerramos frmFactura
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
            SetValorCuota();
            MontoPago = Math.Round((Monto_f / CantCuotas_f), 2);

            lblAlumno.Text = Alumno_f;
            lblActCuota.Text = Actividad_f;
            lblCostoAct.Text = Convert.ToString(CostoAct_f);
            lblMensual.Text = Convert.ToString(ValorCuota);
            lblTipoPago.Text = Forma_f;
            lblCantPagos.Text = Convert.ToString(CantCuotas_f);
            lblMontoPago.Text = Convert.ToString(MontoPago);
            lblMontoTotal.Text = Convert.ToString(Monto_f);
            lblDescuento.Text = (Forma_f == "Efectivo") ? Convert.ToString(DescuentoEfectivo) : "No Aplica";
            GenerarNumeroComprobante(lblNumComp);
                  
            if (EsSocio_f == 1)
            {
                pnlCuotaMensual.Visible = true;
                pnlActividad.Visible = false;
                lblSocio.Text = "Es Socio";
            }
            else
            {
                pnlActividad.Visible = true;
                pnlCuotaMensual.Visible = false;
                lblSocio.Text = "No es Socio";
            }

            // Se obtiene la fecha actual
            lblDFecha.Text = DateTime.UtcNow.ToShortDateString();
        }
              
        private void GenerarNumeroComprobante(Label label)
        {
            string numeroComprobante = contadorComprobante.ToString("D7"); // "D7" asegura que haya 7 dígitos
          
            label.Text = numeroComprobante;
         
            contadorComprobante++;
        }

    }
}
