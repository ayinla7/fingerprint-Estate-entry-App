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
    public partial class SignOut2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");



        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public SignOut2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aa = new Admin();
            aa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ENTER FIRSTNAME");
            }
            else
            {
                con2.Open();
                SqlCommand cmd2 = con2.CreateCommand();
                cmd2.CommandType = CommandType.Text;

                cmd2.CommandText = "select count(*) from Registered where Firstname ='" + (textBox1.Text).ToUpper() + "'";


                Int32 Count = (Int32)cmd2.ExecuteScalar();

                if (Count == 0)
                {
                    MessageBox.Show("FIRSTNAME NOT FOUND!");
                }
                else
                {
                    con1.Open();
                    SqlCommand cmd1 = con1.CreateCommand();
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "select Lastname from Registered where Firstname ='" + (textBox1.Text).ToUpper() + "'";


                    String Lastname = (String)cmd1.ExecuteScalar();

                    if (Lastname.ToUpper() == textBox2.Text)
                    {
                        //
                        con3.Open();
                        SqlCommand cmd3 = con3.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "select Context from Registered where Firstname ='" + (textBox1.Text).ToUpper() + "' AND Lastname ='" + (textBox2.Text).ToUpper() + "'";
                        String Context = (String)cmd3.ExecuteScalar();
                        if (Context == "OUT")
                        {
                            MessageBox.Show("VISITOR ALREADY SIGNED OUT!");
                        }
                        else
                        {


                            ///
                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            String context1 = "OUT";
                            String Time = DateTime.Now.ToString("h:mm:ss tt");
                            String Date = DateTime.Today.ToString();
                            cmd.CommandText = "Update Registered set Context='" + context1 + "',TimeOut='" + Time + "',DateOut='" + Date + "' where ( Firstname = '" + textBox1.Text + "' AND Lastname = '" + textBox2.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            disp_data();
                            textBox1.Clear();
                            textBox2.Clear();
                            MessageBox.Show("Signed Out Successfully");
                        }
                        cmd3.ExecuteNonQuery();
                        con3.Close();
                        disp_data();

                    }
                    else
                    {

                        MessageBox.Show("NAME NOT FOUND!");
                    }
                    disp_data();
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                }
                cmd2.ExecuteNonQuery();
                con2.Close();
                disp_data();

            }




        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Registered";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        
    }

        private void SignOut2_Load(object sender, EventArgs e)
        {
            disp_data();
        }
    }
}
