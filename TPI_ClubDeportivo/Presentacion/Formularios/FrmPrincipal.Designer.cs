namespace TPI_ClubDeportivo
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            lblUsuario = new Label();
            btnSalir = new Button();
            btnRegistrarCliente = new Button();
            btnIscribirActividad = new Button();
            btnListarActividades = new Button();
            btnEmitirCarnet = new Button();
            btnPagar = new Button();
            bntVisualizarVencimientos = new Button();
            panel1 = new Panel();
            lblIFTS29 = new Label();
            picLogo = new PictureBox();
            lblRol = new Label();
            pnlAutor = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlAutor.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Futura Md BT", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(385, 166);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(151, 41);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Gainsboro;
            btnSalir.Font = new Font("Futura Md BT", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.DimGray;
            btnSalir.Location = new Point(732, 29);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(140, 50);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.BackColor = Color.DarkGoldenrod;
            btnRegistrarCliente.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarCliente.ForeColor = Color.White;
            btnRegistrarCliente.Location = new Point(56, 247);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(350, 100);
            btnRegistrarCliente.TabIndex = 0;
            btnRegistrarCliente.Text = "Registrar Cliente";
            btnRegistrarCliente.UseVisualStyleBackColor = false;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnIscribirActividad
            // 
            btnIscribirActividad.BackColor = Color.DarkGoldenrod;
            btnIscribirActividad.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnIscribirActividad.ForeColor = Color.White;
            btnIscribirActividad.Location = new Point(483, 247);
            btnIscribirActividad.Name = "btnIscribirActividad";
            btnIscribirActividad.Size = new Size(350, 100);
            btnIscribirActividad.TabIndex = 1;
            btnIscribirActividad.Text = "Inscribir en Actividad";
            btnIscribirActividad.UseVisualStyleBackColor = false;
            btnIscribirActividad.Click += btnIscribirActividad_Click;
            // 
            // btnListarActividades
            // 
            btnListarActividades.BackColor = Color.DarkGoldenrod;
            btnListarActividades.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnListarActividades.ForeColor = Color.White;
            btnListarActividades.Location = new Point(56, 389);
            btnListarActividades.Name = "btnListarActividades";
            btnListarActividades.Size = new Size(350, 100);
            btnListarActividades.TabIndex = 2;
            btnListarActividades.Text = "Ver Actividades";
            btnListarActividades.UseVisualStyleBackColor = false;
            btnListarActividades.Click += btnListarActividades_Click;
            // 
            // btnEmitirCarnet
            // 
            btnEmitirCarnet.BackColor = Color.DarkGoldenrod;
            btnEmitirCarnet.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnEmitirCarnet.ForeColor = Color.White;
            btnEmitirCarnet.Location = new Point(483, 389);
            btnEmitirCarnet.Name = "btnEmitirCarnet";
            btnEmitirCarnet.Size = new Size(350, 100);
            btnEmitirCarnet.TabIndex = 3;
            btnEmitirCarnet.Text = "Emitir Carnet";
            btnEmitirCarnet.UseVisualStyleBackColor = false;
            btnEmitirCarnet.Click += btnEmitirCarnet_Click;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.DarkGoldenrod;
            btnPagar.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnPagar.ForeColor = Color.White;
            btnPagar.Location = new Point(56, 529);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(350, 100);
            btnPagar.TabIndex = 4;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // bntVisualizarVencimientos
            // 
            bntVisualizarVencimientos.BackColor = Color.DarkGoldenrod;
            bntVisualizarVencimientos.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            bntVisualizarVencimientos.ForeColor = Color.White;
            bntVisualizarVencimientos.Location = new Point(483, 529);
            bntVisualizarVencimientos.Name = "bntVisualizarVencimientos";
            bntVisualizarVencimientos.Size = new Size(350, 100);
            bntVisualizarVencimientos.TabIndex = 5;
            bntVisualizarVencimientos.Text = "Cuotas que Vencen Hoy";
            bntVisualizarVencimientos.UseVisualStyleBackColor = false;
            bntVisualizarVencimientos.Click += bntVisualizarVencimientos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(lblIFTS29);
            panel1.Controls.Add(btnSalir);
            panel1.Location = new Point(-4, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 110);
            panel1.TabIndex = 8;
            // 
            // lblIFTS29
            // 
            lblIFTS29.AutoSize = true;
            lblIFTS29.Font = new Font("Century", 26F, FontStyle.Bold, GraphicsUnit.Point);
            lblIFTS29.ForeColor = Color.FromArgb(64, 64, 64);
            lblIFTS29.Location = new Point(284, 25);
            lblIFTS29.Name = "lblIFTS29";
            lblIFTS29.Size = new Size(354, 54);
            lblIFTS29.TabIndex = 11;
            lblIFTS29.Text = "Menú Principal";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(32, 33);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Futura Md BT", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblRol.Location = new Point(294, 122);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(322, 41);
            lblRol.TabIndex = 10;
            lblRol.Text = "* Administrador *";
            lblRol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAutor
            // 
            pnlAutor.BackColor = Color.LightSkyBlue;
            pnlAutor.Controls.Add(label2);
            pnlAutor.Location = new Point(-4, 676);
            pnlAutor.Name = "pnlAutor";
            pnlAutor.Size = new Size(900, 33);
            pnlAutor.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Futura Md BT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(8, 6);
            label2.Name = "label2";
            label2.Size = new Size(301, 22);
            label2.TabIndex = 10;
            label2.Text = "ComC_G7  Mendiola - Rodrigues";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(892, 708);
            Controls.Add(pnlAutor);
            Controls.Add(lblRol);
            Controls.Add(picLogo);
            Controls.Add(panel1);
            Controls.Add(lblUsuario);
            Controls.Add(bntVisualizarVencimientos);
            Controls.Add(btnPagar);
            Controls.Add(btnEmitirCarnet);
            Controls.Add(btnListarActividades);
            Controls.Add(btnIscribirActividad);
            Controls.Add(btnRegistrarCliente);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VENTANA PRINCIPAL";
            Load += FrmPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlAutor.ResumeLayout(false);
            pnlAutor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Button btnSalir;
        private Button btnRegistrarCliente;
        private Button btnIscribirActividad;
        private Button btnListarActividades;
        private Button btnEmitirCarnet;
        private Button btnPagar;
        private Button bntVisualizarVencimientos;
        private Panel panel1;
        private PictureBox picLogo;
        private Label lblRol;
        private Label lblIFTS29;
        private Panel pnlAutor;
        private Label label2;
    }
}