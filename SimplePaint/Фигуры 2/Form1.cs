using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фигуры_2
{
    public partial class Form1 : Form
    {
        Graphics g;
        int numfig = 1;
        MFigures figures = new MFigures();
        Figure selectedfigure;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true); //дабы убрать мерцание
            UpdateStyles();

            g = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)//Прямоугольник
        {
            numfig = 1;
        }

        private void button2_Click(object sender, EventArgs e)//Кружок
        {
            numfig = 2;
        }

        private void button3_Click(object sender, EventArgs e)//Треугольник
        {
            numfig = 3;
        }
        int x1, y1;

        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
            foreach (Figure f in figures.mfigures)
            {
                f.Draw(g);
            }          
        }
        bool down = false;
        bool obj = false;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (obj)
            {
                if (down && selectedfigure != null)
                {
                    if (selectedfigure.choice)
                    {
                        selectedfigure.Resize(e.X, e.Y);
                    }
                    else
                    {
                        selectedfigure.Location(e.X, e.Y, x1, y1);
                    }
                }
            }
            else
            {
                if (down)
                {
                    if (numfig == 1)
                    {
                        Rectangle fig = new Rectangle(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);
                        fig.Draw(g);
                    }
                    if (numfig == 2)
                    {
                        Ellipse fig = new Ellipse(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);

                        fig.Draw(g);
                    }
                    if (numfig == 3)
                    {
                        Triangle fig = new Triangle(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);
                        fig.Draw(g);
                    }

                }
            }
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (obj)
            {
                obj = false;
                if (selectedfigure != null)
                {
                    figures.mfigures.Remove(figures.mfigures[figures.mfigures.Count - 1]);
                }
                selectedfigure = null;
                button8.Enabled = false;

            }
            else
            {
                button8.Enabled = true;
                obj = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedfigure == null) 
                return;
            figures.RemoveFigure(selectedfigure);
            figures.RemoveFigure(figures.mfigures[figures.mfigures.Count - 1]);
            figures.RemoveFigure(figures.mfigures[figures.mfigures.Count -1]);
            selectedfigure = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (selectedfigure != null) figures.RemoveFigure(figures.mfigures[figures.mfigures.Count - 1]);
            obj = false;
            button8.Enabled = false;
            selectedfigure = null;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                figures.Save(saveFileDialog1.FileName);
            }

            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                figures = MFigures.Restore(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                button5.BackColor = colorDialog1.Color;
            }

            if (obj && selectedfigure != null)
            {
                selectedfigure.fillcolor = colorDialog1.Color;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            down = true;
            if (obj && selectedfigure != null)
            {
                x1 -= selectedfigure.x;
                y1 -= selectedfigure.y;

                figures.RemoveFigure(figures.mfigures[figures.mfigures.Count - 1]);
                figures.RemoveFigure(figures.mfigures[figures.mfigures.Count - 1]);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;

            if (obj)
            {
                selectedfigure = figures.Hit(e.X, e.Y);
                if (selectedfigure == null)
                {
                    return;
                }
                Rectangle_1 re = new Rectangle_1(selectedfigure.x, selectedfigure.y, selectedfigure.w, selectedfigure.h, Color.Black, Color.Red);
                Rectangle ree = new Rectangle(selectedfigure.x + selectedfigure.w - 5, selectedfigure.y + selectedfigure.h - 5, 10, 10, Color.Red, Color.Red);
                re.Draw(g);
                ree.Draw(g);
                figures.AddFigure(re);
                figures.AddFigure(ree);
            }
            else
            {
                if (numfig == 1)
                {
                    Rectangle fig = new Rectangle(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);
                    fig.Draw(g);
                    figures.AddFigure(fig);
                }
                if (numfig == 2)
                {
                    Ellipse fig = new Ellipse(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);
                    fig.Draw(g);
                    figures.AddFigure(fig);
                }
                if (numfig == 3)
                {
                    Triangle fig = new Triangle(x1, y1, e.X - x1, e.Y - y1, colorDialog1.Color, Color.Black);
                    fig.Draw(g);
                    figures.AddFigure(fig);
                }
            }
        }
    }
}
