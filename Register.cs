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

using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Data.SqlClient;
using AForge.Imaging.Filters;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


//using Excel = Microsoft.Office.Interop.Excel;


namespace AlfredGardens
{
    
    public partial class Register : Form
    {
        Guid name;
        int count = 0;
       // SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlParameter picture;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        public Register()
        {
            InitializeComponent();
        }
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice finalframe;

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        ////private void copyAlltoClipboard()
        ////{
        ////    dataGridView1.SelectAll();
        ////    DataObject dataObj = dataGridView1.GetClipboardContent();
        ////    if (dataObj != null)
        ////        Clipboard.SetDataObject(dataObj);
        ////    copyAlltoClipboard();
        ////    MessageBox.Show("Copied");


        ////}
        private void Type()
        {
           
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

     
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form1 aa = new Form1();
            aa.Show();
        }



       

        private void button2_Click_1(object sender, EventArgs e)
        {
            //this.Hide();
            //  Form aa = new Form();

            if (textBox1.Text == "")
            {
                MessageBox.Show("FIRSTNAME MUST BE ENTERED!");
           
            }
            else if ((type.Text).ToString() == "")
            {
                MessageBox.Show("A TYPE MUST BE SELECTED!");
            }

            else if ((gender.Text).ToString()=="")
            {
                MessageBox.Show("A GENDER MUST BE SELECTED!");
            }
            else if ((house.Text).ToString()== "")
            {
                MessageBox.Show("A HOUSE MUST BE SELECTED!");
            }
            else if (pictureBox2.Image == null)
            {
                MessageBox.Show("IMAGE MUST BE CAPTURED!");
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
                    h =house.Text;

                    String t;
                    t = type.Text;

                    String Time = DateTime.Now.ToString("h:mm:ss tt");
                    String Date = DateTime.Today.ToString("dd-MM-yyyy");
                    String Yes = "IN";
                    String Empty = "-";
                    ////////////////////////////////////////////////////////////////////////////
                    String path = Application.StartupPath + @"\Pictures\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        MessageBox.Show("Directory Created");
                    }
                    else
                    {
                        MessageBox.Show("Directory Already EXist");
                    }
                    if (pictureBox2.Image != null)
                    {
                        Bitmap v = new Bitmap(pictureBox2.Image);
                        String k = DateTime.Now.ToString();
                        name = Guid.NewGuid();

                        v.Save(Application.StartupPath + @"\Pictures\" + name + ".JPG", ImageFormat.Jpeg);

                        Bitmap nv = new Bitmap(v);
                        v.Dispose();
                        v = null;
                        MessageBox.Show("Image Saved");

                    }
                    else
                    {
                        MessageBox.Show("Null Image");
                    }
                    pictureBox2.Invalidate();
                    pictureBox2.Image = null;
                    pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\Pictures\" + name + ".JPG");

                    if (pictureBox2.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                        byte[] a = ms.GetBuffer();


                        ms.Close();
                       // cn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@picture", a);
                        cmd.Parameters.AddWithValue("@picname", name);
                        
                        cmd.CommandText = "Insert into Registered(Firstname, Lastname, Gender, House, MobileNo,TimeIn,DateIn,Context,TimeOut,DateOut,Type,picname,picture) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + g + "', '" + h + "', '" + textBox5.Text + "',  '" + Time + "', '" + Date + "', '" + Yes + "','" + Empty + "','" + Empty + "','" + t + "',@picname,@picture)";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = "";
                        pictureBox2.Image = null;

                        MessageBox.Show("Signed In Successfully");
                        //  disp_data();
                    }
                    Clear();
                    this.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (finalframe.IsRunning == true)
                {
                    finalframe.Stop();

                }
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
                pictureBox2.Image = null;
                pictureBox2.Invalidate();
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                if (comboBox1.SelectedIndex == -1)
                {
                    finalframe = new VideoCaptureDevice(CaptureDevice[0].MonikerString);
                }
                else
                {
                    finalframe = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);

                }

                finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_newFrame);
                finalframe.Start();


            }

        }
        //public void disp_data()
        //{

        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select * from Register";
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    sda.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    con.Close();
        //}
        void FinalFrame_newFrame(object Sender0, NewFrameEventArgs eventArgs)
        {
            // throw new NotImplementedException();
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe.IsRunning == true)
            {
                finalframe.Stop();

            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            

            type.Items.Add("VISITOR");
            type.Items.Add("STAFF");
                      gender.Items.Add("MALE");
            gender.Items.Add("FEMALE");
            House();
            Type();
        
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[A-Z]"))
            {
                MessageBox.Show("Please enter  only numbers!");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }

            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            finalframe = new VideoCaptureDevice(CaptureDevice[0].MonikerString);

            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_newFrame);
            finalframe.Start();



        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            if (finalframe.IsRunning == true)
            {
                finalframe.Stop();

            }
        }
      
        private void button4_Click(object sender, EventArgs e)
        {

          //  copyAlltoClipboard();
            //MessageBox.Show("Copied");
            //Microsoft.Office.Interop.Excel.Application xlexcel;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;
            //xlexcel = new Excel.Application();
            //xlexcel.Visible = true;
            //xlWorkBook = xlexcel.Workbooks.Add(misValue);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            //CR.Select();
            //xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void house_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           /// DGVPrinter printer = new DGVPrinter();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           

        }

        private void reset_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            pictureBox2.Image = null;
            pictureBox2.Invalidate();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            if (comboBox1.SelectedIndex == -1)
            {
                finalframe = new VideoCaptureDevice(CaptureDevice[0].MonikerString);
            }
            else
            {
                finalframe = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);

            }

            finalframe.NewFrame += new NewFrameEventHandler(FinalFrame_newFrame);
            finalframe.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe.IsRunning == true)
            {
                finalframe.Stop();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox2.Image = ((Bitmap)pictureBox1.Image.Clone());
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Register_Shown(object sender, EventArgs e)
        {
          

        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (finalframe.IsRunning == true)
            {
                finalframe.Stop();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

















        //    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
        //    app.Visible = true;
        //    worksheet = workbook.Sheets["Sheet1"];
        //    worksheet = workbook.ActiveSheet;
        //    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
        //    {
        //        worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
        //    }
        //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //    {
        //        for (int j = 0; j < dataGridView1.Columns.Count; j++)
        //        {
        //            if (dataGridView1.Rows[i].Cells[j].Value != null)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
        //            }
        //            else
        //            {
        //                worksheet.Cells[i + 2, j + 1] = "";
        //            }
        //        }
        //    }
        //}
    }

}