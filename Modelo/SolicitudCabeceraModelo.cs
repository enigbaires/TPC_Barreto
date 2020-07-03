using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class SolicitudCabeceraModelo
    {
        public int id_solicitud { get; set; }
        public int id_usuario_solicitante { get; set; }
        public int id_usuario_aprobador { get; set; }
        public int punto_venta { get; set; }
        public int cantidad_items { get; set; }
        public int cantidad_bultos { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public int id_cliente { get; set; }
        public int id_transportista { get; set; }
        public int id_tipo_remito { get; set; }
        public String observacion_solicitud { get; set; }
        public int estado_solicitud { get; set; } //0: pendiente 1: aprobado 2: rehacer 3: rechazado
    }
}
