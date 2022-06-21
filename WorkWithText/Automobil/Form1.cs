using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automobil
{
    public partial class Form1 : Form
    {
        Graphics g;
        Brush b1;
        Pen p;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            StreamReader sr = new StreamReader("cars.txt", Encoding.Default);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                textBox1.Text += line + "\r\n";
            }
            sr.Close();

            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "cars.txt";

            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);

            aFile.Seek(0, SeekOrigin.End);

            sw.WriteLine(textBox2.Text.ToString()+ " " + textBox3.Text.ToString() + " " + textBox4.Text.ToString() + ",");
            sw.Close();

            textBox1.Text = "";

            StreamReader sr = new StreamReader("cars.txt", Encoding.Default);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                textBox1.Text += line + "\r\n";
            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button2.Enabled = false;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Сначала выведите на экран");
            }

            else
            {
                string s = textBox1.Text + " ";
                string s_new = "";
                int aki = 0;

                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == ' ' && s[i + 1] != ' ')
                    {
                        for (int l = i; l < s.Length - 1; l++)
                        {
                            if (aki == 0)
                            {
                                s_new += s[l + 1];

                                if (s[l] != ' ' && s[l + 1] == ' ' && l + 2 < s.Length)
                                {
                                    s_new += s[l + 2] + ".";
                                    s_new += "\r\n";
                                    aki = 2;
                                    break;
                                }
                            }
                        }
                        aki--;
                    }
                }
                textBox1.Text = s_new;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button2.Enabled = false;

            string s = textBox1.Text + " ";
            string s_new = "";
            int aki = 0;
            int ro = 0;
            string _s = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            for (int j = 0; j < 33; j++)
            {
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == ' ' && s[i + 1] != ' ')
                    {
                        for (int l = i; l < s.Length - 1; l++)
                        {
                            if (aki == 0)
                            {
                                if (s[l] != ' ' && s[l + 1] == ' ' && l + 2 < s.Length)
                                {
                                    if (s[l] != ' ' && s[l + 1] == ' ' && l + 2 < s.Length)
                                    {
                                        if (s[l + 2] == Convert.ToChar(_s[j]))
                                        {
                                            for (int gg = 0; gg< s.Length; gg++)
                                            {
                                                if (s[l - gg] >= 'A' && s[l - gg] <= 'Z')
                                                {
                                                    for (int g = 0; g < s.Length; g++)
                                                    {
                                                        s_new += s[l - gg + g];

                                                        if (s[l - gg + g + 1] == ',')
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                }
                                            }

                                            s_new += "\r\n";
                                        }
                                        aki = 2;
                                        break;
                                    }
                                }
                            }
                        }
                        aki--;
                    }
                }
            }

            textBox1.Text = s_new;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button2.Enabled = false;

            string s = textBox1.Text + " ";
            string ss = textBox5.Text;
            string s_new = "";
            string s_sb = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < ss.Length; j++)
                {
                    if (s.Length> i + j + 1 && s[i + j] == ss[j])
                    {
                        s_sb += s[i + j];
                    }
                }

                if (s_sb.Length != ss.Length)
                {
                    s_sb = "";
                }

                else
                {
                    for (int g = 0; g < s.Length; g++)
                    {
                        if (s[i + g ] == ' ')
                        {
                            for (int h = 0; h < s.Length; h++)
                            {
                                s_sb += s[i + g + h];

                                if (s[i + g + h] == ',')
                                {
                                    s_sb += "\r\n";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                s_new += s_sb;

                s_sb = "";
            }

            textBox1.Text = s_new;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
            button2.Enabled = false;

            string s = textBox1.Text + " ";
            string ss = textBox6.Text;
            string s_new = "";
            string s_sb = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < ss.Length; j++)
                {
                    if (s.Length > i + j + 1 && s[i + j] == ss[j])
                    {
                        s_sb += s[i + j];
                    }
                }

                if (s_sb.Length != ss.Length)
                {
                    s_sb = "";
                }

                else
                {
                    s_sb = "";

                    for (int g = 0; g < s.Length; g++)
                    {
                        if (s[i - g - 1] == ',' || i - g == 0)
                        {
                            for (int h = 1; h < s.Length; h++)
                            {
                                s_sb += s[i - g + h + 1];

                                if (s[i - g + h + 1] == ',')
                                {
                                    s_sb += "\r\n";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                s_new += s_sb;

                s_sb = "";
            }

            textBox1.Text = s_new;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = 0;
            string s = textBox1.Text + " ";
            string nams = "";
            int dad = -1;

            for (int _n = 0 ; _n < s.Length; _n++)
            {
                if (s[_n] == ',')
                {
                    n++;
                }
            }

            string[] crs = new string[n+1];
            string[,] cars = new string[n+1, 2];

            for (int i = 0; i < s.Length; i++)
            {
                nams = "";
                if (i == 0 || s[i - 1] == ',')
                {
                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        nams += s[i + j];

                        if (s[i + j + 1] == ' ')
                        {
                            dad++;
                            break;
                        }
                    }
                    crs[dad] = nams;
                }
            }

            string net = "";
            string ten = "";
            int aa, aaa;

            for (int i = 0; i < n ; i++)
            {
                net = crs[i];
                aaa = 0;

                for (int j = 0; j < n; j++)
                {
                    aa = 0;

                    ten = crs[j];

                    if (net.Length == ten.Length)
                    {
                        aa = 0;

                        for (int h = 0; h < ten.Length - 1; h++)
                        {
                            if  (ten[h] == net[h])
                            {
                                aa++;
                            }

                            if (aa == net.Length-1)
                            {
                                aaa++;
                            }
                        }

                        if (aaa == 1)
                        {
                            cars[i, 0] = net;
                        }

                        cars[i, 1] = aaa.ToString();
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                net = cars[i, 0];
                aaa = 0;

                for (int j = 0; j < n; j++)
                {
                    aa = 0;

                    ten = cars[j, 0];

                    if (net.Length == ten.Length)
                    {
                        aa = 0;

                        for (int h = 0; h < ten.Length - 1; h++)
                        {
                            if (ten[h] == net[h])
                            {
                                aa++;
                            }

                            if (aa == net.Length - 1)
                            {
                                aaa++;
                            }
                        }

                        if (aaa > 1)
                        {
                            cars[i, 0] = "";
                            cars[i, 1] = "";
                        }
                    }
                }
            }

            picture.Show();
            textBox7.Show();

            Bitmap bmp = new Bitmap(picture.Width, picture.Height);
            Graphics g = Graphics.FromImage(bmp);
            Brush b1 = new SolidBrush(Color.Red);
            int plus = 0;

            for (int i = 0; i < n; i++)
            {
                if (cars[i,0] != "")
                {
                    textBox7.Text += cars[i, 0] + "              ";
                    g.FillRectangle(b1, new Rectangle(1 + plus, 180 - Convert.ToInt32(cars[i,1])*10, 20, 200));
                    plus += 84 - cars[i,0].Length;
                }
            }

            picture.Image = bmp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picture.Hide();
            textBox7.Hide();

            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }
    }
}
