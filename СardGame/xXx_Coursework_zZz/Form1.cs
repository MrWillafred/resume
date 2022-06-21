using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace xXx_Coursework_zZz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true); //дабы убрать мерцание

            UpdateStyles(); // чтобы вся шляпа сверху работала

        }

        Point LastPoint;
        private PictureBox currentPictureBox;
        int card_side = 1;



        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPictureBox.Left += e.X - LastPoint.X;
                currentPictureBox.Top += e.Y - LastPoint.Y; // перемещает картинку 
                currentPictureBox.Width = 266;
                currentPictureBox.Height = 400;
                Refresh();
            }

            Point between = new Point(e.X - LastPoint.X, e.Y - LastPoint.Y);
            float Score_dist = (float)Math.Sqrt(between.X * between.X + between.Y * between.Y);

        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y); // запоминает положение курсора
            currentPictureBox = (PictureBox)sender;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (WinSize._size == 1)
            {
                ClientSize = new Size(1280, 720);
            }

            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();

            pictureBox9.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();

            label12.Hide();
            label13.Hide();
            label15.Hide();

            label17.Hide();
            label18.Hide();
            label19.Hide();

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            this.Text = "Курсовая картоная игра";

        }

        int meme = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (WinSize._size == 2)
            {
                pictureBox1.Location = new Point(109, 741);
                pictureBox2.Location = new Point(216, 741);
                pictureBox3.Location = new Point(323, 741);
                pictureBox4.Location = new Point(430, 741);
                pictureBox5.Location = new Point(537, 741);
                pictureBox6.Location = new Point(644, 741);
            }

            if (WinSize._size == 1)
            {
                pictureBox1.Location = new Point(87, 592);
                pictureBox2.Location = new Point(172, 592);
                pictureBox3.Location = new Point(258, 592);
                pictureBox4.Location = new Point(344, 592);
                pictureBox5.Location = new Point(429, 592);
                pictureBox6.Location = new Point(515, 592);
            }

            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            pictureBox4.Show();
            pictureBox5.Show();
            pictureBox6.Show();

            whole = new List<string>();

            pictureBox1.Image = new Bitmap(RandImg());
            pictureBox2.Image = new Bitmap(RandImg());
            pictureBox3.Image = new Bitmap(RandImg());
            pictureBox4.Image = new Bitmap(RandImg());
            pictureBox5.Image = new Bitmap(RandImg());
            pictureBox6.Image = new Bitmap(RandImg());

            button1.Enabled = false;

            pictureBox8.Hide();
            label16.Hide();

            if (meme == 1)
            {
                pictureBox9.Show();
                label17.Show();

                button3.Enabled = true;
                button2.Enabled = true;

                meme = 2131;
            }
        }

        List<string> whole;
        private string RandImg()
        {
            Random rand = new Random();
            string path = Application.StartupPath + @"\cards\";
            string filename = rand.Next(1, 50).ToString();
            whole.Add(filename);
            Thread.Sleep(16);
            string End_str = (path + filename + ".jpg");
            return End_str;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (card_side == 1)
            {
                pictureBox1.Image = cards_aAa._0;
                pictureBox2.Image = cards_aAa._0;
                pictureBox3.Image = cards_aAa._0;
                pictureBox4.Image = cards_aAa._0;
                pictureBox5.Image = cards_aAa._0;
                pictureBox6.Image = cards_aAa._0;

                card_side = 0;
            }

            else if (card_side == 0)
            {
                string path = Application.StartupPath + @"\cards\";
                pictureBox1.Image = new Bitmap(path + whole[0] + ".jpg");
                pictureBox2.Image = new Bitmap(path + whole[1] + ".jpg");
                pictureBox3.Image = new Bitmap(path + whole[2] + ".jpg");
                pictureBox4.Image = new Bitmap(path + whole[3] + ".jpg");
                pictureBox5.Image = new Bitmap(path + whole[4] + ".jpg");
                pictureBox6.Image = new Bitmap(path + whole[5] + ".jpg");

                card_side = 1;
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            currentPictureBox = (PictureBox)sender;
            currentPictureBox.Width = 101;
            currentPictureBox.Height = 150;

        }

        Random rnd_stat = new Random();
        int rnd_stats;
        string[] file = File.ReadAllLines(Application.StartupPath + @"\source\inform_stats.txt", Encoding.Default);
        string[] file_stats = File.ReadAllLines(Application.StartupPath + @"\source\stats.txt", Encoding.Default);

        int hod = -1;
        int blala = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            blala = 1;

            label15.Hide();

            rnd_stats = rnd_stat.Next(0, 4);
            label7.Text = file[rnd_stats];
            label8.Text = file[rnd_stats] + ": ";

            //label13.Text = file_stats[rnd_stat.Next(0, 249)]; это честный бой, но характеристи силишком 
            // не сбалнсированны, поэтому прибегнем к генератору случайных чисел

            label13.Text = rnd_stat.Next(130, 399).ToString();

            label12.Show();
            label13.Show();

            button3.Enabled = false;

            hod++;
            if (hod % 6 == 0 && hod != 0)
            {
                button1.Enabled = true;

                pictureBox8.Show();
                label16.Show();
            }

            label9.Text = "-";

            pictureBox10.Show();
            label18.Show();

            pictureBox9.Hide();
            label17.Hide();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {

        }

        PictureBox this_boxn;

        string g_boxn;
        int g_box_ends;
        int _this_stat;
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (Cursor.Position.X >= pictureBox7.Location.X && Cursor.Position.Y >= pictureBox7.Location.Y && Cursor.Position.X <= pictureBox7.Location.X + 180 && Cursor.Position.Y <= pictureBox7.Location.Y + 270 && blala ==1)
            {
                PictureBox pbox = sender as PictureBox;//теперь pbox это именно тот бокс по которому кликали
                this_boxn = sender as PictureBox;
                g_boxn = pbox.Name;
                string g_box_end = g_boxn.Substring(g_boxn.Length-1);
                g_box_ends = Convert.ToInt32(g_box_end);
                g_box_ends--;
                _this_stat = Convert.ToInt32(whole[g_box_ends]);
                _this_stat = ((_this_stat - 1) * 5 + (rnd_stats));
                _this_stat = Convert.ToInt32(file_stats[_this_stat]);
                label9.Text = _this_stat.ToString();

                button4.Enabled = true;

                blala = 0;

                pictureBox11.Show();
                label19.Show();

                pictureBox10.Hide();
                label18.Hide();

            }
        }


        public static int _scor_of_all = 0;

        int _card_h = 0;
        private void button4_Click(object sender, EventArgs e)
        {

            label12.Hide();
            label13.Hide();

            int hit, death, a, b;

            _card_h = 1;

            a = Convert.ToInt32(label13.Text);
            b = Convert.ToInt32(label9.Text);

            if (a > b) // ты получил в лицо(
            {
                hit = ((a - b) / (a / 100))/2;
                death = Convert.ToInt32(label3.Text) - hit;

                if (death <= 0)
                {
                    this.Hide();
                    Form2 gg = new Form2();
                    gg.Show();

                }

                label3.Text = death.ToString();

                label15.Text = "-" + hit.ToString();
                label15.Show();
            }

            _scor_of_all++; 

            label11.Text = _scor_of_all.ToString();

            button4.Enabled = false;
            button3.Enabled = true;

            if (_card_h == 1)
            {
                this_boxn.Hide();
            }

            label7.Text = ".....";
            label9.Text = ".....";

            pictureBox9.Show();
            label17.Show();

            pictureBox11.Hide();
            label19.Hide();

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            label14.ForeColor = Color.White;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = Color.Black;
        }

    }

}
