using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Entidades
{
    internal class E_Actividad
    {
        public int IdActividad { get; private set; }
        public string? TipoDoc { get; private set; }
        public string? DocCliente { get; private set; }

        public void SetIdActividad(int idActividad)
        {
            IdActividad = idActividad;
        }

        public void SetDocCliente(string DocCliente)
        {
            this.DocCliente = DocCliente;
        }

        public void SetTipoDoc(string TipoDoc)
        {
            this.TipoDoc = TipoDoc;
        }
    }
}
