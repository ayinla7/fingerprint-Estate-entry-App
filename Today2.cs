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
    public partial class Today2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Today2()
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

            String Date = DateTime.Today.ToString("dd-mm-yyyy");
            String Yes = "IN";
            String No = "OUT";

            cmd.CommandText = "select * from Registered where DateIn ='" + Date + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin aa = new Admin();
            aa.Show();
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
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
        }

        private void Today2_Load(object sender, EventArgs e)
        {

        }
    }
}
