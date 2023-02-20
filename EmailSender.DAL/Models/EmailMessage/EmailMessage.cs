using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DAL
{ 
    public class EmailMessage
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
