using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon_Tech_Api.Tables
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int File_To_SendId { get; set; }
        public File_To_Send File_To_Send { get; set; }
        public int Message_TextId { get; set; }
        public Message_Text Message_Text { get; set; }
    }
}
