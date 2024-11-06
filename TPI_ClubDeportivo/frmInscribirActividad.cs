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
using TPI_ClubDeportivo.Datos.Entidades;

namespace TPI_ClubDeportivo
{
    public partial class frmInscribirActividad : Form
    {
        // TODO: Cambiar IDCliente por Documento del cliente para la inscripción.
        // TODO: Mostar solo lista de actividades disponibles, aquellas que tengan cupo libre.
        public frmInscribirActividad()
        {
            InitializeComponent();
        }

        private void frmAsignar_Load(object sender, EventArgs e)
        {
            CargarGrilla(); // Llamada al procedimiento
        }

        public void CargarGrilla()
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                string query;
                sqlCon = D_Conexion.getInstancia().CrearConexion();
                query = "SELECT e.IdEdicion, a.NombreActividad, e.DiasActividad, e.HorarioActividad, CONCAT(i.NombreInst, ' ', i.ApellidoInst) AS Instructor, a.CostoDiario " +
                        "FROM Actividad a " +
                        "INNER JOIN Edicion e ON a.NActividad = e.NActividad " +
                        "INNER JOIN Instructor i ON e.instructor = i.Ninstructor " +
                        "WHERE e.fecha > CURDATE() " +
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
                        dtgvActividades.Rows[renglon].Cells[4].Value = reader.GetString(4);
                        dtgvActividades.Rows[renglon].Cells[5].Value = reader.GetDouble(5);

                    }
                }
                else
                {
                    MessageBox.Show("NO HAY DATOS PARA LA CARGA DE LA GRILLA");
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

        private void btnVolverInsAct_Click(object sender, EventArgs e)
        {
            this.Owner.Show();  // Mostrá el formulario principal (dueño)
            this.Close();       // Cerrá el formulario actual
        }

        private void btnInscribirCliente_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "" || txtIdActividad.Text == "")
            {
                MessageBox.Show("Debe completar datos requeridos (*) ", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String respuesta;
                E_Actividad inscripcion = new E_Actividad();

                inscripcion.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                inscripcion.IdActividad = Convert.ToInt32(txtIdActividad.Text);

                // Instaciamos para usar el método dentro de postulantes
                D_Actividad inscribir = new D_Actividad();

                respuesta = inscribir.Nueva_Inscripcion(inscripcion);

                bool esnumero = int.TryParse(respuesta, out int codigo);


                if (esnumero)
                {
                    if (codigo == 1)
                    {
                        MessageBox.Show("EL CLIENTE YA ESTA INSCRIPTO EL LA ACTIVIDAD", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Se inscribio con éxito el cliente ID: " + txtIdCliente.Text + " a la Actividad ID: " + txtIdActividad.Text, "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }


        private void btnLimpiarInscripcion_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "";
            txtIdActividad.Text = "";
        }
    }
}
