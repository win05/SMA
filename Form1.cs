using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SMA
{
    public partial class Form1 : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BQOCPFL\WACSQL;Initial Catalog=SMA;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Utilisateur = v.Text;
            string Modpass = textBox1.Text;

            if (Utilisateur == "SMA" && Modpass == "123")
            {

                //MessageBox.Show(" Login success !!");
                this.Hide();
                FormSave ds = new FormSave();
                ds.Show();
            }
            else
            {
                MessageBox.Show(" wrong username or password ");
            }
        }
    }
}
