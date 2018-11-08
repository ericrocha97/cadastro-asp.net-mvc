using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Atividade.Site
{
    public partial class register : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GravarBanco()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            cnx.Open();
            MySqlCommand comm = cnx.CreateCommand();
            comm.CommandText = "INSERT INTO usuario(`nome`,`email`,`senha`) VALUES(@nome, @email, @senha)";
            comm.Parameters.AddWithValue("@nome", name.Text);
            comm.Parameters.AddWithValue("@email", email.Text);
            comm.Parameters.AddWithValue("@senha", password.Text);
            comm.ExecuteNonQuery();
            cnx.Close();
        }

        private void Limpacampos()
        {
            name.Text = "";
            email.Text = "";
            password.Text = "";
        }

        private void IrParaLogin()
        {
            Response.Redirect("login.aspx");
        }

        public bool IsCheckboxChecked
        {
            get { return aggree.Checked; }
        }

           

        protected void ButtonRegister(object sender, EventArgs e)
        {
            
            if (IsCheckboxChecked.Equals(true))
            {
                GravarBanco();
                Limpacampos();
                string alerta = "Usuário cadastrado com sucesso.";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                IrParaLogin();
            }
            else
            {
                string alertax = "Você deve concordar com os termos de uso.";
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alertax + "')</script>");
            }
            {

            }
            

        }
    }
}