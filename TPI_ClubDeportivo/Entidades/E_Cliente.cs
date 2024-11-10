using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI_ClubDeportivo.Datos.Infrastructure;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_Cliente
    {
        public int IdCliente { get; private set; }
        public string? Nombre { get; private set; }
        public string? Apellido { get; private set; }
        public string? TipoDoc { get; private set; }
        public string Doc { get; private set; }
        public DateTime? FechaNacimiento { get; private set; }
        public string? Tel { get; private set; }
        public string? Email { get; private set; }
        public string? Domicilio { get; private set; }
        public bool EsSocio { get; private set; }
        public bool AptoFisico { get; private set; }
        public List<E_Actividad> ActividadesInscriptas { get; private set; }

        public E_Cliente()
        {
            this.EsSocio = false;
            this.AptoFisico = true;
        }


        public void SetIdCliente(int idCliente)
        {
            IdCliente = idCliente;
        }

        public int GetIdCliente()
        {
            return IdCliente;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void SetApellido(string apellido)
        {
            Apellido = apellido;
        }

        public void SetTipoDoc(string tipoDoc)
        {
            TipoDoc = tipoDoc;
        }

        public void SetDoc(string doc)
        {
            Doc = doc;
        }

        public void SetFechaNacimiento(DateTime? fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }

        public void SetTel(string tel)
        {
            Tel = tel;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetDomicilio(string domicilio)
        {
            Domicilio = domicilio;
        }

        public void SetEsSocio(bool esSocio)
        {
            EsSocio = esSocio;
        }

        public void SetAptoFisico(bool aptoFisico)
        {
            AptoFisico = aptoFisico;
        }

        public void SetActividadesInscriptas(List<E_Actividad> actividades)
        {
            ActividadesInscriptas = actividades;
        }


        public bool VerificarEsSocio(string TipoDocPago, string Documento)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            bool esSocio = false; 

            try
            {
                sqlCon = ConexionDB.getInstancia().CrearConexion();

                string query = "SELECT EsSocio " +
                               "FROM Cliente " +
                               "WHERE TDocC = @TipoDoc AND DocC = @Documento";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                comando.Parameters.AddWithValue("@TipoDoc", TipoDocPago);
                comando.Parameters.AddWithValue("@Documento", Documento);

                sqlCon.Open();
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read()) 
                {
                    esSocio = reader.GetInt32(0) == 1; 
                }

                reader.Close();
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

            return esSocio;
        }

    }
}


