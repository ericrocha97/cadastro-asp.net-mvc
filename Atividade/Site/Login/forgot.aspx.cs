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
    public partial class forgot : System.Web.UI.Page
    {
        private DataSet connDataSet;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonReset(object sender, EventArgs e)
        {
            VerificEmail();
            

        }

        private void Limpacampos()
        {
            email.Text = "";
            newpassword.Text = "";
        }

        private void VerificEmail()
        {
            try
            {
                string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123"; ;
                MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
                                                                             //Recebendo as informações dos campos do front.
                string usu = email.Text;

                //Vamos abrir a conexão
                cnx.Open();

                connDataSet = new DataSet();

                MySqlCommand verificar_usu = new MySqlCommand("SELECT * FROM usuario WHERE email= '" + email.Text.Trim() + "' LIMIT 1", cnx);

                bool resultado = verificar_usu.ExecuteReader().HasRows;


                if (resultado == true)
                {
                    myModal.Attributes["class"] = "modal show";
                    myModal.Attributes["style"] = "display: block;";
                    // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "myModal", "openModal();", true);
                }
                else
                {
                    string alerta = "E-mail não cadastrado";

                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    
                }

            }
            catch (Exception ex)
            {
                string alerta = "Deu erro, falha catastrófica, fim do mundo se aproxima ";

                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            }

           
        }
        

        protected void FecharModal(object sender, EventArgs e)
        {
            myModal.Attributes["class"] = "modal";
            myModal.Attributes["style"] = "display: none;";

        }

        private void AlterSenha()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            cnx.Open();
            MySqlCommand comm = cnx.CreateCommand();
            comm.CommandText = "UPDATE usuario SET `senha` = @senha WHERE `email` = @email";
            comm.Parameters.AddWithValue("@senha", newpassword.Text);
            comm.Parameters.AddWithValue("@email", email.Text);
            comm.ExecuteNonQuery();
            cnx.Close();
        }

        protected void ButtonAlter(object sender, EventArgs e)
        {
            AlterSenha();
            Limpacampos();
            Response.Redirect("login.aspx");

        }
    }
}