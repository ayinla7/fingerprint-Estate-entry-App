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
    public partial class Register2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Register2()
        {
            InitializeComponent();
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            copyAlltoClipboard();
            MessageBox.Show("Copied");


        }

        private void House()
        {
            house.Items.Add("FACILITY");
            house.Items.Add("1");
            house.Items.Add("2");
            house.Items.Add("3");
            house.Items.Add("4");
            house.Items.Add("5");
            house.Items.Add("6");
            house.Items.Add("7");
            house.Items.Add("8");
            house.Items.Add("9");
            house.Items.Add("10");
            house.Items.Add("11");
            house.Items.Add("12");
            house.Items.Add("13");
            house.Items.Add("14");
            house.Items.Add("15");
            house.Items.Add("16");
            house.Items.Add("17");
            house.Items.Add("18");
            house.Items.Add("19");
            house.Items.Add("20");
            house.Items.Add("21");
            house.Items.Add("22");
            house.Items.Add("23");
            house.Items.Add("24");
            house.Items.Add("25");
            house.Items.Add("26");
            house.Items.Add("27");
            house.Items.Add("28");
            house.Items.Add("29");
            house.Items.Add("30");
            house.Items.Add("31");
            house.Items.Add("32");
            house.Items.Add("33");
            house.Items.Add("34");
            house.Items.Add("35");
            house.Items.Add("36");
            house.Items.Add("37");
            house.Items.Add("38");
            house.Items.Add("39");
            house.Items.Add("40");
            house.Items.Add("41");
            house.Items.Add("42");
            house.Items.Add("43");
            house.Items.Add("44");
            house.Items.Add("45");
            house.Items.Add("46");
            house.Items.Add("47");
            house.Items.Add("48");
            house.Items.Add("49");
            house.Items.Add("50");
            house.Items.Add("51");
            house.Items.Add("52");
            house.Items.Add("53");
            house.Items.Add("54");
            house.Items.Add("55");
            house.Items.Add("56");
            house.Items.Add("57");
            house.Items.Add("58");
            house.Items.Add("59");
            house.Items.Add("60");
            house.Items.Add("61");
            house.Items.Add("62");
            house.Items.Add("63");
            house.Items.Add("64");
            house.Items.Add("65");
            house.Items.Add("66");
            house.Items.Add("67");
            house.Items.Add("68");
            house.Items.Add("69");
            house.Items.Add("70");
            house.Items.Add("71");
            house.Items.Add("72");
            house.Items.Add("73");
            house.Items.Add("74");
            house.Items.Add("75");
            house.Items.Add("76");
            house.Items.Add("77");
            house.Items.Add("78");
            house.Items.Add("79");
            house.Items.Add("80");
            house.Items.Add("81");
            house.Items.Add("82");
            house.Items.Add("83");
            house.Items.Add("84");
            house.Items.Add("85");
            house.Items.Add("86");
            house.Items.Add("87");
            house.Items.Add("88");
            house.Items.Add("89");
            house.Items.Add("90");
            house.Items.Add("91");
            house.Items.Add("92");
            house.Items.Add("93");
            house.Items.Add("94");
            house.Items.Add("95");
            house.Items.Add("96");
            house.Items.Add("97");
            house.Items.Add("98");
            house.Items.Add("99");
            house.Items.Add("100");


        }





        public void Clear()
        {

            textBox1.Clear();
            textBox2.Clear();

            textBox5.Clear();

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
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form1 aa = new Form1();
            aa.Show();
        }


        private void Register2_Load(object sender, EventArgs e)
        {
            disp_data();
            gender.Items.Add("MALE");
            gender.Items.Add("FEMALE");
            House();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Admin aa = new Admin();
            aa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("FIRSTNAME MUST BE ENTERED!");

            }

            else if ((gender.Text).ToString() == "")
            {
                MessageBox.Show("A GENDER MUST BE SELECTED!");
            }
            else if ((house.Text).ToString() == "")
            {
                MessageBox.Show("A HOUSE MUST BE SELECTED!");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    string g;
                    g = gender.Text;

                    String h;
                    h = house.Text;

                    String Time = DateTime.Now.ToString("h:mm:ss tt");
                    String Date = DateTime.Today.ToString("dd-mm-yyyy");
                    String Yes = "IN";
                    String Empty = "-";

                    cmd.CommandText = "Insert into Registered(Firstname, Lastname, Gender, House, MobileNo,TimeIn,DateIn,Context,TimeOut,DateOut) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + g + "', '" + h + "', '" + textBox5.Text + "',  '" + Time + "', '" + Date + "', '" + Yes + "','" + Empty + "','" + Empty + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Signed In Successfully");
                    disp_data();
                    Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}


