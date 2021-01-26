using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AlfredGardens
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;

        DataTable dt;

        System.Windows.Forms.Timer timer = null;
        //   Timer timr = new Timer();

        MySqlConnection conn;
        string connString;
        MySqlConnection conned;
        string connedString; 

        public Form1()
        {
            connString = "SERVER = www.db4free.net; PORT=3306;DATABASE=testalfred;UID=testalfreduser;PASSWORD=testalfredpassword;";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(10000);

            InitializeComponent();
            t.Abort();
            this.time.Text = DateTime.Now.ToString();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Enabled = true;

        }
        
    public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.time.Text = DateTime.Now.ToString();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
        
        
        
        private void button2_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //public void Pinging()
        //{
        //    try
        //    {
        //        Ping myPing = new Ping();
        //        String host = "google.com";
        //        byte[] buffer = new byte[32];
        //        int timeout = 1000;
        //        PingOptions pingOptions = new PingOptions();
        //        PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
        //        return (reply.Status == IPStatus.Success);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
private void Form1_Load(object sender, EventArgs e)
        {
            this.username.KeyPress += Username_KeyPress;
             this.password.KeyPress += password_KeyPress;
            connected();
            button1.Hide();



            // Pinging();


            String Date = DateTime.Today.ToString("dd/mm/yyyy");
            //date.Text = Date;
           // String Time = DateTime.Now.ToString("h:mm:ss tt");
           // time.Text = Time;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((username.Text == "") && (password.Text == ""))
            {
                MessageBox.Show("PLEASE ENTER USERNAME AND PASSWORD!","LOG IN ERROR!",MessageBoxButtons.OK,MessageBoxIcon.Hand);

            }
            else if ((username.Text == ""))
            {
                MessageBox.Show("PLEASE ENTER USERNAME!", "LOG IN ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if ((password.Text == ""))
            {
                MessageBox.Show("PLEASE ENTER PASSWORD!", "LOG IN ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if ((username.Text.ToUpper() == "QMTECH") && (password.Text.ToUpper() == "KWAMXZDYN1596"))
                {
                    this.Hide();
                    Admin aa = new Admin();
                    aa.Show();

                }

                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "select Password from login where Username ='" + (username.Text).ToUpper() + "'";


                    String pass = (String)cmd.ExecuteScalar();
                    if (pass == password.Text.ToUpper())
                    {

                        /////////////
                        SqlConnection con1 = new SqlConnection();
                        con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

                        con1.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.Text;


                        String Time = DateTime.Now.ToString("h:mm:ss tt");
                        String Date = DateTime.Today.ToString("dd-mm-yyyy");


                        cmd1.CommandText = "Insert into Watch(Username,password,time,date) values('" + username.Text + "', '" + password.Text + "','" + Time + "', '" + Date + "')";
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                        MessageBox.Show("Successful", "LOG IN!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.Hide();
                        Main aa = new Main();
                        aa.Show();
                    }
                    else
                    {
                        MessageBox.Show("INCORRECT PASSWORD AND USERNAME!", "LOG IN ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
           
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
           

        }
         
        private void Username_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{ENTER}");
                e.Handled = true;
                //  e.SuppressKeyPress = true;
                password.Focus();
            }
        }
        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                button8.PerformClick();
            }
        }
        private void connected()
        {

            ///////// Open connextion

            //conn.Open();

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    label1.Text = "CONNECTED";
                    button1.Hide();
                }
                else
                {
                    label1.Text = "NOT CONNECTED";
                    button1.Show();
                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                label1.Text = "NOT CONNECTED 2";
                button1.Show();
            }
        }
        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connected();


        }
    }
    
}
