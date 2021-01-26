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
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
namespace AlfredGardens
{
    public partial class Total : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Total()
        {
            InitializeComponent();
        }
        public void Total_data()
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

            cmd.CommandText = "select * from Registered";
            cmd1.CommandText = "Select COUNT(*) from Registered ";
            cmd2.CommandText = "Select COUNT(*) from Registered where Context ='" + Yes + "'";
            cmd3.CommandText = "Select COUNT(*) from Registered where Context ='" + No + "'";

            Int32 count1 = (Int32)cmd1.ExecuteScalar();
            Int32 count2 = (Int32)cmd2.ExecuteScalar();
            Int32 count3 = (Int32)cmd3.ExecuteScalar();

            total1.Text = count1.ToString();
            totalin.Text = count2.ToString();
            totalout.Text = count3.ToString();

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Total_Load(object sender, EventArgs e)
        {
            Total_data();
            hous.Hide();
            searcht.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
           
            searchc.Items.Add("FIRST NAME");
            searchc.Items.Add("LAST NAME");
            searchc.Items.Add("GENDER");
            searchc.Items.Add("HOUSE");
            searchc.Items.Add("MOBILE NUMBER");

            searchc.Items.Add("DATE IN");
            searchc.Items.Add("CONTEXT");
            
            searchc.Items.Add("DATE OUT");
            searchc.Items.Add("TYPE");
            searchc.Items.Add("DATE IN RANGE");
            searchc.Items.Add("DATE OUT RANGE");


        }
        private void copyAlltoClipboard()
        {
            if (dataGridView1.Rows.Count == 1)
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE ALL DATA?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "DELETE Registered";

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                Total_data();
                MessageBox.Show("Deleted Sucessfully");
            }
        }

        private void totalin_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void total1_Click(object sender, EventArgs e)
        {

        }

        private void totalout_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
         ///   String Date = DateTime.Today.ToString("dd/mm/yyyy");


            con1.Open();

            SqlCommand cmd1 = con1.CreateCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.Text;





            if (k =="") {
                MessageBox.Show("An Option Must be selected!");

            }
            else if (k == "FIRST NAME")
            {
                searcht.Show();
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";
                cmd.CommandText = "select * from Registered where Firstname like'" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where Firstname like '" + t + "'";
                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();

            }
            else if (k == "LAST NAME")
            {
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";

                cmd.CommandText = "select * from Registered where Firstname like '" + t+ "'";
                cmd1.CommandText = "select COUNT(*) from Registered where Firstname like '" + t + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "GENDER")
            {

                cmd.CommandText = "select * from Registered where Gender ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where Gender ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();

            }
            else if (k == "HOUSE")

            {
                cmd.CommandText = "select * from Registered where House ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where House ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "MOBILE NUMBER")
            {
                String t = "%" + searcht.Text.ToString().ToUpper() + "%";
                cmd.CommandText = "select * from Registered where MobileNo like'" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where MobileNo like'" + t + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }

            else if (k == "DATE IN")
            {
                String q = dateTimePicker1.Value.ToString("dd-MM-yyyy"); ;

                cmd.CommandText = "select * from Registered where DateIn ='" + q + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn ='" + q + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "CONTEXT")
            {

                cmd.CommandText = "select * from Registered where Context ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where Context ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }

            else if (k == "DATE OUT")
            {
                String q = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "select * from Registered where DateOut ='" + q + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateOut ='" + q + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "TYPE")
            {

                cmd.CommandText = "select * from Registered where Type ='" + (hous.Text).ToUpper() + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where Type ='" + (hous.Text).ToUpper() + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "DATE IN RANGE")
            {
                String q = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                String t = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "select * from Registered where DateIn >= '" + q + "' AND DateIn <='" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateIn >= '" + q + "' AND DateIn <='" + t + "'";

                Int32 count1 = (Int32)cmd1.ExecuteScalar();
                count.Text = "Result: " + count1.ToString();
            }
            else if (k == "DATE OUT RANGE")
            {
                String q = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                String t = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                cmd.CommandText = "select * from Registered where DateOut >= '" + q + "' AND DateOut <= '" + t + "'";
                cmd1.CommandText = "select COUNT(*) from Registered where DateOut >= '" + q + "' AND DateOut <= '" + t + "'";

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


        }
        private void House()
        {
            hous.Items.Add("FACILITY");
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
        private void searchc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hous_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void searchc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (searchc.Text == "GENDER")
            {
                dateTimePicker2.Hide();
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select Gender";
                searcht.Hide();
                dateTimePicker1.Hide();
                hous.Items.Add("MALE");
                hous.Items.Add("FEMALE");

            }
            else if (searchc.Text == "HOUSE")
            {
                dateTimePicker2.Hide();
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select House";
                searcht.Hide();
                dateTimePicker1.Hide();
                House();
            }
            else if (searchc.Text == "CONTEXT")
            {
                dateTimePicker2.Hide();
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
                dateTimePicker2.Hide();
                searcht.Show();
                searcht.Tag = "Enter First Name";
                hous.Hide();
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "LAST NAME")
            {
                dateTimePicker2.Hide();
                searcht.Show();
                hous.Hide();
                searcht.Tag = "Enter Last Name";
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "MOBILE NUMBER")
            {
                dateTimePicker2.Hide();
                searcht.Show();
                hous.Hide();
                searcht.Tag = "Enter Mobile Number";
                dateTimePicker1.Hide();
            }
            else if (searchc.Text == "DATE IN")
            {
                dateTimePicker1.Show();
                searcht.Hide();
                dateTimePicker2.Hide();
                hous.Hide();

            }
            else if (searchc.Text == "DATE OUT")
            {
                dateTimePicker1.Show();
                searcht.Hide();
                dateTimePicker2.Hide();
                hous.Hide();
            }
            else if (searchc.Text == "TYPE")
            {
                hous.Items.Clear();
                hous.Show();
                hous.Text = "Select Type";
                hous.Items.Add("VISITOR");
                hous.Items.Add("STAFF");
                dateTimePicker2.Hide();
                searcht.Hide();
                dateTimePicker1.Hide();

            }
            else if (searchc.Text == "DATE IN RANGE")
            {
                dateTimePicker1.Show();
                dateTimePicker2.Show();
                searcht.Hide();

                hous.Hide();

            }
            else if (searchc.Text == "DATE OUT RANGE")
            {
                dateTimePicker1.Show();
                dateTimePicker2.Show();
                searcht.Hide();

                hous.Hide();

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO PRINT?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                Clsprint Print = new Clsprint(dataGridView1, "ALFRED GARDENS ESTATE DATABASE");
                Print.PrintForm();
            }







            ////Open the print dialog
            //PrintDialog printDialog = new PrintDialog();
            //PrintDocument printDocument = new PrintDocument();
            //printDialog.Document = printDocument;
            //printDialog.UseEXDialog = true;
            ////Get the document
            //_printDocument.PrintPage += new PrintPageEventHandler(dataGridView1);
            //_printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
            //gw = gridview;
            //_ReportHeader = ReportHeader;
            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //    printDocument.DocumentName = "Test Page Print";
            //    printDocument.Print();
            //}
            ///*
            //Note: In case you want to show the Print Preview Dialog instead of 
            //Print Dialog then comment the above code and uncomment the following code
            //*/

            ////Open the print preview dialog
            ////PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            ////objPPdialog.Document = printDocument1;
            ////objPPdialog.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
           
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select count(*) from Registered ";
            Int32 count1 = (Int32)cmd1.ExecuteScalar();
            button6.Text = count1.ToString();
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select count(*) from Import ";
            Int32 count2 = (Int32)cmd2.ExecuteScalar();

           // button6.Text = count2.ToString();
            cmd2.ExecuteNonQuery();


            String Firstname;
            String Lastname;
            String Gender;
            String House;
            String MobileNo;
            String TimeIn;
            String DateIn;
            String Context;
            String TimeOut;
            String DateOut;
            String Type;



            int count3 = count1 - count2;

            if (count1 == 0) {
                MessageBox.Show("Empty Data ");


            }
            else
            {
                for(int a = 1; a <= count2 ; a++)
                {

                    //Update
                    SqlCommand cm1 = con.CreateCommand(), cm2 = con.CreateCommand(), cm3 = con.CreateCommand(), cm4 = con.CreateCommand(), cm5 = con.CreateCommand(), cm6 = con.CreateCommand(), cm7 = con.CreateCommand(), cm8 = con.CreateCommand(), cm9 = con.CreateCommand(), cm10 = con.CreateCommand(), cm11 = con.CreateCommand(), cm12 = con.CreateCommand();
                    cm1.CommandType = CommandType.Text;
                    cm2.CommandType = CommandType.Text;
                    cm3.CommandType = CommandType.Text;
                    cm4.CommandType = CommandType.Text;
                    cm5.CommandType = CommandType.Text;
                    cm6.CommandType = CommandType.Text;
                    cm7.CommandType = CommandType.Text;
                    cm8.CommandType = CommandType.Text;
                    cm9.CommandType = CommandType.Text;
                    cm10.CommandType = CommandType.Text;
                    cm11.CommandType = CommandType.Text;
                    cm12.CommandType = CommandType.Text;

                    SqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.Text;

                    cm1.CommandText = "select Firstname from Registered where Id ='" + a + "'";
                    cm2.CommandText = "select Lastname from Registered where Id ='" + a + "'";
                    cm3.CommandText = "select Gender from Registered where Id ='" + a + "'";
                    cm4.CommandText = "select House from Registered where Id ='" + a + "'";
                    cm5.CommandText = "select MobileNo from Registered where Id ='" + a + "'";
                    cm6.CommandText = "select TimeIn from Registered where Id ='" + a + "'";
                    cm7.CommandText = "select DateIn from Registered where Id ='" + a + "'";
                    cm8.CommandText = "select Context from Registered where Id ='" + a + "'";
                    cm9.CommandText = "select TimeOut from Registered where Id ='" + a + "'";
                    cm10.CommandText = "select DateOut from Registered where Id ='" + a + "'";
                    cm11.CommandText = "select Type from Registered where Id ='" + a + "'";
                    cm12.CommandText = "select Firstname, Lastname, Gender, House, MobileNo,TimeIn,DateIn,Context,TimeOut,DateOut,Type from Registered where Id ='" + a + "'";


                    Firstname = (String)cm1.ExecuteScalar();
                    Lastname = (String)cm2.ExecuteScalar();
                    Gender = (String)cm3.ExecuteScalar();
                    House = (String)cm4.ExecuteScalar();
                    MobileNo = (String)cm5.ExecuteScalar();
                    TimeIn = (String)cm6.ExecuteScalar();
                    DateIn = (String)cm7.ExecuteScalar();
                    Context = (String)cm8.ExecuteScalar();
                    TimeOut = (String)cm9.ExecuteScalar();
                    DateOut = (String)cm10.ExecuteScalar();
                    Type = (String)cm11.ExecuteScalar();


                   
                    cmd4.CommandText = "Update Import set Firstname='" + Firstname + "',Lastname='" + Lastname + "',Gender='" + Gender + "',House='" + House + "',MobileNo='" + MobileNo + "',TimeIn='" + TimeIn + "',DateIn='" + DateIn + "',Context='" + Context + "',TimeOut='" + TimeOut + "',DateOut='" + DateOut + "' where (Id = '" + a + "')";


                    cm1.ExecuteNonQuery();
                    cm2.ExecuteNonQuery();
                    cm3.ExecuteNonQuery();
                    cm4.ExecuteNonQuery();
                    cm5.ExecuteNonQuery();
                    cm6.ExecuteNonQuery();
                    cm7.ExecuteNonQuery();
                    cm8.ExecuteNonQuery();
                    cm9.ExecuteNonQuery();
                    cm10.ExecuteNonQuery();
                    cm11.ExecuteNonQuery();

                    cmd4.ExecuteNonQuery();
                }
                for (int b = count2 + 1; b <= count1 ; b++)
                {
                    //Insert
                    SqlCommand cm1 = con.CreateCommand(), cm2 = con.CreateCommand(), cm3 = con.CreateCommand(), cm4 = con.CreateCommand(), cm5 = con.CreateCommand(), cm6 = con.CreateCommand(), cm7 = con.CreateCommand(), cm8 = con.CreateCommand(), cm9 = con.CreateCommand(), cm10 = con.CreateCommand(), cm11 = con.CreateCommand(), cm12 = con.CreateCommand();
                    cm1.CommandType = CommandType.Text;
                    cm2.CommandType = CommandType.Text;
                    cm3.CommandType = CommandType.Text;
                    cm4.CommandType = CommandType.Text;
                    cm5.CommandType = CommandType.Text;
                    cm6.CommandType = CommandType.Text;
                    cm7.CommandType = CommandType.Text;
                    cm8.CommandType = CommandType.Text;
                    cm9.CommandType = CommandType.Text;
                    cm10.CommandType = CommandType.Text;
                    cm11.CommandType = CommandType.Text;
                    cm12.CommandType = CommandType.Text;

                    SqlCommand cmd5 = con.CreateCommand();
                    cmd5.CommandType = CommandType.Text;

                    cm1.CommandText = "select Firstname from Registered where Id ='" + b + "'";
                    cm2.CommandText = "select Lastname from Registered where Id ='" + b + "'";
                    cm3.CommandText = "select Gender from Registered where Id ='" + b + "'";
                    cm4.CommandText = "select House from Registered where Id ='" + b + "'";
                    cm5.CommandText = "select MobileNo from Registered where Id ='" + b + "'";
                    cm6.CommandText = "select TimeIn from Registered where Id ='" + b + "'";
                    cm7.CommandText = "select DateIn from Registered where Id ='" + b + "'";
                    cm8.CommandText = "select Context from Registered where Id ='" + b + "'";
                    cm9.CommandText = "select TimeOut from Registered where Id ='" + b + "'";
                    cm10.CommandText = "select DateOut from Registered where Id ='" + b + "'";
                    cm11.CommandText = "select Type from Registered where Id ='" + b + "'";
                    cm12.CommandText = "select Firstname, Lastname, Gender, House, MobileNo,TimeIn,DateIn,Context,TimeOut,DateOut,Type from Registered where Id ='" + b + "'";


                    Firstname = (String)cm1.ExecuteScalar();
                    Lastname = (String)cm2.ExecuteScalar();
                    Gender = (String)cm3.ExecuteScalar();
                    House = (String)cm4.ExecuteScalar();
                    MobileNo = (String)cm5.ExecuteScalar();
                    TimeIn = (String)cm6.ExecuteScalar();
                    DateIn = (String)cm7.ExecuteScalar();
                    Context = (String)cm8.ExecuteScalar();
                    TimeOut = (String)cm9.ExecuteScalar();
                    DateOut = (String)cm10.ExecuteScalar();
                    Type = (String)cm11.ExecuteScalar();



                    cmd5.CommandText = "Insert into Import(Firstname, Lastname, Gender, House, MobileNo,TimeIn,DateIn,Context,TimeOut,DateOut,Type) values('" + Firstname + "', '" + Lastname + "', '" + Gender + "', '" + House + "', '" + MobileNo + "',  '" + TimeIn + "', '" + DateIn + "', '" + Context + "','" + TimeOut + "','" + DateOut + "','" + Type + "')";

                    cm1.ExecuteNonQuery();
                    cm2.ExecuteNonQuery();
                    cm3.ExecuteNonQuery();
                    cm4.ExecuteNonQuery();
                    cm5.ExecuteNonQuery();
                    cm6.ExecuteNonQuery();
                    cm7.ExecuteNonQuery();
                    cm8.ExecuteNonQuery();
                    cm9.ExecuteNonQuery();
                    cm10.ExecuteNonQuery();
                    cm11.ExecuteNonQuery();


                    cmd5.ExecuteNonQuery();

                }

            }
            

            MessageBox.Show("SucessFul");
            
            con.Close();
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Signoutdetails d = new Signoutdetails();
            d.textBox16.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            d.name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            d.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            d.textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            d.textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            d.textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            d.textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            d.textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            d.textBox8.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            d.textBox9.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
            d.textBox10.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            d.textBox11.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            d.textBox12.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();

           
            d.ShowDialog();
        }
    }
}
