using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon_Tech_Api.Tables
{
    public class File_To_Send
    {
        public int Id { get; set; }
        public string File { get; set; }
        public int File_TopicsId { get; set; }
        public File_Topics File_Topics { get; set; }
        public int Send_OrderId { get; set; }
        public Send_Order Send_Order { get; set; }
    }
}
