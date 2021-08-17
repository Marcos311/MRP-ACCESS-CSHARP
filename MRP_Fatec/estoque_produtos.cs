using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MRP_Fatec
{
    public partial class estoque_produtos : Form
    {
        public estoque_produtos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath;

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                con.Open();

                string SQL = "SELECT * FROM tb_produtofinal";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, con);

                DataSet DS = new DataSet();

                adapter.Fill(DS, "tb_produtofinal");

                dataGridView1.DataSource = DS.Tables["tb_produtofinal"];

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void estoque_produtos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath;

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                con.Open();

                OleDbCommand cmd = new OleDbCommand();

                cmd.Connection = con;

                string cons = "UPDATE tb_produtofinal SET Estoq_atual = '" + textBox2.Text +
                                            "', Estoq_max = '" + textBox3.Text +
                                            "', Estoq_min = '" + textBox4.Text +
                                            "' WHERE Codigo = " + textBox1.Text + "";

                cmd.CommandText = cons;

                cmd.ExecuteNonQuery();

                string SQLATT = "Select * from tb_produtofinal";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQLATT, con);

                DataSet DS = new DataSet();

                adapter.Fill(DS, "tb_produtofinal");

                dataGridView1.DataSource = DS.Tables["tb_produtofinal"];

                con.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                string path = Application.StartupPath;

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                string procura = "SELECT * FROM tb_produtofinal";

                DataTable dados = new DataTable();

                OleDbDataAdapter adpt = new OleDbDataAdapter(procura, con);

                adpt.Fill(dados);

                con.Open();

                string Codigo = dataGridView1.SelectedCells[0].Value.ToString();

                textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[11].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[12].Value.ToString();
                textBox4.Text = dataGridView1.SelectedCells[13].Value.ToString();

                string SQL = "SELECT * FROM tb_produtofinal WHERE Codigo = " + Codigo;

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, con);

                DataSet DS = new DataSet();

                adapter.Fill(DS, "tb_produtofinal");

                dataGridView1.DataSource = DS.Tables["tb_produtofinal"];
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
