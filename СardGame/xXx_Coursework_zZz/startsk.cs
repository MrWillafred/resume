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
    public partial class startsk : Form
    {
        public startsk()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinSize form = new WinSize();
            form.Show();

            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
