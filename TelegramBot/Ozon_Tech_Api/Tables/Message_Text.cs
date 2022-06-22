﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozon_Tech_Api.Tables
{
    public class Message_Text
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Send_OrderId { get; set; }
        public Send_Order Send_Order { get; set; }
    }
}
