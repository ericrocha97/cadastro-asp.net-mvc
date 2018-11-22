using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Atividade.Site
{
    public partial class CadastroProduto : System.Web.UI.Page
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
            string sql = "select * from produtos";
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
            GridProduto.DataSource = data;
            GridProduto.DataBind();

        }

        private void GravarBanco()
        {
            try
            {
                string connectionString = @"Server=MYSQL5018.site4now.net;Database=db_a427ba_ericroc;Uid=a427ba_ericroc;Pwd=poi098zxc123";
                MySqlConnection cnx = new MySqlConnection(connectionString); //instancia  conexão.
                cnx.Open();
                MySqlCommand comm = cnx.CreateCommand();
                comm.CommandText = "INSERT INTO produtos(`descricao`,`UN`,`preco`) VALUES(@descricao, @UN, @preco)";
                comm.Parameters.AddWithValue("@descricao", TextBoxDesc.Text.ToUpper());
                comm.Parameters.AddWithValue("@UN", TextBoxUN.Text.ToUpper());
               
                 string valor = TextBoxPreco.Text;
                

                NumberFormatInfo nfi = new NumberFormatInfo();

                var cultureSeparator = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                cultureSeparator.NumberFormat.NumberDecimalSeparator = nfi.CurrencyDecimalSeparator;

                valor = valor.Replace(",", nfi.CurrencyDecimalSeparator);
                valor = valor.Replace(".", nfi.CurrencyDecimalSeparator);

                decimal number = decimal.Parse(valor, cultureSeparator);
                
                comm.Parameters.AddWithValue("@preco", number);
                comm.ExecuteNonQuery();
                cnx.Close();
                

            }
            catch (Exception ex)
            {
                string alerta = "Deu erro, falha catastrófica, fim do mundo se aproxima ";

                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "<script type='text/javascript'>alert('" + alerta + "')</script>");

            }
            
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
            TextBoxDesc.Text = "";
            TextBoxUN.Text = "";
            TextBoxPreco.Text = "";

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
            del.CommandText = "DELETE FROM produtos WHERE codigo = @id";
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
            string sql = "SELECT * FROM `produtos` WHERE `descricao` LIKE @descricao or `codigo` LIKE @descricao or `UN` LIKE @descricao or `preco` LIKE @descricao";
            // abre a conexao
            cnx.Open();
            // cria o comando
            MySqlCommand cmd = new MySqlCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@descricao","%" + TextBoxPesquisa.Text + "%");
            // cria a tabela de dados
            DataTable data = new DataTable();
            //carrega a tabela com os dados
            data.Load(cmd.ExecuteReader());
            //fecha conexao
            cnx.Close();
            // carega a grid com a tabela
            GridProduto.DataSource = data;
            GridProduto.DataBind();
        }
    }
}