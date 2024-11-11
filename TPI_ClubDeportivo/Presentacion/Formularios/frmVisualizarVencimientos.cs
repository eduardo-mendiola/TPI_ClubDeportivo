using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Entidades;

namespace TPI_ClubDeportivo.Presentacion.Formularios
{
    public partial class frmVisualizarVencimientos : Form
    {
        public frmVisualizarVencimientos()
        {
            InitializeComponent();
        }

        private void btnVolverVence_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmVisualizarVencimientos_Load(object sender, EventArgs e)
        {
            E_Cuota CuentasVencen = new E_Cuota();
            CuentasVencen.ListarCuotasVencenHoy(dtgvVencen);
        }
    }
}
