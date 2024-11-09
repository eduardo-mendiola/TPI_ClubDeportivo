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

namespace TPI_ClubDeportivo
{
    public partial class frmInscribirActividad : Form
    {
        // TODO: Mostar solo lista de actividades disponibles, aquellas que tengan cupo libre.
        public frmInscribirActividad()
        {
            InitializeComponent();
        }

        private void frmAsignar_Load(object sender, EventArgs e)
        {
            CargarGrilla(); // Llamada al procedimiento
            cboTipoDocCliente.SelectedIndex = 0; // Para que al iniciar el form de registro muestre DNI en el tipo por defecto.
        }

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

        private bool ComprobarCupoDisponible(int CodAct)
        {
            bool Respuesta = false;
            try
            {
                using (MySqlConnection sqlCon = ConexionDB.getInstancia().CrearConexion())
                {
                    sqlCon.Open();
                    string query = "SELECT MaxParticipantes, CantInscriptos " +
                                   "FROM Actividad a " +
                                   "INNER JOIN Edicion e ON a.NActividad = e.NActividad " +
                                   "WHERE e.IdEdicion = @CodAct";

                    MySqlCommand comando = new MySqlCommand(query, sqlCon);
                    comando.Parameters.AddWithValue("@CodAct", CodAct);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int maxParticipantes = reader.GetInt32(0);
                            int cantInscriptos = reader.GetInt32(1);
                            int cupoDisponible = maxParticipantes - cantInscriptos;

                            // Comprueba si hay cupo disponible
                            Respuesta = cupoDisponible > 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo obtener el cupo disponible de la actividad.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar el cupo disponible: " + ex.Message);
            }
            return Respuesta;
        }


        private void btnInscribirCliente_Click(object sender, EventArgs e)
        {
            if (cboTipoDocCliente.Text == "" || txtDocCliente.Text == "" || txtIdActividad.Text == "")
            {
                MessageBox.Show("Debe completar todos los datos requeridos", "AVISO DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String respuesta;
                E_Actividad inscripcion = new E_Actividad();

                inscripcion.SetTipoDoc(cboTipoDocCliente.Text);
                inscripcion.SetDocCliente(txtDocCliente.Text);
                inscripcion.SetIdActividad(Convert.ToInt32(txtIdActividad.Text));

                if (ComprobarCupoDisponible(Convert.ToInt32(txtIdActividad.Text))) 
                {
                    // Instaciamos para usar el método dentro de postulantes
                    D_Actividad inscribir = new D_Actividad();

                    respuesta = inscribir.Nueva_Inscripcion(inscripcion);

                    bool esnumero = int.TryParse(respuesta, out int codigo);

                    if (esnumero)
                    {
                        if (codigo == 1)
                        {
                            MessageBox.Show("El cliente ya está inscrito en la actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Se inscribió con éxito el cliente con documento: " + cboTipoDocCliente.Text + ": " + txtDocCliente.Text + " a la Actividad ID: " + txtIdActividad.Text, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dtgvActividades.Rows.Clear();
                            CargarGrilla();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay cupos disponibles en la actividad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void btnLimpiarInscripcion_Click(object sender, EventArgs e)
        {
            txtDocCliente.Text = "";
            txtIdActividad.Text = "";
        }
    }
}
