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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home m = new Home();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarRegister n = new CarRegister();
            n.Show();
        }
    }
}
