using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;

namespace  AlfredGardens
{

    public partial class Signoutdetails : Form
    {
        public Signoutdetails myForm;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");



        
        public Signoutdetails()
        {
            InitializeComponent();
        }
        public void button3_Click(object sender, EventArgs e)
        {
            var SignOut = new SignOut(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            



        }
        public void disp_data()
        {
            

        }
        
        private void Signoutdetails_Load(object sender, EventArgs e)
        {
            disp_data();
       //     con.Open();
       //     SqlCommand cmd = new SqlCommand();
       //     cmd.CommandText = "Select picture from Registered where id ='" +textBox16.Text.ToString()+ "'";

       //     SqlDataReader dr;
       //     SqlParameter picture;
       //     SqlDataAdapter sda = new SqlDataAdapter(cmd);
       //     SqlCommandBuilder scb = new SqlCommandBuilder(sda);
       //     //DataTable dt;
       //     DataSet ds = new DataSet();
       //     sda.Fill(ds);
       ////     cmd.ExecuteNonQuery();
       //     con.Close();

       //     byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
       //     MemoryStream ms = new MemoryStream(ap);
       //     pictureBox1.Image = Image.FromStream(ms);
       //     pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
       //     pictureBox1.BorderStyle = BorderStyle.Fixed3D;
       //     ms.Close();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //  disp_data();
         
            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home aa = new Home();
            aa.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

