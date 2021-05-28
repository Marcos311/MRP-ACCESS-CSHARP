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

namespace MRPPROJETO
{
    public partial class FormCadastrar : Form
    {
        public FormCadastrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCadProdFinal cadastrar = new FormCadProdFinal();
            try
            {
                string path = Application.StartupPath;

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                con.Open();

                string SQL;

                SQL = "Insert Into tb_produtofinal(Tipo, Marca, Modelo, Ano, DiscoRigido, Gabinete, RAM, PlacaMae, Processador, Cooler, PlacadeVideo) Values";

                SQL += "('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')";

                OleDbCommand cmd = new OleDbCommand(SQL, con);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados cadastrados com sucesso");

                string SQLATT = "SELECT * FROM tb_produtofinal";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQLATT, con);

                DataSet DS = new DataSet();

                adapter.Fill(DS, "tb_produtofinal");

                cadastrar.DgProdutosFinais.DataSource = DS.Tables["tb_produtofinal"];

                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
