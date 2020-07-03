using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class EmpresaModelo
    {
        public int id_empresa { get; set; }
        public String cuit { get; set; }
        public String razon_social { get; set; }
        public int numero_sap_empresa { get; set; }
        public String direccion_legal { get; set; }
        public String direccion_entrega { get; set; }
        public String telefono { get; set; }
        public String email { get; set; }

        //0: Cliente 1: transportista
        public int tipo_empresa { get; set; }
        public int habilitado_empresa { get; set; }

    }
}
