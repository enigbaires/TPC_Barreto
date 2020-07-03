using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ArchivoAdjuntoModelo
    {
        public int id_solicitud { get; set; }
        public String descripcion_archivo { get; set; }        
        public DateTime fecha_upload { get; set; }
    }
}
