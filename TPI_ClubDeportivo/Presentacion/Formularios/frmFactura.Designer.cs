using System.Windows.Forms;

namespace TPI_ClubDeportivo
{
    partial class frmFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFactura));
            pnlTitulo = new Panel();
            label1 = new Label();
            picLogo = new PictureBox();
            lblTitulo = new Label();
            btnImprimir = new Button();
            pnlDatosInstituto = new Panel();
            label5 = new Label();
            lblNumComp = new Label();
            label4 = new Label();
            lblDFecha = new Label();
            pnlDatos = new Panel();
            pnlCuotaMensual = new Panel();
            lblMensual = new Label();
            label9 = new Label();
            label3 = new Label();
            lblMontoPago = new Label();
            label2 = new Label();
            lblDescuento = new Label();
            lblAlumno = new Label();
            pnlActividad = new Panel();
            lblCA = new Label();
            lblCostoAct = new Label();
            lblActSoc = new Label();
            lblActCuota = new Label();
            label6 = new Label();
            lblCantPagos = new Label();
            label8 = new Label();
            lblSocio = new Label();
            lblMontoTotal = new Label();
            label13 = new Label();
            lblTipoPago = new Label();
            label11 = new Label();
            btnSalirFact = new Button();
            pnlAutor = new Panel();
            label7 = new Label();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlDatosInstituto.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlCuotaMensual.SuspendLayout();
            pnlActividad.SuspendLayout();
            pnlAutor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.Lavender;
            pnlTitulo.Controls.Add(label1);
            pnlTitulo.Controls.Add(picLogo);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Location = new Point(12, 19);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(776, 248);
            pnlTitulo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(170, 135);
            label1.Name = "label1";
            label1.Size = new Size(223, 32);
            label1.TabIndex = 2;
            label1.Text = "CLUB DEPORTIVO ";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(14, 17);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 35;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(3, 187);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(434, 46);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "COMPROBANTE DE PAGO";
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.DodgerBlue;
            btnImprimir.Font = new Font("Futura Md BT", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(478, 705);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(234, 70);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // pnlDatosInstituto
            // 
            pnlDatosInstituto.BackColor = Color.White;
            pnlDatosInstituto.Controls.Add(label5);
            pnlDatosInstituto.Controls.Add(lblNumComp);
            pnlDatosInstituto.Controls.Add(label4);
            pnlDatosInstituto.Controls.Add(lblDFecha);
            pnlDatosInstituto.Location = new Point(12, 279);
            pnlDatosInstituto.Name = "pnlDatosInstituto";
            pnlDatosInstituto.Size = new Size(776, 91);
            pnlDatosInstituto.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(398, 13);
            label5.Name = "label5";
            label5.Size = new Size(224, 30);
            label5.TabIndex = 7;
            label5.Text = "Num. Comprobante:";
            // 
            // lblNumComp
            // 
            lblNumComp.AutoSize = true;
            lblNumComp.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumComp.Location = new Point(622, 15);
            lblNumComp.Name = "lblNumComp";
            lblNumComp.Size = new Size(104, 30);
            lblNumComp.TabIndex = 6;
            lblNumComp.Text = "0000000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 13);
            label4.Name = "label4";
            label4.Size = new Size(74, 30);
            label4.TabIndex = 5;
            label4.Text = "Fecha:";
            // 
            // lblDFecha
            // 
            lblDFecha.AutoSize = true;
            lblDFecha.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblDFecha.Location = new Point(82, 14);
            lblDFecha.Name = "lblDFecha";
            lblDFecha.Size = new Size(127, 30);
            lblDFecha.TabIndex = 4;
            lblDFecha.Text = "00/00/0000";
            // 
            // pnlDatos
            // 
            pnlDatos.BackColor = Color.White;
            pnlDatos.Controls.Add(pnlCuotaMensual);
            pnlDatos.Controls.Add(label3);
            pnlDatos.Controls.Add(lblMontoPago);
            pnlDatos.Controls.Add(label2);
            pnlDatos.Controls.Add(lblDescuento);
            pnlDatos.Controls.Add(lblAlumno);
            pnlDatos.Controls.Add(pnlActividad);
            pnlDatos.Controls.Add(label6);
            pnlDatos.Controls.Add(lblCantPagos);
            pnlDatos.Controls.Add(label8);
            pnlDatos.Controls.Add(lblSocio);
            pnlDatos.Controls.Add(lblMontoTotal);
            pnlDatos.Controls.Add(label13);
            pnlDatos.Controls.Add(lblTipoPago);
            pnlDatos.Controls.Add(label11);
            pnlDatos.Location = new Point(12, 381);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(776, 312);
            pnlDatos.TabIndex = 1;
            // 
            // pnlCuotaMensual
            // 
            pnlCuotaMensual.Controls.Add(lblMensual);
            pnlCuotaMensual.Controls.Add(label9);
            pnlCuotaMensual.Location = new Point(368, 70);
            pnlCuotaMensual.Name = "pnlCuotaMensual";
            pnlCuotaMensual.Size = new Size(364, 48);
            pnlCuotaMensual.TabIndex = 26;
            // 
            // lblMensual
            // 
            lblMensual.AutoSize = true;
            lblMensual.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensual.Location = new Point(194, 9);
            lblMensual.Name = "lblMensual";
            lblMensual.Size = new Size(97, 37);
            lblMensual.TabIndex = 24;
            lblMensual.Text = "11111";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(8, 10);
            label9.Name = "label9";
            label9.Size = new Size(182, 32);
            label9.TabIndex = 8;
            label9.Text = "Valor Cuota:  $";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(491, 259);
            label3.Name = "label3";
            label3.Size = new Size(128, 30);
            label3.TabIndex = 27;
            label3.Text = "Pago de:  $";
            // 
            // lblMontoPago
            // 
            lblMontoPago.AutoSize = true;
            lblMontoPago.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoPago.Location = new Point(615, 256);
            lblMontoPago.Name = "lblMontoPago";
            lblMontoPago.Size = new Size(85, 35);
            lblMontoPago.TabIndex = 28;
            lblMontoPago.Text = "11111";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(47, 159);
            label2.Name = "label2";
            label2.Size = new Size(49, 57);
            label2.TabIndex = 23;
            label2.Text = "$";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescuento.Location = new Point(588, 192);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(29, 35);
            lblDescuento.TabIndex = 22;
            lblDescuento.Text = "1";
            // 
            // lblAlumno
            // 
            lblAlumno.AutoSize = true;
            lblAlumno.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblAlumno.Location = new Point(33, 20);
            lblAlumno.Name = "lblAlumno";
            lblAlumno.Size = new Size(132, 41);
            lblAlumno.TabIndex = 7;
            lblAlumno.Text = "Nombre";
            // 
            // pnlActividad
            // 
            pnlActividad.Controls.Add(lblCA);
            pnlActividad.Controls.Add(lblCostoAct);
            pnlActividad.Controls.Add(lblActSoc);
            pnlActividad.Controls.Add(lblActCuota);
            pnlActividad.Location = new Point(372, 54);
            pnlActividad.Name = "pnlActividad";
            pnlActividad.Size = new Size(364, 87);
            pnlActividad.TabIndex = 25;
            // 
            // lblCA
            // 
            lblCA.AutoSize = true;
            lblCA.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCA.Location = new Point(7, 48);
            lblCA.Name = "lblCA";
            lblCA.Size = new Size(191, 32);
            lblCA.TabIndex = 23;
            lblCA.Text = "Costo Diario:  $";
            // 
            // lblCostoAct
            // 
            lblCostoAct.AutoSize = true;
            lblCostoAct.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblCostoAct.Location = new Point(193, 45);
            lblCostoAct.Name = "lblCostoAct";
            lblCostoAct.Size = new Size(97, 37);
            lblCostoAct.TabIndex = 24;
            lblCostoAct.Text = "11111";
            // 
            // lblActSoc
            // 
            lblActSoc.AutoSize = true;
            lblActSoc.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblActSoc.Location = new Point(41, 10);
            lblActSoc.Name = "lblActSoc";
            lblActSoc.Size = new Size(129, 32);
            lblActSoc.TabIndex = 8;
            lblActSoc.Text = "Actividad:";
            // 
            // lblActCuota
            // 
            lblActCuota.AutoSize = true;
            lblActCuota.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblActCuota.Location = new Point(169, 8);
            lblActCuota.Name = "lblActCuota";
            lblActCuota.Size = new Size(140, 37);
            lblActCuota.TabIndex = 9;
            lblActCuota.Text = "Actividad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(466, 195);
            label6.Name = "label6";
            label6.Size = new Size(134, 30);
            label6.TabIndex = 21;
            label6.Text = "Descuento: ";
            // 
            // lblCantPagos
            // 
            lblCantPagos.AutoSize = true;
            lblCantPagos.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantPagos.Location = new Point(591, 228);
            lblCantPagos.Name = "lblCantPagos";
            lblCantPagos.Size = new Size(29, 35);
            lblCantPagos.TabIndex = 20;
            lblCantPagos.Text = "1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(453, 228);
            label8.Name = "label8";
            label8.Size = new Size(141, 30);
            label8.TabIndex = 19;
            label8.Text = "Cant. Pagos:";
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblSocio.Location = new Point(33, 69);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(76, 35);
            lblSocio.TabIndex = 16;
            lblSocio.Text = "Socio";
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoTotal.Location = new Point(93, 161);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(145, 57);
            lblMontoTotal.TabIndex = 15;
            lblMontoTotal.Text = "11111";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(34, 127);
            label13.Name = "label13";
            label13.Size = new Size(64, 30);
            label13.TabIndex = 14;
            label13.Text = "Total";
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipoPago.Location = new Point(597, 161);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(111, 35);
            lblTipoPago.TabIndex = 13;
            lblTipoPago.Text = "efectivo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(420, 164);
            label11.Name = "label11";
            label11.Size = new Size(174, 30);
            label11.TabIndex = 12;
            label11.Text = "Forma de Pago:";
            // 
            // btnSalirFact
            // 
            btnSalirFact.BackColor = Color.DarkGray;
            btnSalirFact.Font = new Font("Futura Md BT", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalirFact.ForeColor = Color.White;
            btnSalirFact.Location = new Point(94, 705);
            btnSalirFact.Name = "btnSalirFact";
            btnSalirFact.Size = new Size(234, 70);
            btnSalirFact.TabIndex = 1;
            btnSalirFact.Text = "SALIR";
            btnSalirFact.UseVisualStyleBackColor = false;
            btnSalirFact.Click += btnSalirFact_Click;
            // 
            // pnlAutor
            // 
            pnlAutor.BackColor = Color.LightSkyBlue;
            pnlAutor.Controls.Add(label7);
            pnlAutor.Location = new Point(-1, 811);
            pnlAutor.Name = "pnlAutor";
            pnlAutor.Size = new Size(801, 33);
            pnlAutor.TabIndex = 37;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Futura Md BT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(8, 6);
            label7.Name = "label7";
            label7.Size = new Size(301, 22);
            label7.TabIndex = 10;
            label7.Text = "ComC_G7  Mendiola - Rodrigues";
            // 
            // frmFactura
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 843);
            Controls.Add(pnlAutor);
            Controls.Add(btnSalirFact);
            Controls.Add(pnlDatos);
            Controls.Add(pnlDatosInstituto);
            Controls.Add(btnImprimir);
            Controls.Add(pnlTitulo);
            Name = "frmFactura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmFactura";
            Load += frmFactura_Load;
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlDatosInstituto.ResumeLayout(false);
            pnlDatosInstituto.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlCuotaMensual.ResumeLayout(false);
            pnlCuotaMensual.PerformLayout();
            pnlActividad.ResumeLayout(false);
            pnlActividad.PerformLayout();
            pnlAutor.ResumeLayout(false);
            pnlAutor.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTitulo;
        private Button btnImprimir;
        private Label label1;
        private Panel pnlDatosInstituto;
        private Panel pnlDatos;
        private Label lblTitulo;
        private Label lblNumComp;
        private Label label4;
        private Label lblDFecha;
        private Label lblMontoTotal;
        private Label label13;
        private Label lblTipoPago;
        private Label label11;
        private Label lblActCuota;
        private Label lblActSoc;
        private Label lblAlumno;

        #endregion

        private Label lblSocio;
        private Label lblCantPagos;
        private Label label8;
        private Label lblDescuento;
        private Label label6;
        private Label lblCostoAct;
        private Label lblCA;
        private Panel pnlActividad;
        private Panel pnlCuotaMensual;
        private Label label2;
        private Label lblMensual;
        private Label label9;
        private Label label10;
        private PictureBox picLogo;
        private Label label3;
        private Label lblMontoPago;
        private Label label5;
        private Button btnSalirFact;
        private Panel pnlAutor;
        private Label label7;
    }
}