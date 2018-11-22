using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
//using System.Web;
using System.Security.Permissions;


namespace Atividade.Views
{
    public partial class Cadastro_Cliente : System.Web.UI.Page
    {
        private DataSet connDataSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherGridMySQL();
            DropUF();
        }

        public void PreencherGridMySQL()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.

            connDataSet = new DataSet();



            // sql consulta
            string sql = "select * from clientes";
            // abre a conexao
            cnx.Open();
            // cria o comando
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            // cria a tabela de dados
            DataTable data = new DataTable();
            //carrega a tabela com os dados
            data.Load(cmd.ExecuteReader());
            //fecha conexao
            cnx.Close();
            cnx.Dispose();
            // carega a grid com a tabela
            GridCliente.DataSource = data;
            GridCliente.DataBind();

        }

        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Cidade { get; set; }

        }


        private void PreencherGrid()
        {
            GridCliente.DataSource = ConsultarDados();
            GridCliente.DataBind();
        }

        private List<Cliente> ConsultarDados()
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            Cliente cadastro = new Cliente
            {
                //Id = int.Parse(TextBoxID.Text),
                Nome = TextBoxNome.Text,
                Endereco = TextBoxEndereco.Text,
                // Cidade = TextBoxCidade.Text
            };
            ListaClientes.Add(cadastro);

            return ListaClientes;
        }

        private void GravarBanco()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            cnx.Open();
            MySqlCommand comm = cnx.CreateCommand();
            comm.CommandText = "INSERT INTO clientes(`nome`,`endereco`,`cidade`) VALUES(@nome, @endereco, @cidade)";
            comm.Parameters.AddWithValue("@nome", TextBoxNome.Text.ToUpper());
            comm.Parameters.AddWithValue("@endereco", TextBoxEndereco.Text.ToUpper());
            comm.Parameters.AddWithValue("@cidade", ddlCidade.SelectedItem);
            comm.ExecuteNonQuery();
            cnx.Close();
        }

        

        protected void ButtonGravar(object sender, EventArgs e)
        {
            if (TextBoxNome.Text == "") {
                string alerta = "Campo Nome Obrigatorio";

                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
            } else {
                if(TextBoxEndereco.Text == "")
                {
                    string alerta = "Campo Endereço Obrigatorio";

                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                }
                else
                {
                    if(ddlCidade.SelectedItem is null)
                    {
                        string alerta = "Campo Cidade Obrigatorio";

                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                    }
                    else
                    {
                        if(ddlCidade.SelectedItem.Text == "Selecione a cidade")
                        {
                            string alerta = "Campo Cidade Obrigatorio";

                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");
                        }
                        else {
                            GravarBanco();
                            PreencherGridMySQL();
                            Limpacampos();
                            
                        }
                    }
                }
            }
            
        }

        private void Limpacampos()
        {
            TextBoxIdEx.Text = "";
            TextBoxNome.Text = "";
            TextBoxEndereco.Text = "";
            ddUF.ClearSelection();
            ddlCidade.ClearSelection();


        }

        protected void ButtonExcluir(object sender, EventArgs e)
        {

            ExcluirBanco();
            PreencherGridMySQL();
            Limpacampos();

            
        }

        private void ExcluirBanco()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnxdel = new MySqlConnection(connectionString); //instancia  conexão.
            cnxdel.Open();
            MySqlCommand del = cnxdel.CreateCommand();
            del.CommandText = "DELETE FROM clientes WHERE codigo = @id";
            del.Parameters.AddWithValue("@id", TextBoxIdEx.Text);
            del.ExecuteNonQuery();
            cnxdel.Close();
        }

        protected void ButtonVoltar(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void ButtonPesquisar(object sender, EventArgs e)
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            // sql consulta
            string sql = "SELECT * FROM `clientes` WHERE `nome` LIKE @nome or `codigo` LIKE @nome or `endereco` LIKE @nome or `cidade` LIKE @nome";
            // abre a conexao
            cnx.Open();
            // cria o comando
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nome","%" + TextBoxPesquisa.Text + "%");
            // cria a tabela de dados
            DataTable data = new DataTable();
            //carrega a tabela com os dados
            data.Load(cmd.ExecuteReader());
            //fecha conexao
            cnx.Close();
            // carega a grid com a tabela
            GridCliente.DataSource = data;
            GridCliente.DataBind();
        }

        public void DropUF()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection sqlCon = new MySqlConnection(connectionString); //estancia a conexao
            sqlCon.Open();
            string sql = "SELECT `codigo` , `nome` FROM `estado`";
            using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
            {
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                {
                    
                    ddUF.DataTextField = "nome";//Aqui inclua o nome do campo no Banco referente ao Nome a ser apresentado no DropDown  																
                    ddUF.DataValueField = "codigo";//Aqui inclua o nome do campo no Banco referente ao ID
                    ddUF.DataSource = dr; //Recebe o comando do select para popular o bagulho. 
                    ddUF.DataBind();  //vincula os dados					
                }
            }
            sqlCon.Close();
        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCidade.ClearSelection();
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection sqlCon = new MySqlConnection(connectionString); //estancia a conexao
            sqlCon.Open();
            string sql = "SELECT `codigo` , `nome` FROM `cidades` where `estado` like @estado";
            using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
            {
                cmd.Parameters.AddWithValue("@estado", ddUF.SelectedItem);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                {
                    ddlCidade.DataTextField = "nome";//Aqui inclua o nome do campo no Banco referente ao Nome a ser apresentado no DropDown  																
                    ddlCidade.DataValueField = "codigo";//Aqui inclua o nome do campo no Banco referente ao ID
                    ddlCidade.DataSource = dr; //Recebe o comando do select para popular o bagulho. 
                    ddlCidade.DataBind();  //vincula os dados

                }
            }
            sqlCon.Close();
        }

        public void Pesquisa(object sender, EventArgs e)
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            // sql consulta
            string sql = "SELECT * FROM `clientes` WHERE `nome` LIKE @nome";
            // abre a conexao
            cnx.Open();
            // cria o comando
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nome", TextBoxPesquisa.Text + "%");
            // cria a tabela de dados
            DataTable data = new DataTable();
            //carrega a tabela com os dados
            data.Load(cmd.ExecuteReader());
            //fecha conexao
            cnx.Close();
            // carega a grid com a tabela
            GridCliente.DataSource = data;
            GridCliente.DataBind();
        }

    }
    


}