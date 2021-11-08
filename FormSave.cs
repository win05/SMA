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
    public partial class FormSave : Form
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-BQOCPFL\WACSQL;Initial Catalog=SMA;Integrated Security=True");
        public FormSave()
        {
            InitializeComponent();
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMADataSet.SMAV' table. You can move, or remove it, as needed.
            this.sMAVTableAdapter.Fill(this.sMADataSet.SMAV);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                cnx.Open();
                string requet = "delete from SMAV where FullName='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand comma = new SqlCommand(requet, cnx);
                comma.ExecuteNonQuery();
                cnx.Close();
                DialogResult res = MessageBox.Show("Do you want to delete this contact ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    MessageBox.Show("Client removed ");
                }
                else MessageBox.Show("Client didn't remove");
            }

            else MessageBox.Show("choose client first ! !", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            AddV Addv = new AddV();
            Addv.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.sMAVTableAdapter.FillBy(this.sMADataSet.SMAV);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to save Changes", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                cnx.Open();
                SqlCommand cm = new SqlCommand("UPDATE SMAV SET FullName='" + textBox6.Text + "',Email='" + textBox5.Text + "',numero='" + textBox4.Text + "'WHERE FullName='" + textBox6.Text + "'", cnx);
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully update");
                textBox6.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
            else MessageBox.Show("Client ne pas modifier");
            cnx.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
         
        }
    }
}
