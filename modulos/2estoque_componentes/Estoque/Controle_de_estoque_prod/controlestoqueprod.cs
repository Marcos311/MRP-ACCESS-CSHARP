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

namespace Controle_de_estoque_prod
{
    public partial class Estoque_prod : Form
    {
        public Estoque_prod()
        {
            InitializeComponent();
        }

        private void bt_Ajuda_Click(object sender, EventArgs e)
        {
            Form2 form_ajuda = new Form2();
            form_ajuda.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath;

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + path + @"\database\DBP1-MRP_final.mdb");

                con.Open();

                string SQL = "SELECT * FROM tb_cadpecas";

                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, con);

                DataSet DS = new DataSet();

                adapter.Fill(DS, "tb_cadpecas");

                dataGridView1.DataSource = DS.Tables["tb_cadpecas"];

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
