using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace nums_and_colors
{
    interface ISortable
    {
        Color GetColor(ISortable min, ISortable max);
        int Compare(ISortable b);
    }
}
