using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ozon_Tech_Api.Tables;

namespace Ozon_Tech_Api
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public int Studet_Code { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StatusesId { get; set; }
        public Statuses Statuses { get; set; }
    }
}
    