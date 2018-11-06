using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Atividade
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/CadastroCliente.aspx");
        }

        protected void CadEstado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/CadastroEstado.aspx");
        }

        protected void CadCidade_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/CadastroCidade.aspx");
        }
    }
}