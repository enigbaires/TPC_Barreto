using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace Vista
{
    public partial class CAIListado : System.Web.UI.Page
    {
        public List<CAIModelo> caiListado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DAOCai dao = new DAOCai();
            caiListado = dao.ListarCAI();
        }
    }
}