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
    public partial class Cadastro_Cidade : System.Web.UI.Page
    {
        private DataSet connDataSet;

        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherGridMySQL();
        }

        public void PreencherGridMySQL()
        {
            string connectionString = @"Server=localhost;Database=atividade;Uid=root;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.

            connDataSet = new DataSet();



            // sql consulta
            string sql = "select * from cidades";
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
            GridCidade.DataSource = data;
            GridCidade.DataBind();

        }

        public class Cidade
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Estado { get; set; }
            public string UF { get; set; }

        }


        private void PreencherGrid()
        {
            
            this.GridCidade.DataSource = ConsultarDados();
            this.GridCidade.DataBind();
            
        }

        private List<Cidade> ConsultarDados()
        {
            List<Cidade> ListaCidades = new List<Cidade>();
            Cidade cadastro = new Cidade
            {
                Id = TextBoxID.Text,
                Nome = TextBoxNome.Text,
                Estado = TextBoxEstado.Text,
                UF = TextBoxUF.Text
            };
            ListaCidades.Add(cadastro);

            return ListaCidades;
        }

        private void GravarBanco()
        {
            string connectionString = @"Server=localhost;Database=atividade;Uid=root;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            cnx.Open();
            MySqlCommand comm = cnx.CreateCommand();
            comm.CommandText = "INSERT INTO cidades(`nome`,`estado`,`UF`) VALUES(@nome, @estado, @UF)";
            comm.Parameters.AddWithValue("@nome", TextBoxNome.Text);
            comm.Parameters.AddWithValue("@estado", TextBoxEstado.Text);
            comm.Parameters.AddWithValue("@UF", TextBoxUF.Text);
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
            TextBoxEstado.Text = "";
            TextBoxUF.Text = "";

        }

        protected void ButtonExcluir(object sender, EventArgs e)
        {
            ExcluirBanco();
            PreencherGridMySQL();
            Limpacampos();
        }

        private void ExcluirBanco()
        {
            string connectionString = @"Server=localhost;Database=atividade;Uid=root;Pwd=poi098zxc123";
            MySqlConnection cnxdel = new MySqlConnection(connectionString); //instancia  conexão.
            cnxdel.Open();
            MySqlCommand del = cnxdel.CreateCommand();
            del.CommandText = "DELETE FROM cidades WHERE codigo = @id";
            del.Parameters.AddWithValue("@id", TextBoxIdEx.Text);
            del.ExecuteNonQuery();
            cnxdel.Close();
        }

        protected void ButtonVoltar(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}