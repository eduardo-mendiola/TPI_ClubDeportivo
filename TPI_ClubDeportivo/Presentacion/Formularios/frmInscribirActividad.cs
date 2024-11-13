using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPI_ClubDeportivo.Datos;
using TPI_ClubDeportivo.Datos.Infrastructure;
using TPI_ClubDeportivo.Entidades;
using TPI_ClubDeportivo.Interfaces;

namespace TPI_ClubDeportivo
{
    public partial class frmInscribirActividad : Form
    {
        public frmInscribirActividad()
        {
            InitializeComponent();
        }

        private E_Cliente cliente;
        public bool AbiertoDesdePrincipal { get; set; } = false;

        public frmInscribirActividad(E_Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;  // Guarda el cliente para usarlo en el formulario

            // Precargar los datos del cliente en los campos de texto si es necesario
            cboTipoDocCliente.Text = cliente.GetTipoDoc();
            txtDocCliente.Text = cliente.GetDoc();
        }
      
        
        private void frmInscribirActividad_Load(object sender, EventArgs e)
        {
            CargarGrilla(); // Llamada al procedimiento
            //cboTipoDocCliente.SelectedIndex = 0; // Para que al iniciar el form de registro muestre DNI en el tipo por defecto.
        }

        // Salir de frmInscribirActividad a frmPrincipal
        private void btnVolverInsAct_Click(object sender, EventArgs e)
        {
            this.Owner.Show();  // Mostrá el formulario principal (dueño)
            this.Close();       // Cerrá el formulario actual
        }

        // Carga los datos en la grilla 
        public void CargarGrilla()
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = ConexionDB.getInstancia().CrearConexion();
                query = "SELECT e.IdEdicion, a.NombreActividad, e.DiasActividad, e.HorarioActividad, a.MaxParticipantes, a.CantInscriptos, CONCAT(i.NombreInst, ' ', i.ApellidoInst) AS Instructor, a.CostoDiario " +
                        "FROM Actividad a " +
                        "INNER JOIN Edicion e ON a.NActividad = e.NActividad " +
                        "INNER JOIN Instructor i ON e.instructor = i.Ninstructor " +
                        "WHERE e.fecha > CURDATE() AND a.CantInscriptos < a.MaxParticipantes " +
                        "ORDER BY a.NombreActividad; ";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();

                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int renglon = dtgvActividades.Rows.Add();
                        dtgvActividades.Rows[renglon].Cells[0].Value = reader.GetInt32(0);
                        dtgvActividades.Rows[renglon].Cells[1].Value = reader.GetString(1);
                        dtgvActividades.Rows[renglon].Cells[2].Value = reader.GetString(2);
                        dtgvActividades.Rows[renglon].Cells[3].Value = reader.GetTimeSpan(3);
                        dtgvActividades.Rows[renglon].Cells[4].Value = reader.GetInt32(4);
                        dtgvActividades.Rows[renglon].Cells[5].Value = (reader.GetInt16(4) - reader.GetInt32(5));
                        dtgvActividades.Rows[renglon].Cells[6].Value = reader.GetString(6);
                        dtgvActividades.Rows[renglon].Cells[7].Value = reader.GetDouble(7);

                    }
                }
                else
                {
                    MessageBox.Show("NO HAY DATOS PARA LA CARGA DE LA GRILLA", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        // Inscribir a un cliente en una actividad 
        private void btnInscribirCliente_Click(object sender, EventArgs e)
        {
            E_Actividad NuevaInscripcion = new E_Actividad();
            if (NuevaInscripcion.InscribirEnActividad(cboTipoDocCliente.Text, txtDocCliente.Text, txtIdActividad.Text))
            {
                dtgvActividades.Rows.Clear();
                CargarGrilla();

                
                if (!AbiertoDesdePrincipal)  // Ejecuta esta lógica solo si no fue abierto desde frmPrincipal
                {
                    MessageBox.Show("Inscripción completada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;  // Retornar OK
                    this.Close();
                }
            }
        }

        // Limpiar los campos de tipo de documento y número
        private void btnLimpiarInscripcion_Click(object sender, EventArgs e)
        {
            txtDocCliente.Text = "";
            txtIdActividad.Text = "";
        }

    }
}
