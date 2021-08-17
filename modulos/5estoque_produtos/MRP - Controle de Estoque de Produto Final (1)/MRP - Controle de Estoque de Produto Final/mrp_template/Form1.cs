using mrp_template.Componentes;
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

namespace mrp_template
{
    public partial class main_form : Form
    {

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
