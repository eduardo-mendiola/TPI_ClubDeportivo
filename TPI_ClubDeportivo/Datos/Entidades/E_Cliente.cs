using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Datos.Entidades
{
    internal class E_Cliente
    {
        public int NCliente { get; set; }
        public String? NombreC { get; set; }
        public String? ApellidoC { get; set; }
        public String? TDocC { get; set; }
        public int DocC { get; set; }
        public DateTime? FechaNacimientoC { get; set; }
        public String? TelC { get; set; }
        public String? DomicilioC { get; set; }
        public String? EmailC { get; set; }
        public bool EsSocio { get; set; }
    }
}
