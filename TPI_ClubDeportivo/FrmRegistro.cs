﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Datos.Entidades;

namespace TPI_ClubDeportivo
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();  // Mostrá el formulario principal (dueño)
            this.Close();       // Cerrá el formulario actual
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtDocumento.Text == "" || cboTipo.Text == "")
            {
                MessageBox.Show("Debe completar datos requeridos (*) ", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String respuesta;
                E_Cliente cliente = new E_Cliente();

                cliente.NombreC = txtNombre.Text;
                cliente.ApellidoC = txtApellido.Text;
                cliente.DocC = Convert.ToInt32(txtDocumento.Text);
                cliente.TDocC = cboTipo.Text;

                // Instaciamos para usar el método dentro de postulantes
                Datos.Clientes clientes = new Datos.Clientes();

                respuesta = clientes.Nuevo_Cliente(cliente);

                bool esnumero = int.TryParse(respuesta, out int codigo);


                if (esnumero)
                {
                    if (codigo == 1)
                    {
                        MessageBox.Show("CLIENTE YA EXISTE", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se almaceno con exito con el codigo Nro " + respuesta, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        /* =============================================
         * Limpiamos los objetos para un nuevo ingreso
         * =============================================
         */
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            cboTipo.Text = "";
            txtNombre.Focus();
        }
    }
}
