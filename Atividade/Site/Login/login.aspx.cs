using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Atividade.Site.Login
{
    public partial class login : System.Web.UI.Page

    {
        private DataSet connDataSet;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin(object sender, EventArgs e)
        {
            VerificLogin();
            Limpacampos();

        }

        private void Limpacampos()
        {
            email.Text = "";
            password.Text = "";
        }

        private void VerificLogin()
        {
            try
            {
                string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123"; ;
                MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
                                                                             //Recebendo as informações dos campos do front.
                string usu = email.Text;
                string pass = password.Text;

                //Vamos abrir a conexão
                cnx.Open();

                connDataSet = new DataSet();

                MySqlCommand verificar_usu = new MySqlCommand("SELECT * FROM usuario WHERE email= '" + email.Text.Trim() + "' AND senha= '" + password.Text.Trim() + "'LIMIT 1", cnx);

                bool resultado = verificar_usu.ExecuteReader().HasRows;


                if (resultado == true)
                {
                    Response.Redirect("../Index.aspx");
                }
                else
                {
                    string alerta = "Usuário ou senha incorreta";

                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    // Response.Redirect("login.aspx");
                }

            }
            catch (Exception ex)
            {
                string alerta = "Deu erro, falha catastrófica, fim do mundo se aproxima ";

                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            }
        }
    }
}