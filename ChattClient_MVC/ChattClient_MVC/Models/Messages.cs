using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChattClient_MVC.Models
{
    public class Messages
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}