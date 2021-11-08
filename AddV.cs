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
using System.Text.RegularExpressions;

namespace SMA
{
    public partial class AddV : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BQOCPFL\WACSQL;Initial Catalog=SMA;Integrated Security=True");
        public AddV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            SqlDataAdapter dt = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("insert into SMAV (FullName,Email,NumberPhone) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", cnx);
            cmd.ExecuteNonQuery();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Erroure un text box est vide !!");
            }
            else
            {
                MessageBox.Show("The operation has been successfully completed.");
            }
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";

            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSave FS = new FormSave();
            FS.Show();
            this.Hide();
        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
       
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch)&& ch!=8&& ch!=46)
            {
                e.Handled = true;
            }
            if(char.IsDigit(e.KeyChar))
            {
                if((sender as TextBox).Text.Count(char.IsDigit)>=10)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{10}$");
            if(r.IsMatch(textBox3.Text))
            {
                textBox3.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                textBox3.BackColor = System.Drawing.Color.LightPink;
            }
        }

       
    }
}
