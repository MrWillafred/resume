using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nums_and_colors
{
    class MyInt : ISortable
    {
        public int val;

        public MyInt(int val)
        {
            this.val = val;
        }

        public Color GetColor(ISortable min, ISortable max)
        {
            MyInt miintmax = (MyInt)max;
            MyInt miintmin = (MyInt)min;
            double xmax = miintmax.val;
            double xmin = miintmin.val;
            double d = (xmax - xmin) / 5;
            Color color = new Color();

            // сюда бы запихнуть сортировку цвета)))
            int c;

            for (int i = 0; i < 1; i++)
            {
                if (val >= (xmin) && val <= (xmin + d))
                {
                    c = Convert.ToInt32(255 * ((val - xmin) / d)); // к первой точке
                    color = Color.FromArgb(255, c, 0);
                }

                else if (val >= (xmin + d) && val <= (xmin + (2 * d)))
                {
                    c = Convert.ToInt32(255 * ((val - (xmin + d)) / d)); // ко второй
                    color = Color.FromArgb(255 - c, 255, 0);
                }

                else if (val >= (xmin + (2 * d)) && val <= (xmin + (3 * d)))
                {
                    c = Convert.ToInt32(255 * ((val - (xmin + 2 * d)) / d)); // к третьей
                    color = Color.FromArgb(0, 255, c);
                }

                else if (val >= (xmin + (3 * d)) && val <= (xmin + (4 * d)))
                {
                    c = Convert.ToInt32(255 * ((val - (xmin + 3 * d)) / d)); // к четвертой 
                    color = Color.FromArgb(0, 255 - c, 255);
                }

                else if (val >= (xmin + (4 * d)) && val <= (xmin + (5 * d)))
                {
                    c = Convert.ToInt32(255 * ((val - (xmin + 4 * d)) / d)); // к пятой
                    color = Color.FromArgb(c, 0, 255);
                }
            }

                return color;
        }

        public int Compare(ISortable b)
        {
            MyInt mib = (MyInt)b;
            return val - mib.val;
        }
    }
}
