using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace xXx_Coursework_zZz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 hh = new Form1();
            hh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Regis hi = new Regis();
            hi.Show();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllText("txt228.txt"));
        }

        private Button _button;
        private void button_MouseEnter(object sender, EventArgs e)
        {
            _button = (Button)sender;
            _button.ForeColor = Color.White;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            _button.ForeColor = Color.Black;
        }
    }
}
