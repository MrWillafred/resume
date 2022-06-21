using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace nums_and_colors
{
    public partial class Form1 : Form
    {
        Graphics g, gg;

        int much;
        Random rnd = new Random();
        MyInt[] nums;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            gg = panel2.CreateGraphics();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(3, 251, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            button2.Enabled = true;

            textBox2.Text = "";
            label6.Text = "";
            label7.Text = "";

            much = Convert.ToInt32(textBox1.Text);
            nums = new MyInt[much];

            for (int i = 0; i < much; i++)
            {
                nums[i] = new MyInt(rnd.Next(0, 100));
            }

            //textBox2.Text = "Чувак, ты думал что-то здесь будет? Оооо нет.";

            Wok wok = new Wok();
            wok.Find(nums);
            wok.Draw(g);
            wok.Refr();
            wok.Draw(gg);
        }
    }
}
