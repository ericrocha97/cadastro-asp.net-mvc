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
            DropUF();
        }

        public void PreencherGridMySQL()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
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
                //Id = TextBoxID.Text,
                Nome = TextBoxNome.Text,
                Estado = TextBoxEstado.Text,
                UF = TextBoxUF.Text
            };
            ListaCidades.Add(cadastro);

            return ListaCidades;
        }

        private void GravarBanco()
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            cnx.Open();
            MySqlCommand comm = cnx.CreateCommand();
            comm.CommandText = "INSERT INTO cidades(`nome`,`estado`,`UF`) VALUES(@nome, @estado, @UF)";
            comm.Parameters.AddWithValue("@nome", TextBoxNome.Text.ToUpper());
            comm.Parameters.AddWithValue("@estado", ddUF.SelectedItem);
            comm.Parameters.AddWithValue("@UF", TextBoxUF.Text.ToUpper());
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
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
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

        protected void ButtonPesquisar(object sender, EventArgs e)
        {
            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
            // sql consulta
            string sql = "SELECT * FROM `cidades` WHERE `nome` LIKE @nome";
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
            GridCidade.DataSource = data;
            GridCidade.DataBind();
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
                    /*DropDownList2.Items.Add(dr["nome_estado"].ToString());
                    DropDownList2.Items[cont].Value = dr["i_estados"].ToString();*/

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

            string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
            MySqlConnection sqlCon = new MySqlConnection(connectionString); //estancia a conexao
            sqlCon.Open();
            string sql = "SELECT `UF` FROM `estado` WHERE `nome` like @estado";
            using (MySqlCommand cmd = new MySqlCommand(sql, sqlCon))
            {
                cmd.Parameters.AddWithValue("@estado", ddUF.SelectedItem + "%");
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TextBoxUF.Text = dr["UF"].ToString();
                }
            }
            sqlCon.Close();
        }
    }
}