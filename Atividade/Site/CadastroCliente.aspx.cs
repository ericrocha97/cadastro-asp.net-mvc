using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Atividade.Views
{
    public partial class Cadastro_Cliente : System.Web.UI.Page
    {
        private DataSet connDataSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherGridMySQL();
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
                Cidade = TextBoxCidade.Text
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
            comm.Parameters.AddWithValue("@nome", TextBoxNome.Text);
            comm.Parameters.AddWithValue("@endereco", TextBoxEndereco.Text);
            comm.Parameters.AddWithValue("@cidade", TextBoxCidade.Text);
            comm.ExecuteNonQuery();
            cnx.Close();
        }


        protected void ButtonGravar(object sender, EventArgs e)
        {
            GravarBanco();
            PreencherGridMySQL();
            Limpacampos();
        }

        private void Limpacampos()
        {
            TextBoxIdEx.Text = "";
            TextBoxNome.Text = "";
            TextBoxEndereco.Text = "";
            TextBoxCidade.Text = "";

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
            string sql = "SELECT * FROM `clientes` WHERE `nome` LIKE @nome";
            // abre a conexao
            cnx.Open();
            // cria o comando
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nome", TextBoxPesquisa.Text);
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