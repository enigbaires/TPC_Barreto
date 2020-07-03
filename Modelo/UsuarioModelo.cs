using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioModelo
    {
        public int id_usuario { get; set; }
        public String nombre { get; set; }
        public String usuario_code1 { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public int usuario_tipo { get; set; } //0: usuario 1: aprobador 2: administrador
        public int usuario_habilitado { get; set; }
    }
}
