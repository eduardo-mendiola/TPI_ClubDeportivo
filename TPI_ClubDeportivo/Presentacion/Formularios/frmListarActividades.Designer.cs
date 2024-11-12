namespace TPI_ClubDeportivo.Presentacion.Formularios
{
    partial class frmListarActividades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarActividades));
            picLogo = new PictureBox();
            panel1 = new Panel();
            lblPagar = new Label();
            btnVolverListAct = new Button();
            dtgvActReg = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NombreAct = new DataGridViewTextBoxColumn();
            Duracion = new DataGridViewTextBoxColumn();
            Maximo = new DataGridViewTextBoxColumn();
            Inscriptos = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Horario = new DataGridViewTextBoxColumn();
            Dias = new DataGridViewTextBoxColumn();
            Instructor = new DataGridViewTextBoxColumn();
            pnlAutor = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvActReg).BeginInit();
            pnlAutor.SuspendLayout();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.InitialImage = null;
            picLogo.Location = new Point(32, 32);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 42;
            picLogo.TabStop = false;
            picLogo.WaitOnLoad = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(lblPagar);
            panel1.Controls.Add(btnVolverListAct);
            panel1.Location = new Point(-4, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1430, 110);
            panel1.TabIndex = 41;
            // 
            // lblPagar
            // 
            lblPagar.AutoSize = true;
            lblPagar.Font = new Font("Century", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblPagar.ForeColor = Color.FromArgb(64, 64, 64);
            lblPagar.Location = new Point(469, 32);
            lblPagar.Name = "lblPagar";
            lblPagar.Size = new Size(493, 47);
            lblPagar.TabIndex = 11;
            lblPagar.Text = "Actividades Registradas";
            // 
            // btnVolverListAct
            // 
            btnVolverListAct.BackColor = Color.Gainsboro;
            btnVolverListAct.Font = new Font("Futura Md BT", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnVolverListAct.ForeColor = Color.DimGray;
            btnVolverListAct.Location = new Point(1261, 28);
            btnVolverListAct.Name = "btnVolverListAct";
            btnVolverListAct.Size = new Size(140, 50);
            btnVolverListAct.TabIndex = 0;
            btnVolverListAct.Text = "Volver";
            btnVolverListAct.UseVisualStyleBackColor = false;
            btnVolverListAct.Click += btnVolverListAct_Click;
            // 
            // dtgvActReg
            // 
            dtgvActReg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvActReg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvActReg.Columns.AddRange(new DataGridViewColumn[] { ID, NombreAct, Duracion, Maximo, Inscriptos, dataGridViewTextBoxColumn1, Fecha, Horario, Dias, Instructor });
            dtgvActReg.Location = new Point(32, 230);
            dtgvActReg.Name = "dtgvActReg";
            dtgvActReg.RowHeadersWidth = 50;
            dtgvActReg.RowTemplate.Height = 33;
            dtgvActReg.Size = new Size(1365, 324);
            dtgvActReg.TabIndex = 1;
            // 
            // ID
            // 
            ID.FillWeight = 50F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // NombreAct
            // 
            NombreAct.HeaderText = "ACTIVIDAD";
            NombreAct.MinimumWidth = 6;
            NombreAct.Name = "NombreAct";
            // 
            // Duracion
            // 
            Duracion.FillWeight = 50F;
            Duracion.HeaderText = "MIN";
            Duracion.MinimumWidth = 6;
            Duracion.Name = "Duracion";
            // 
            // Maximo
            // 
            Maximo.FillWeight = 50F;
            Maximo.HeaderText = "CUPO";
            Maximo.MinimumWidth = 6;
            Maximo.Name = "Maximo";
            // 
            // Inscriptos
            // 
            Inscriptos.FillWeight = 50F;
            Inscriptos.HeaderText = "INSC.";
            Inscriptos.MinimumWidth = 6;
            Inscriptos.Name = "Inscriptos";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "COSTO/DÍA ($)";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            // 
            // Horario
            // 
            Horario.FillWeight = 60F;
            Horario.HeaderText = "HORA";
            Horario.MinimumWidth = 6;
            Horario.Name = "Horario";
            // 
            // Dias
            // 
            Dias.FillWeight = 150F;
            Dias.HeaderText = "DÍAS";
            Dias.MinimumWidth = 6;
            Dias.Name = "Dias";
            // 
            // Instructor
            // 
            Instructor.FillWeight = 200F;
            Instructor.HeaderText = "INSTRUCTOR";
            Instructor.MinimumWidth = 6;
            Instructor.Name = "Instructor";
            // 
            // pnlAutor
            // 
            pnlAutor.BackColor = Color.LightSkyBlue;
            pnlAutor.Controls.Add(label2);
            pnlAutor.Location = new Point(-4, 637);
            pnlAutor.Name = "pnlAutor";
            pnlAutor.Size = new Size(1430, 33);
            pnlAutor.TabIndex = 43;
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
            // frmListarActividades
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 669);
            Controls.Add(pnlAutor);
            Controls.Add(dtgvActReg);
            Controls.Add(picLogo);
            Controls.Add(panel1);
            Name = "frmListarActividades";
            Text = "frmListarActividades";
            Load += frmListarActividades_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvActReg).EndInit();
            pnlAutor.ResumeLayout(false);
            pnlAutor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picLogo;
        private Panel panel1;
        private Label lblPagar;
        private Button btnVolverListAct;
        private DataGridView dtgvActReg;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NombreAct;
        private DataGridViewTextBoxColumn Duracion;
        private DataGridViewTextBoxColumn Maximo;
        private DataGridViewTextBoxColumn Inscriptos;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Horario;
        private DataGridViewTextBoxColumn Dias;
        private DataGridViewTextBoxColumn Instructor;
        private Panel pnlAutor;
        private Label label2;
    }
}