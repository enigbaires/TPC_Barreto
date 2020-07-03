using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class SolicitudDetalleModelo
    {
        public int id_solicitud { get; set; }
        public int id_articulo { get; set; }
        public int cantidad { get; set; }
    }
}
