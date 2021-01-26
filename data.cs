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
    public partial class data : Form
    {
        public data()
        {
            InitializeComponent();
        }

        private void data_Load(object sender, EventArgs e)
        {
            SaveData s = new SaveData();
            int k =s.getdata();
        }

         void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
