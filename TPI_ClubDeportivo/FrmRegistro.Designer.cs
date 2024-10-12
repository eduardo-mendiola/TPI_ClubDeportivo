namespace TPI_ClubDeportivo
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            lblNombre = new Label();
            lblDocumento = new Label();
            lblApellido = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDocumento = new TextBox();
            btnIngresar = new Button();
            btnLimpiar = new Button();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblFechaNacimiento = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtDomicilio = new TextBox();
            lblDomicilio = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            picLogo = new PictureBox();
            panel1 = new Panel();
            lblIFTS29 = new Label();
            btnVolver = new Button();
            label8 = new Label();
            label9 = new Label();
            radSocio = new RadioButton();
            radNoSocio = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombre.Location = new Point(21, 248);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(111, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDocumento.Location = new Point(457, 354);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(139, 29);
            lblDocumento.TabIndex = 1;
            lblDocumento.Text = "Documento";
            lblDocumento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblApellido
            // 
            lblApellido.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblApellido.Location = new Point(457, 248);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(111, 25);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(21, 288);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 40);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(457, 288);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(400, 40);
            txtApellido.TabIndex = 3;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtDocumento.Location = new Point(457, 399);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(400, 40);
            txtDocumento.TabIndex = 5;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.DodgerBlue;
            btnIngresar.Font = new Font("Futura Md BT", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(495, 716);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 70);
            btnIngresar.TabIndex = 10;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Font = new Font("Futura Md BT", 15F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(67, 716);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(320, 70);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.Location = new Point(21, 354);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(59, 29);
            lblTipo.TabIndex = 8;
            lblTipo.Text = "Tipo";
            lblTipo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboTipo
            // 
            cboTipo.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "DNI", "PASAPORTE", "EXTRANJERO" });
            cboTipo.Location = new Point(21, 392);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(200, 40);
            cboTipo.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.Location = new Point(457, 572);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(111, 25);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(457, 609);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 40);
            txtEmail.TabIndex = 9;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblFechaNacimiento.Location = new Point(21, 460);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(250, 25);
            lblFechaNacimiento.TabIndex = 15;
            lblFechaNacimiento.Text = "Fecha de nacimiento";
            lblFechaNacimiento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(457, 498);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(400, 40);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.Location = new Point(457, 460);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(111, 25);
            lblTelefono.TabIndex = 17;
            lblTelefono.Text = "Teléfono";
            lblTelefono.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDomicilio
            // 
            txtDomicilio.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtDomicilio.Location = new Point(21, 609);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(400, 40);
            txtDomicilio.TabIndex = 8;
            // 
            // lblDomicilio
            // 
            lblDomicilio.Font = new Font("Futura Md BT", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDomicilio.Location = new Point(21, 572);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(111, 25);
            lblDomicilio.TabIndex = 19;
            lblDomicilio.Text = "Domicilio";
            lblDomicilio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Font = new Font("Futura Md BT", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(21, 498);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.RightToLeft = RightToLeft.No;
            dtpFechaNacimiento.Size = new Size(238, 39);
            dtpFechaNacimiento.TabIndex = 6;
            dtpFechaNacimiento.Value = new DateTime(2024, 10, 11, 22, 54, 53, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(858, 293);
            label1.Name = "label1";
            label1.Size = new Size(33, 41);
            label1.TabIndex = 22;
            label1.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(226, 395);
            label2.Name = "label2";
            label2.Size = new Size(33, 41);
            label2.TabIndex = 23;
            label2.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(424, 291);
            label3.Name = "label3";
            label3.Size = new Size(33, 41);
            label3.TabIndex = 24;
            label3.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(857, 399);
            label4.Name = "label4";
            label4.Size = new Size(33, 41);
            label4.TabIndex = 25;
            label4.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(424, 609);
            label6.Name = "label6";
            label6.Size = new Size(33, 41);
            label6.TabIndex = 27;
            label6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(860, 609);
            label7.Name = "label7";
            label7.Size = new Size(33, 41);
            label7.TabIndex = 28;
            label7.Text = "*";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(33, 33);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 30;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(lblIFTS29);
            panel1.Controls.Add(btnVolver);
            panel1.Location = new Point(-3, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 110);
            panel1.TabIndex = 29;
            // 
            // lblIFTS29
            // 
            lblIFTS29.AutoSize = true;
            lblIFTS29.Font = new Font("Century", 26F, FontStyle.Bold, GraphicsUnit.Point);
            lblIFTS29.ForeColor = Color.FromArgb(64, 64, 64);
            lblIFTS29.Location = new Point(232, 25);
            lblIFTS29.Name = "lblIFTS29";
            lblIFTS29.Size = new Size(453, 54);
            lblIFTS29.TabIndex = 11;
            lblIFTS29.Text = "Registro de Clientes";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Gainsboro;
            btnVolver.Font = new Font("Futura Md BT", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnVolver.ForeColor = Color.DimGray;
            btnVolver.Location = new Point(732, 29);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(140, 50);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Futura Md BT", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(859, 498);
            label8.Name = "label8";
            label8.Size = new Size(33, 41);
            label8.TabIndex = 31;
            label8.Text = "*";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Futura Md BT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(333, 139);
            label9.Name = "label9";
            label9.Size = new Size(235, 36);
            label9.TabIndex = 34;
            label9.Text = "Tipo de Registro";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radSocio
            // 
            radSocio.AutoSize = true;
            radSocio.Checked = true;
            radSocio.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            radSocio.Location = new Point(333, 187);
            radSocio.Name = "radSocio";
            radSocio.Size = new Size(103, 38);
            radSocio.TabIndex = 0;
            radSocio.TabStop = true;
            radSocio.Text = "Socio";
            radSocio.UseVisualStyleBackColor = true;
            // 
            // radNoSocio
            // 
            radNoSocio.AutoSize = true;
            radNoSocio.Font = new Font("Futura Md BT", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            radNoSocio.Location = new Point(457, 187);
            radNoSocio.Name = "radNoSocio";
            radNoSocio.Size = new Size(149, 38);
            radNoSocio.TabIndex = 1;
            radNoSocio.TabStop = true;
            radNoSocio.Text = "No Socio";
            radNoSocio.UseVisualStyleBackColor = true;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(892, 823);
            Controls.Add(radNoSocio);
            Controls.Add(radSocio);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(picLogo);
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtDomicilio);
            Controls.Add(lblDomicilio);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(cboTipo);
            Controls.Add(lblTipo);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(txtDocumento);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(lblDocumento);
            Controls.Add(lblNombre);
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "REGISTRO DE CLIENTES";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label lblNombre;
        private Label lblDocumento;
        private Label lblApellido;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDocumento;
        private Button btnIngresar;
        private Button btnLimpiar;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Button btnVolver;
        private Label label8;
        private Label label9;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFechaNacimiento;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtDomicilio;
        private Label lblDomicilio;
        private DateTimePicker dtpFechaNacimiento;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private PictureBox picLogo;
        private Panel panel1;
        private Label lblIFTS29;
        private RadioButton radSocio;
        private RadioButton radNoSocio;
    }
}