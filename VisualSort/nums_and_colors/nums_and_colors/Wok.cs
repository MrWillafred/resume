using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nums_and_colors
{
    class Wok
    {
        ISortable[] array;
        ISortable min, max;

        public void Find(ISortable[] arr)
        {
            array = arr;

            min = array[0];
            max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Compare(max) > 0)
                    max = array[i];

                if (array[i].Compare(min) < 0)
                    min = array[i];
            }
        }

        public void Refr()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    if (array[i].Compare(array[j + 1]) > 0)
                    {
                        ISortable tea = array[i];
                        array[i] = array[j + 1];
                        array[j + 1] = tea;
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            int w = 502 / array.Length;
            int x = 502 / array.Length;

            if (w <= 0)
            {
                w = 1;
                x = 1;
            }

            int h = 40;

            for (int i = 0; i < array.Length; i++)
            {
                g.FillRectangle(new SolidBrush(array[i].GetColor(min, max)), x * i, 0, w, h);
            }

            
        }

    }
}
