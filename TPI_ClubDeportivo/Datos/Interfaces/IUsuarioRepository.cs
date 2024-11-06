using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPI_ClubDeportivo.Datos.Interfaces
{
    internal interface IUsuarioRepository
    {
        DataTable ObtenerUsuarioPorCredenciales(string nombreUsuario, string password);
    }
}
