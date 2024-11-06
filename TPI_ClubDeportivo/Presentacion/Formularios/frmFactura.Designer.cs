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
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            btnImprimir = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pnlNombreInstitudo = new Panel();
            pnlDatosInstituto = new Panel();
            label5 = new Label();
            label4 = new Label();
            lblDFecha = new Label();
            pnlDatos = new Panel();
            pnlCuotaMensual = new Panel();
            lblMensual = new Label();
            label9 = new Label();
            pnlActividad = new Panel();
            lblCA = new Label();
            lblCostoAct = new Label();
            lblActSoc = new Label();
            lblActCuota = new Label();
            lblDescuento = new Label();
            label6 = new Label();
            lblCantPagos = new Label();
            label8 = new Label();
            lblMontoPago = new Label();
            label3 = new Label();
            lblSocio = new Label();
            lblMontoTotal = new Label();
            label13 = new Label();
            lblTipoPago = new Label();
            label11 = new Label();
            lblAlumno = new Label();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlNombreInstitudo.SuspendLayout();
            pnlDatosInstituto.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlCuotaMensual.SuspendLayout();
            pnlActividad.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.Beige;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Location = new Point(12, 19);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(776, 78);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(234, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(343, 37);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "COMPROBANTE DE PAGO";
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(612, 572);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(169, 50);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(7, 12);
            label1.Name = "label1";
            label1.Size = new Size(270, 32);
            label1.TabIndex = 2;
            label1.Text = "INSTITUTO TERCIARIO";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(281, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 112);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pnlNombreInstitudo
            // 
            pnlNombreInstitudo.BackColor = Color.OldLace;
            pnlNombreInstitudo.Controls.Add(label1);
            pnlNombreInstitudo.Controls.Add(pictureBox1);
            pnlNombreInstitudo.Location = new Point(12, 113);
            pnlNombreInstitudo.Name = "pnlNombreInstitudo";
            pnlNombreInstitudo.Size = new Size(384, 112);
            pnlNombreInstitudo.TabIndex = 1;
            // 
            // pnlDatosInstituto
            // 
            pnlDatosInstituto.BackColor = Color.OldLace;
            pnlDatosInstituto.Controls.Add(label5);
            pnlDatosInstituto.Controls.Add(label4);
            pnlDatosInstituto.Controls.Add(lblDFecha);
            pnlDatosInstituto.Location = new Point(404, 113);
            pnlDatosInstituto.Name = "pnlDatosInstituto";
            pnlDatosInstituto.Size = new Size(384, 112);
            pnlDatosInstituto.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(7, 64);
            label5.Name = "label5";
            label5.Size = new Size(370, 23);
            label5.TabIndex = 6;
            label5.Text = "DATOS GENERALES DEL INSTITUTO TÉCNICO";
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
            pnlDatos.BackColor = Color.Beige;
            pnlDatos.Controls.Add(pnlCuotaMensual);
            pnlDatos.Controls.Add(pnlActividad);
            pnlDatos.Controls.Add(lblDescuento);
            pnlDatos.Controls.Add(label6);
            pnlDatos.Controls.Add(lblCantPagos);
            pnlDatos.Controls.Add(label8);
            pnlDatos.Controls.Add(lblMontoPago);
            pnlDatos.Controls.Add(label3);
            pnlDatos.Controls.Add(lblSocio);
            pnlDatos.Controls.Add(lblMontoTotal);
            pnlDatos.Controls.Add(label13);
            pnlDatos.Controls.Add(lblTipoPago);
            pnlDatos.Controls.Add(label11);
            pnlDatos.Controls.Add(lblAlumno);
            pnlDatos.Location = new Point(12, 242);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(776, 312);
            pnlDatos.TabIndex = 1;
            // 
            // pnlCuotaMensual
            // 
            pnlCuotaMensual.Controls.Add(lblMensual);
            pnlCuotaMensual.Controls.Add(label9);
            pnlCuotaMensual.Location = new Point(22, 121);
            pnlCuotaMensual.Name = "pnlCuotaMensual";
            pnlCuotaMensual.Size = new Size(295, 48);
            pnlCuotaMensual.TabIndex = 26;
            // 
            // lblMensual
            // 
            lblMensual.AutoSize = true;
            lblMensual.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblMensual.Location = new Point(167, 9);
            lblMensual.Name = "lblMensual";
            lblMensual.Size = new Size(85, 35);
            lblMensual.TabIndex = 24;
            lblMensual.Text = "11111";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(8, 10);
            label9.Name = "label9";
            label9.Size = new Size(164, 30);
            label9.TabIndex = 8;
            label9.Text = "Valor Cuota:  $";
            // 
            // pnlActividad
            // 
            pnlActividad.Controls.Add(lblCA);
            pnlActividad.Controls.Add(lblCostoAct);
            pnlActividad.Controls.Add(lblActSoc);
            pnlActividad.Controls.Add(lblActCuota);
            pnlActividad.Location = new Point(23, 121);
            pnlActividad.Name = "pnlActividad";
            pnlActividad.Size = new Size(295, 87);
            pnlActividad.TabIndex = 25;
            // 
            // lblCA
            // 
            lblCA.AutoSize = true;
            lblCA.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblCA.Location = new Point(8, 48);
            lblCA.Name = "lblCA";
            lblCA.Size = new Size(171, 30);
            lblCA.TabIndex = 23;
            lblCA.Text = "Costo Diario:  $";
            // 
            // lblCostoAct
            // 
            lblCostoAct.AutoSize = true;
            lblCostoAct.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblCostoAct.Location = new Point(172, 45);
            lblCostoAct.Name = "lblCostoAct";
            lblCostoAct.Size = new Size(85, 35);
            lblCostoAct.TabIndex = 24;
            lblCostoAct.Text = "11111";
            // 
            // lblActSoc
            // 
            lblActSoc.AutoSize = true;
            lblActSoc.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblActSoc.Location = new Point(35, 10);
            lblActSoc.Name = "lblActSoc";
            lblActSoc.Size = new Size(118, 30);
            lblActSoc.TabIndex = 8;
            lblActSoc.Text = "Actividad:";
            // 
            // lblActCuota
            // 
            lblActCuota.AutoSize = true;
            lblActCuota.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblActCuota.Location = new Point(150, 8);
            lblActCuota.Name = "lblActCuota";
            lblActCuota.Size = new Size(126, 35);
            lblActCuota.TabIndex = 9;
            lblActCuota.Text = "Actividad";
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblDescuento.Location = new Point(601, 170);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(29, 35);
            lblDescuento.TabIndex = 22;
            lblDescuento.Text = "1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(479, 173);
            label6.Name = "label6";
            label6.Size = new Size(128, 30);
            label6.TabIndex = 21;
            label6.Text = "Descuento:";
            // 
            // lblCantPagos
            // 
            lblCantPagos.AutoSize = true;
            lblCantPagos.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantPagos.Location = new Point(601, 136);
            lblCantPagos.Name = "lblCantPagos";
            lblCantPagos.Size = new Size(29, 35);
            lblCantPagos.TabIndex = 20;
            lblCantPagos.Text = "1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(463, 136);
            label8.Name = "label8";
            label8.Size = new Size(141, 30);
            label8.TabIndex = 19;
            label8.Text = "Cant. Pagos:";
            // 
            // lblMontoPago
            // 
            lblMontoPago.AutoSize = true;
            lblMontoPago.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoPago.Location = new Point(626, 207);
            lblMontoPago.Name = "lblMontoPago";
            lblMontoPago.Size = new Size(85, 35);
            lblMontoPago.TabIndex = 18;
            lblMontoPago.Text = "11111";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(463, 210);
            label3.Name = "label3";
            label3.Size = new Size(171, 30);
            label3.TabIndex = 17;
            label3.Text = "Monto Pago:  $";
            // 
            // lblSocio
            // 
            lblSocio.AutoSize = true;
            lblSocio.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblSocio.Location = new Point(38, 75);
            lblSocio.Name = "lblSocio";
            lblSocio.Size = new Size(76, 35);
            lblSocio.TabIndex = 16;
            lblSocio.Text = "Socio";
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoTotal.Location = new Point(626, 245);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(85, 35);
            lblMontoTotal.TabIndex = 15;
            lblMontoTotal.Text = "11111";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(463, 248);
            label13.Name = "label13";
            label13.Size = new Size(170, 30);
            label13.TabIndex = 14;
            label13.Text = "Monto Total:  $";
            // 
            // lblTipoPago
            // 
            lblTipoPago.AutoSize = true;
            lblTipoPago.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipoPago.Location = new Point(640, 94);
            lblTipoPago.Name = "lblTipoPago";
            lblTipoPago.Size = new Size(111, 35);
            lblTipoPago.TabIndex = 13;
            lblTipoPago.Text = "efectivo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(463, 97);
            label11.Name = "label11";
            label11.Size = new Size(174, 30);
            label11.TabIndex = 12;
            label11.Text = "Forma de Pago:";
            // 
            // lblAlumno
            // 
            lblAlumno.AutoSize = true;
            lblAlumno.Font = new Font("Segoe UI", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblAlumno.Location = new Point(37, 28);
            lblAlumno.Name = "lblAlumno";
            lblAlumno.Size = new Size(110, 35);
            lblAlumno.TabIndex = 7;
            lblAlumno.Text = "Nombre";
            // 
            // frmFactura
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 644);
            Controls.Add(pnlDatos);
            Controls.Add(pnlDatosInstituto);
            Controls.Add(pnlNombreInstitudo);
            Controls.Add(btnImprimir);
            Controls.Add(pnlTitulo);
            Name = "frmFactura";
            Text = "frmFactura";
            Load += frmFactura_Load;
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlNombreInstitudo.ResumeLayout(false);
            pnlNombreInstitudo.PerformLayout();
            pnlDatosInstituto.ResumeLayout(false);
            pnlDatosInstituto.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlCuotaMensual.ResumeLayout(false);
            pnlCuotaMensual.PerformLayout();
            pnlActividad.ResumeLayout(false);
            pnlActividad.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTitulo;
        private Button btnImprimir;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel pnlNombreInstitudo;
        private Panel pnlDatosInstituto;
        private Panel pnlDatos;
        private Label lblTitulo;
        private Label label5;
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
        private Label lblMontoPago;
        private Label label3;
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
    }
}