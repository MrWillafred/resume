using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon_Tech_Api.Tables
{
    public class User_Responses
    {
        public int Id { get; set; }
        public string? File { get; set; }
        public string? Text_Response { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
