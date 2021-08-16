using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;

namespace ModuloCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] cnpjs;

        public OleDbConnection Conectar()
        {
            string caminho = Application.StartupPath + @"\database\DBP1-MRP_final.mdb";
            string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + caminho;
            OleDbConnection aConnection = new OleDbConnection(conn);
            return aConnection;
        }

        private void AjudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajuda janela_ajuda = new Ajuda();
            janela_ajuda.ShowDialog();
        }

        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarFornecedor cadastro_forn = new CadastrarFornecedor();
            cadastro_forn.ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            OleDbConnection con = Conectar();
            OleDbCommand aCommand = new OleDbCommand("SELECT count(*) FROM tb_fornecedores where status_fornecedor = 1", con);
            OleDbCommand aCommand2 = new OleDbCommand("SELECT * FROM tb_fornecedores where status_fornecedor = 1", con);

            try
            {
                con.Open();

                OleDbDataReader aReader = aCommand.ExecuteReader();

                aReader.Read();
                int qtd_reg = aReader.GetInt32(0);

                cnpjs = new string[qtd_reg];

                aReader.Close();

                ///////////////////////////////////////////////////////////////

                int cont = 0;

                OleDbDataReader aReader2 = aCommand2.ExecuteReader();

                aReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Preencha o tipo do produto");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Preencha a marca do produto");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Preencha o modelo do produto");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Preencha o tipo do produto");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Preencha o ano do produto");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Preencha o tipo do disco rígido do produto");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Preencha o tipo do gabinete do produto");
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Preencha o tipo da RAM produto");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Preencha o tipo da placa mãe do produto");
                }
                else
                {

                    string path = Application.StartupPath;

                    OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                    con.Open();

                    string SQL;

                    SQL = "Insert Into tb_compras(codigo_peca, marca_peca, tipo_peca, modelo_peca, especificacoes_peca, qtd_peca, valor_compra, data_compra, status_compra) Values";

                    SQL += "('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')";

                    OleDbCommand cmd = new OleDbCommand(SQL, con);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados cadastrados com sucesso");

                    string SQLATT = "SELECT * FROM tb_compras";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(SQLATT, con);

                    DataSet DS = new DataSet();

                    adapter.Fill(DS, "tb_compras");

                    dataGridView1.DataSource = DS.Tables["tb_compras"];


                    con.Close();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
    
}
