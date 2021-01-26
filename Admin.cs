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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register2 aa = new Register2();
            aa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignOut2 aa = new SignOut2();
            aa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Today2 aa = new Today2();
            aa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Total2 aa = new Total2();
            aa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Watch aa = new Watch();
            aa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 aa = new Form1();
            aa.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account aa = new Account();
            aa.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            delacct ss = new delacct();
            ss.Show();
        }
    }
}
