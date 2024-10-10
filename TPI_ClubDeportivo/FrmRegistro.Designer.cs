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
            picRegistro = new PictureBox();
            lblInscripcion = new Label();
            btnVolver = new Button();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblFechaNacimiento = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtDomicilio = new TextBox();
            lblDomicilio = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)picRegistro).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(436, 123);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(111, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDocumento.Location = new Point(655, 272);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(122, 24);
            lblDocumento.TabIndex = 1;
            lblDocumento.Text = "Documento";
            // 
            // lblApellido
            // 
            lblApellido.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.Location = new Point(436, 197);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(111, 25);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            lblApellido.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(555, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(448, 36);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(555, 194);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(448, 36);
            txtApellido.TabIndex = 4;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtDocumento.Location = new Point(783, 268);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(220, 33);
            txtDocumento.TabIndex = 5;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.White;
            btnIngresar.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.Location = new Point(394, 651);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(170, 52);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.Location = new Point(620, 651);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(170, 52);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipo.Location = new Point(449, 271);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(52, 24);
            lblTipo.TabIndex = 8;
            lblTipo.Text = "Tipo";
            // 
            // cboTipo
            // 
            cboTipo.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "DNI", "PASAPORTE", "EXTRANJERO" });
            cboTipo.Location = new Point(519, 268);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(114, 34);
            cboTipo.TabIndex = 9;
            // 
            // picRegistro
            // 
            picRegistro.ErrorImage = null;
            picRegistro.Image = (Image)resources.GetObject("picRegistro.Image");
            picRegistro.InitialImage = null;
            picRegistro.Location = new Point(0, 2);
            picRegistro.Name = "picRegistro";
            picRegistro.Size = new Size(372, 746);
            picRegistro.SizeMode = PictureBoxSizeMode.StretchImage;
            picRegistro.TabIndex = 10;
            picRegistro.TabStop = false;
            // 
            // lblInscripcion
            // 
            lblInscripcion.AutoSize = true;
            lblInscripcion.Font = new Font("Futura Md BT", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblInscripcion.ForeColor = Color.Peru;
            lblInscripcion.Location = new Point(548, 38);
            lblInscripcion.Name = "lblInscripcion";
            lblInscripcion.Size = new Size(327, 32);
            lblInscripcion.TabIndex = 11;
            lblInscripcion.Text = "REGISTRO DE CLIENTES";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVolver.Location = new Point(838, 651);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(170, 52);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmail.Location = new Point(443, 566);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(111, 25);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(562, 561);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(448, 33);
            txtEmail.TabIndex = 14;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblFechaNacimiento.Location = new Point(443, 344);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(230, 25);
            lblFechaNacimiento.TabIndex = 15;
            lblFechaNacimiento.Text = "Fecha de nacimiento";
            lblFechaNacimiento.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(562, 413);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(448, 33);
            txtTelefono.TabIndex = 18;
            // 
            // lblTelefono
            // 
            lblTelefono.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefono.Location = new Point(443, 418);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(111, 25);
            lblTelefono.TabIndex = 17;
            lblTelefono.Text = "Teléfono";
            lblTelefono.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDomicilio
            // 
            txtDomicilio.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtDomicilio.Location = new Point(562, 487);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(448, 33);
            txtDomicilio.TabIndex = 20;
            // 
            // lblDomicilio
            // 
            lblDomicilio.Font = new Font("Futura Md BT", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDomicilio.Location = new Point(443, 492);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(111, 25);
            lblDomicilio.TabIndex = 19;
            lblDomicilio.Text = "Domicilio";
            lblDomicilio.TextAlign = ContentAlignment.TopCenter;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Font = new Font("Futura Md BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaNacimiento.Location = new Point(669, 342);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(334, 31);
            dtpFechaNacimiento.TabIndex = 21;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1045, 745);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtDomicilio);
            Controls.Add(lblDomicilio);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(btnVolver);
            Controls.Add(lblInscripcion);
            Controls.Add(picRegistro);
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
            ((System.ComponentModel.ISupportInitialize)picRegistro).EndInit();
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
        private PictureBox picRegistro;
        private Label lblInscripcion;
        private Button btnVolver;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFechaNacimiento;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtDomicilio;
        private Label lblDomicilio;
        private DateTimePicker dtpFechaNacimiento;
    }
}