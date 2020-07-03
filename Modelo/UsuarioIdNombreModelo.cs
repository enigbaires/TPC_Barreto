using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioIdNombreModelo
    {
        public int id_matriz { get; set; }
        public int id_usuario_solicitante { get; set; }
        public int id_usuario_aprobador { get; set; }
        public String nombre_solicitante { get; set; }
        public String nombre_aprobador { get; set; }

    }
}
