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
            lblIngreso = new Label();
            btnSalir = new Button();
            button2 = new Button();
            btnAsignarCurso = new Button();
            btnPagarCurso = new Button();
            btnEmitirCompCurso = new Button();
            SuspendLayout();
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.Font = new Font("Futura Md BT", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblIngreso.Location = new Point(27, 39);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(339, 26);
            lblIngreso.TabIndex = 0;
            lblIngreso.Text = "Usuario: Prueba (Administrador)";
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Futura Md BT", 12F, FontStyle.Italic, GraphicsUnit.Point);
            btnSalir.Location = new Point(702, 30);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(131, 47);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Khaki;
            button2.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(42, 130);
            button2.Name = "button2";
            button2.Size = new Size(372, 118);
            button2.TabIndex = 2;
            button2.Text = "Registrar Cliente";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnInscribir_Click;
            // 
            // btnAsignarCurso
            // 
            btnAsignarCurso.BackColor = Color.LemonChiffon;
            btnAsignarCurso.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAsignarCurso.Location = new Point(461, 130);
            btnAsignarCurso.Name = "btnAsignarCurso";
            btnAsignarCurso.Size = new Size(372, 118);
            btnAsignarCurso.TabIndex = 3;
            btnAsignarCurso.Text = "Inscribir en Actividad";
            btnAsignarCurso.UseVisualStyleBackColor = false;
            // 
            // btnPagarCurso
            // 
            btnPagarCurso.BackColor = Color.LemonChiffon;
            btnPagarCurso.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnPagarCurso.Location = new Point(42, 320);
            btnPagarCurso.Name = "btnPagarCurso";
            btnPagarCurso.Size = new Size(372, 118);
            btnPagarCurso.TabIndex = 4;
            btnPagarCurso.Text = "Pagar Cuota";
            btnPagarCurso.UseVisualStyleBackColor = false;
            // 
            // btnEmitirCompCurso
            // 
            btnEmitirCompCurso.BackColor = Color.Khaki;
            btnEmitirCompCurso.Font = new Font("Futura Md BT", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnEmitirCompCurso.Location = new Point(461, 320);
            btnEmitirCompCurso.Name = "btnEmitirCompCurso";
            btnEmitirCompCurso.Size = new Size(372, 118);
            btnEmitirCompCurso.TabIndex = 5;
            btnEmitirCompCurso.Text = "Emitir datos Cliente";
            btnEmitirCompCurso.UseVisualStyleBackColor = false;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(876, 482);
            Controls.Add(btnEmitirCompCurso);
            Controls.Add(btnPagarCurso);
            Controls.Add(btnAsignarCurso);
            Controls.Add(button2);
            Controls.Add(btnSalir);
            Controls.Add(lblIngreso);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VENTANA PRINCIPAL";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngreso;
        private Button btnSalir;
        private Button button2;
        private Button btnAsignarCurso;
        private Button btnPagarCurso;
        private Button btnEmitirCompCurso;
    }
}