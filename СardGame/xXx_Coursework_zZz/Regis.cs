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
    public partial class Regis : Form
    {
        public Regis()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Regis_Load(object sender, EventArgs e)
        {
            label5.Text = Form1._scor_of_all.ToString();
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "вот сюда";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string a = Convert.ToString(textBox1.Text);
            var aa = new FileStream("txt228.txt",FileMode.Append);
            StreamWriter aaa = new StreamWriter(aa);

            aaa.Write(a + " " + Form1._scor_of_all.ToString());
            aaa.WriteLine(" ");

            aaa.Close();
            aa.Close();

            MessageBox.Show("готова!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "вот сюда";
            }
        }
    }
}
