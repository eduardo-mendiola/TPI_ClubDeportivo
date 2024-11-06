using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Datos.Entidades
{
    internal class E_Cliente
    {
        public int IdCliente { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? TipoDoc { get; set; }
        public String Doc { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public String? Tel { get; set; }
        public String? Email { get; set; }
        public String? Domicilio { get; set; }
        public bool EsSocio { get; set; }
        public bool AptoFisico { get; set; }
        public List<E_Actividad> ActividadesInscriptas { get; set; }
    }
}
