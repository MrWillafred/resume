using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Фигуры_2
{
    [Serializable]
    class Rectangle_1 : Figure
    {
        public override bool IsIn(int x, int y)
        {
            return false;
        }
        public Rectangle_1(int x, int y, int w, int h, Color fillcolor, Color linecolor) : base(x, y, w, h, fillcolor, linecolor) { }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(linecolor), x, y, w, h);
        }
    }
}
