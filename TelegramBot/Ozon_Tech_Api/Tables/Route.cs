using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon_Tech_Api
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
