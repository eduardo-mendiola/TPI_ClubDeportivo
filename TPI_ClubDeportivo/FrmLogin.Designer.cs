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
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(34, 49);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(280, 280);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.ForeColor = Color.DimGray;
            lblUser.Location = new Point(404, 111);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(121, 27);
            lblUser.TabIndex = 1;
            lblUser.Text = "USUARIO";
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtUser.Location = new Point(531, 105);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(226, 39);
            txtUser.TabIndex = 0;
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Futura Md BT", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.Gray;
            btnIngresar.Location = new Point(451, 242);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(249, 96);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtPass.Location = new Point(531, 171);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(226, 39);
            txtPass.TabIndex = 1;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblPass.ForeColor = Color.DimGray;
            lblPass.Location = new Point(351, 177);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(174, 27);
            lblPass.TabIndex = 5;
            lblPass.Text = "CONTRASEÑA";
            // 
            // lblIFTS29
            // 
            lblIFTS29.AutoSize = true;
            lblIFTS29.Font = new Font("Futura Md BT", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblIFTS29.ForeColor = SystemColors.HotTrack;
            lblIFTS29.Location = new Point(414, 33);
            lblIFTS29.Name = "lblIFTS29";
            lblIFTS29.Size = new Size(272, 41);
            lblIFTS29.TabIndex = 6;
            lblIFTS29.Text = "Club Deportivo";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 377);
            Controls.Add(lblIFTS29);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(btnIngresar);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(picLogo);
            Name = "FrmLogin";
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
    }
}