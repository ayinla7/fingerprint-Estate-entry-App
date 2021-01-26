using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AlfredGardens
{
    public partial class delacct : Form
    {
        public delacct()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";
            con3.Open();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select count(*) from login where Firstname ='" + (textBox1.Text).ToUpper() + "'";
            Int32 d = (Int32)cmd3.ExecuteScalar();
            if (d > 0)
            {
                SqlConnection con1 = new SqlConnection();
                SqlConnection con2 = new SqlConnection();
                con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";
                con2.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

                con1.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select password from login where Firstname ='" + (textBox1.Text).ToUpper() + "'";
                con2.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con2;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select password from login where Firstname ='" + (textBox1.Text).ToUpper() + "'";
                label2.Text = (String)cmd1.ExecuteScalar();
                label3.Text = (String)cmd2.ExecuteScalar();
                cmd2.ExecuteNonQuery();
                con2.Close();
                cmd1.ExecuteNonQuery();
                con1.Close();
            }
            else {
                MessageBox.Show("ACCOUNT NOT FOUND");
            }
            cmd3.ExecuteNonQuery();
            con3.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ss = new Admin();
            ss.Show();
        }

        private void delacct_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection();
            con3.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";
            con3.Open();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select count(*) from login where Firstname ='" + (textBox1.Text).ToUpper() + "'";
            Int32 d = (Int32)cmd3.ExecuteScalar();
            if (d > 0)
            {
                SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

            con1.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "delete  from login where Firstname ='" + (textBox1.Text).ToUpper() + "'";
            label2.Text = "";
            label2.Text = "";
            textBox1.Text="";
            cmd1.ExecuteNonQuery();
            con1.Close();
            MessageBox.Show("ACCOUNT DELETED!");
            }
            else
            {
                MessageBox.Show("ACCOUNT NOT FOUND");
            }
            cmd3.ExecuteNonQuery();
            con3.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
