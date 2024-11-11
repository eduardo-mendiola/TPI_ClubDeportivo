namespace TPI_ClubDeportivo
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            picLogo = new PictureBox();
            lblUser = new Label();
            txtUser = new TextBox();
            btnIngresar = new Button();
            txtPass = new TextBox();
            lblPass = new Label();
            lblIFTS29 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(122, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(130, 130);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Futura Md BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.ForeColor = Color.FromArgb(64, 64, 64);
            lblUser.Location = new Point(46, 255);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(94, 27);
            lblUser.TabIndex = 1;
            lblUser.Text = "Usuario";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Futura Md BT", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.Location = new Point(46, 287);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(300, 37);
            txtUser.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.Highlight;
            btnIngresar.Font = new Font("Futura Md BT", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(46, 473);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(300, 62);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Iniciar sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Futura Md BT", 15F, FontStyle.Regular, GraphicsUnit.Point);
            txtPass.Location = new Point(46, 395);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(300, 37);
            txtPass.TabIndex = 1;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Futura Md BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblPass.ForeColor = Color.FromArgb(64, 64, 64);
            lblPass.Location = new Point(46, 359);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(135, 27);
            lblPass.TabIndex = 5;
            lblPass.Text = "Contraseña";
            // 
            // lblIFTS29
            // 
            lblIFTS29.AutoSize = true;
            lblIFTS29.Font = new Font("Century", 25F, FontStyle.Bold, GraphicsUnit.Point);
            lblIFTS29.ForeColor = Color.FromArgb(64, 64, 64);
            lblIFTS29.Location = new Point(63, 169);
            lblIFTS29.Name = "lblIFTS29";
            lblIFTS29.Size = new Size(250, 50);
            lblIFTS29.TabIndex = 6;
            lblIFTS29.Text = "Bienvenido";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(395, 90);
            panel1.TabIndex = 8;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 573);
            Controls.Add(picLogo);
            Controls.Add(panel1);
            Controls.Add(lblIFTS29);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(btnIngresar);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblUser;
        private TextBox txtUser;
        private Button btnIngresar;
        private TextBox txtPass;
        private Label lblPass;
        private Label lblIFTS29;
        private Panel panel1;
    }
}