using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xXx_Coursework_zZz
{
    public partial class WinSize : Form
    {
        public WinSize()
        {
            InitializeComponent();
        }

        private void WinSize_Load(object sender, EventArgs e)
        {

        }

        public static int _size;

        private void button1_Click(object sender, EventArgs e)
        {
            _size = 1;
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _size = 2;
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
