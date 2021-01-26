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
    public partial class Today : Form
    {
     
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        private object house;

        public Today()
        {
            InitializeComponent();
        }
        public void Today_data()
        {
            

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlCommand cmd1 = con.CreateCommand();
            SqlCommand cmd2 = con.CreateCommand();
            SqlCommand cmd3 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd1.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmd3.CommandType = CommandType.Text;

            String Date = DateTime.Today.ToString("dd-MM-yyyy");
            String Yes = "IN";
            String No = "OUT";

            cmd.CommandText = "select * from Registered where DateIn ='"+Date+"'";
            cmd1.CommandText = "Select COUNT(*) from Registered where DateIn ='" + Date + "'";
            cmd2.CommandText = "Select COUNT(*) from Registered where DateIn ='" + Date + "' AND Context ='" + Yes + "'";
            cmd3.CommandText = "Select COUNT(*) from Registered where DateIn ='" + Date + "' AND Context ='" + No + "'";

            
            Int32 count1 = (Int32)cmd1.ExecuteScalar();
            Int32 count2 = (Int32)cmd2.ExecuteScalar();
            Int32 count3 = (Int32)cmd3.ExecuteScalar();

            total.Text = count1.ToString();
            totalin.Text = count2.ToString();
            totalout.Text = count3.ToString();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


           
        }
        private void Today_Load(object sender, EventArgs e)
        {
            hous.Hide();
            searcht.Hide();
            dateTimePicker1.Hide();
            Today_data();
            searchc.Items.Add("FIRST NAME");
            searchc.Items.Add("LAST NAME");
            searchc.Items.Add("GENDER");
            searchc.Items.Add("HOUSE");
            searchc.Items.Add("MOBILE NUMBER");
            
          //  searchc.Items.Add("DATE IN");
            searchc.Items.Add("CONTEXT");
            
           // searchc.Items.Add("DATE OUT");
            searchc.Items.Add("TYPE");


            
            


        }
        private void House()
        {            hous.Items.Add("FACILITY");
            hous.Items.Add("1");
            hous.Items.Add("2");
            hous.Items.Add("3");
            hous.Items.Add("4");
            hous.Items.Add("5");
            hous.Items.Add("6");
            hous.Items.Add("7");
            hous.Items.Add("8");
            hous.Items.Add("9");
            hous.Items.Add("10");
            hous.Items.Add("11");
            hous.Items.Add("12");
            hous.Items.Add("13");
            hous.Items.Add("14");
            hous.Items.Add("15");
            hous.Items.Add("16");
            hous.Items.Add("17");
            hous.Items.Add("18");
            hous.Items.Add("19");
            hous.Items.Add("20");
            hous.Items.Add("21");
            hous.Items.Add("22");
            hous.Items.Add("23");
            hous.Items.Add("24");
            hous.Items.Add("25");
            hous.Items.Add("26");
            hous.Items.Add("27");
            hous.Items.Add("28");
            hous.Items.Add("29");
            hous.Items.Add("30");
            hous.Items.Add("31");
            hous.Items.Add("32");
            hous.Items.Add("33");
            hous.Items.Add("34");
            hous.Items.Add("35");
            hous.Items.Add("36");
            hous.Items.Add("37");
            hous.Items.Add("38");
            hous.Items.Add("39");
            hous.Items.Add("40");
            hous.Items.Add("41");
            hous.Items.Add("42");
            hous.Items.Add("43");
            hous.Items.Add("44");
            hous.Items.Add("45");
            hous.Items.Add("46");
            hous.Items.Add("47");
            hous.Items.Add("48");
            hous.Items.Add("49");
            hous.Items.Add("50");
            hous.Items.Add("51");
            hous.Items.Add("52");
            hous.Items.Add("53");
            hous.Items.Add("54");
            hous.Items.Add("55");
            hous.Items.Add("56");
            hous.Items.Add("57");
            hous.Items.Add("58");
            hous.Items.Add("59");
            hous.Items.Add("60");
            hous.Items.Add("61");
            hous.Items.Add("62");
            hous.Items.Add("63");
            hous.Items.Add("64");
            hous.Items.Add("65");
            hous.Items.Add("66");
            hous.Items.Add("67");
            hous.Items.Add("68");
            hous.Items.Add("69");
            hous.Items.Add("70");
            hous.Items.Add("71");
            hous.Items.Add("72");
            hous.Items.Add("73");
            hous.Items.Add("74");
            hous.Items.Add("75");
            hous.Items.Add("76");
            hous.Items.Add("77");
            hous.Items.Add("78");
            hous.Items.Add("79");
            hous.Items.Add("80");
            hous.Items.Add("81");
            hous.Items.Add("82");
            hous.Items.Add("83");
            hous.Items.Add("84");
            hous.Items.Add("85");
            hous.Items.Add("86");
            hous.Items.Add("87");
            hous.Items.Add("88");
            hous.Items.Add("89");
            hous.Items.Add("90");
            hous.Items.Add("91");
            hous.Items.Add("92");
            hous.Items.Add("93");
            hous.Items.Add("94");
            hous.Items.Add("95");
            hous.Items.Add("96");
            hous.Items.Add("97");
            hous.Items.Add("98");
            hous.Items.Add("99");
            hous.Items.Add("100");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
        private void copyAlltoClipboard()
        {
            if (dataGridView1.Rows.Count==1)
            {
            
                    MessageBox.Show("NO DATA TO COPY");
            
            }
            else
            {
                dataGridView1.SelectAll();
                DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                MessageBox.Show("COPIED");

            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
           
        }

        private void totalin_Click(object sender, EventArgs e)
        {

        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void searcht_Click(object sender, EventArgs e)
        {
            searcht.Text = "";
        }
        public void Clear() {
            
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void totalout_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searcht_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void searchb_Click(object sender, EventArgs e)
        {



            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");


            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            String k = searchc.Text;


            String s;
            String Date = DateTime.Today.ToString("dd-MM-yyyy");


            con1.Open();

            SqlCommand cmd1 = con1.CreateCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.Text;






            if (k == "")
            {
                MessageBox.Show("An Option Must be selected!");

            }
            else if(k == "FIRST NAME")
            {
                searcht.Show();
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";

                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND Firstname like'" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND Firstname like'" + t + "'";
                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: "+count1.ToString();

            }
            else if (k == "LAST NAME")
            {
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND Lastname like'" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND Lastname like'" + t + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "GENDER")
            {
                     
                    cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND Gender ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND Gender ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();

            }
            else if (k == "HOUSE")

            {
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND House ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND House ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "MOBILE NUMBER")
            {
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND MobileNo like'" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND MobileNo like'" + t + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }

            else if (k == "DATE IN")
            {
                String q = dateTimePicker1.Text;
                
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND DateIn ='" + q + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND DateIn ='" + q + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "CONTEXT")
            {

                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND Context ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND Context ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }

            else if (k == "DATE OUT")
            {
                String q = dateTimePicker1.Text;
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND DateOut ='" + q + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND DateOut ='" + q + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "TYPE")
            {
                
                cmd.CommandText = "select * from Registered where DateIn ='" + Date + "' AND Type ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + Date + "' AND Type ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            cmd1.ExecuteNonQuery();
            con1.Close();


            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
//hous.ResetText();
          
//hous.Hide();
//dateTimePicker1.Hide();
//searchb.Hide();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchc.Text == "GENDER")
            {
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select Gender";
                searcht.Hide();
                dateTimePicker1.Hide();
                hous.Items.Add("MALE");
                hous.Items.Add("FEMALE");

            }else if (searchc.Text == "HOUSE")
            {
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select House";
                searcht.Hide();
                dateTimePicker1.Hide();
                House();
            }
            else if (searchc.Text == "CONTEXT")
            {
                hous.Items.Clear();
                searcht.Hide();
                hous.Text = "Select Context";
                dateTimePicker1.Hide();
                hous.Show();
                hous.Items.Add("IN");
                hous.Items.Add("OUT");
            }
            else if (searchc.Text == "FIRST NAME")
            {
                searcht.Show();
                searcht.Tag = "Enter First Name";
                hous.Hide();
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "LAST NAME")
            {
                searcht.Show();
                hous.Hide();
                searcht.Tag = "Enter Last Name";
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "MOBILE NUMBER")
            {
                searcht.Show();
                hous.Hide();
                searcht.Tag = "Enter Mobile Number";
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "DATE IN")
            {
                dateTimePicker1.Show();
                searcht.Hide();

                hous.Hide();

            }
            else if (searchc.Text == "DATE OUT")
            {
                dateTimePicker1.Show();
                searcht.Hide();
                hous.Hide();
            }
            else if (searchc.Text == "TYPE")
            {
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select Type";
                hous.Items.Add("VISITOR");
                hous.Items.Add("STAFF");

                searcht.Hide();
                dateTimePicker1.Hide();
                
            }
        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
