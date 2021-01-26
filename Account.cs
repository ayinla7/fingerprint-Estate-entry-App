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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin s = new Admin();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER USERNAME!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("PLEASE ENTER USERNAME!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("PLEASE ENTER USERNAME!");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("PLEASE ENTER USERNAME!");
            }
            else
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;


                cmd.CommandText = "Insert into login(Username, Password, Firstname , Lastname ,Post) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ACCOUNT SUCESSFULLY CREATED!");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
