using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon_Tech_Api.Tables
{
    public class File_Recommendations
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int File_To_SendId { get; set; }
        public File_To_Send File_To_Send { get; set; }
    }
}
