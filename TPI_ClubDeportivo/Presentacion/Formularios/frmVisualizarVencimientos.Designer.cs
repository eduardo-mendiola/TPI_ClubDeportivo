namespace TPI_ClubDeportivo.Presentacion.Formularios
{
    partial class frmVisualizarVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarVencimientos));
            picLogo = new PictureBox();
            panel1 = new Panel();
            lblPagar = new Label();
            btnVolverVence = new Button();
            dtgvVencen = new DataGridView();
            ID_Pago = new DataGridViewTextBoxColumn();
            Inscripcion = new DataGridViewTextBoxColumn();
            Vencimiento = new DataGridViewTextBoxColumn();
            IdSocio = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            TipoDoc = new DataGridViewTextBoxColumn();
            Doc = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvVencen).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(35, 34);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 39;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(lblPagar);
            panel1.Controls.Add(btnVolverVence);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1430, 110);
            panel1.TabIndex = 38;
            // 
            // lblPagar
            // 
            lblPagar.AutoSize = true;
            lblPagar.Font = new Font("Century", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblPagar.ForeColor = Color.FromArgb(64, 64, 64);
            lblPagar.Location = new Point(519, 32);
            lblPagar.Name = "lblPagar";
            lblPagar.Size = new Size(390, 47);
            lblPagar.TabIndex = 11;
            lblPagar.Text = "Cuotas que Vencen";
            // 
            // btnVolverVence
            // 
            btnVolverVence.BackColor = Color.Gainsboro;
            btnVolverVence.Font = new Font("Futura Md BT", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnVolverVence.ForeColor = Color.DimGray;
            btnVolverVence.Location = new Point(1261, 29);
            btnVolverVence.Name = "btnVolverVence";
            btnVolverVence.Size = new Size(140, 50);
            btnVolverVence.TabIndex = 0;
            btnVolverVence.Text = "Volver";
            btnVolverVence.UseVisualStyleBackColor = false;
            btnVolverVence.Click += btnVolverVence_Click;
            // 
            // dtgvVencen
            // 
            dtgvVencen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvVencen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvVencen.Columns.AddRange(new DataGridViewColumn[] { ID_Pago, Inscripcion, Vencimiento, IdSocio, Nombre, Apellido, TipoDoc, Doc, Monto, Estado });
            dtgvVencen.Location = new Point(35, 248);
            dtgvVencen.Name = "dtgvVencen";
            dtgvVencen.RowHeadersWidth = 50;
            dtgvVencen.RowTemplate.Height = 33;
            dtgvVencen.Size = new Size(1365, 324);
            dtgvVencen.TabIndex = 1;
            // 
            // ID_Pago
            // 
            ID_Pago.HeaderText = "ID PAGO";
            ID_Pago.MinimumWidth = 6;
            ID_Pago.Name = "ID_Pago";
            // 
            // Inscripcion
            // 
            Inscripcion.HeaderText = "INSCRIPCIÓN";
            Inscripcion.MinimumWidth = 6;
            Inscripcion.Name = "Inscripcion";
            // 
            // Vencimiento
            // 
            Vencimiento.HeaderText = "VENCIMIENTO";
            Vencimiento.MinimumWidth = 6;
            Vencimiento.Name = "Vencimiento";
            // 
            // IdSocio
            // 
            IdSocio.HeaderText = "ID SOCIO";
            IdSocio.MinimumWidth = 6;
            IdSocio.Name = "IdSocio";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "NOMBRE";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            Apellido.HeaderText = "APELLIDO";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            // 
            // TipoDoc
            // 
            TipoDoc.HeaderText = "TIPO";
            TipoDoc.MinimumWidth = 6;
            TipoDoc.Name = "TipoDoc";
            // 
            // Doc
            // 
            Doc.HeaderText = "DOCUMENTO";
            Doc.MinimumWidth = 6;
            Doc.Name = "Doc";
            // 
            // Monto
            // 
            Monto.HeaderText = "MONTO ($)";
            Monto.MinimumWidth = 6;
            Monto.Name = "Monto";
            // 
            // Estado
            // 
            Estado.HeaderText = "ESTADO";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            // 
            // frmVisualizarVencimientos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1430, 681);
            Controls.Add(dtgvVencen);
            Controls.Add(picLogo);
            Controls.Add(panel1);
            Name = "frmVisualizarVencimientos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVisualizarVencimientos";
            Load += frmVisualizarVencimientos_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvVencen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picLogo;
        private Panel panel1;
        private Label lblPagar;
        private Button btnVolverVence;
        private DataGridView dtgvVencen;
        private DataGridViewTextBoxColumn ID_Pago;
        private DataGridViewTextBoxColumn Inscripcion;
        private DataGridViewTextBoxColumn Vencimiento;
        private DataGridViewTextBoxColumn IdSocio;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn TipoDoc;
        private DataGridViewTextBoxColumn Doc;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn Estado;
    }
}