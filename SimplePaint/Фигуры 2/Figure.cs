using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Фигуры_2
{
    [Serializable]
    abstract class Figure
    {
        public int w;
        public int h;
        public int x;
        public int y;
        public Color fillcolor;
        public Color linecolor;

        [NonSerialized]
        public bool choice = false;

        public Figure()
        {
            w = 50;
            h = 50;
            fillcolor = Color.DarkRed;
            linecolor = Color.Black;
        }
        public Figure(int x, int y, int w, int h, Color fillcolor, Color linecolor)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.fillcolor = fillcolor;
            this.linecolor = linecolor;        
        }
        public abstract void Draw(Graphics g);

        public abstract bool IsIn(int x, int y);

        public void Resize(int x, int y)
        {
            w = x - this.x;
            h = y - this.y;
        }
        public void Location(int x, int y, int x1, int y1)
        {
            this.x = x - x1;
            this.y = y - y1;
        }

    }
    
}
