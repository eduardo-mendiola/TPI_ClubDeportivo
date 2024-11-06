using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_Cliente
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? TipoDoc { get; set; }
        public string Doc { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Domicilio { get; set; }
        public bool EsSocio { get; set; }
        public bool AptoFisico { get; set; }
        public List<E_Actividad> ActividadesInscriptas { get; set; }
    }
}
