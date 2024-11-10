using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Interfaces
{
    internal interface IPago
    {
        void RealizarPago(string IdPago);
        void ObtenerDeuda(DataGridView dataGridView, string TipoDocPago, string Documento);
    }
}
