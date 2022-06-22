using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ozon_Tech_Api.Tables
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
