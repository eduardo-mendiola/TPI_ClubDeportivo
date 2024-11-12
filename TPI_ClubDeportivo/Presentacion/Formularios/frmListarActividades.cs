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
    public partial class frmListarActividades : Form
    {
        public frmListarActividades()
        {
            InitializeComponent();
        }

        private void frmListarActividades_Load(object sender, EventArgs e)
        {
            // Carga de datos en la grilla
            E_Actividad ListaActividades = new E_Actividad();
            ListaActividades.ListarActividadesRegistradas(dtgvActReg); 
        }

        // Salir de frmListarActividad a frmPrincipal
        private void btnVolverListAct_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
