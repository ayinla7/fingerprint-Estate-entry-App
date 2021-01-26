using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlfredGardens
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Register aa = new Register();
            aa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SignOut aa = new SignOut();
            aa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

          
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
            Total aa = new Total();
            aa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Today aa = new Today();
            aa.Show();
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO LOG OUT?","CONFIRMATION",MessageBoxButtons.OKCancel ,MessageBoxIcon.Warning);
            if (res==DialogResult.OK)
            {
                this.Close();
                Form1 dd = new Form1();
                dd.Show();
            }
            else
            {

            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Register aa = new Register();
            aa.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Register aa = new Register();
            aa.Show();
        }
    }
}
