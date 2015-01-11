using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class SystemLogView
    {
        public int ID { get; set; }

        public int EventTypeID { get; set; }

        public string EventType { get; set; }

        public int UserID { get; set; }

        public DateTime? Date { get; set; }

        public string Message { get; set; }
    }
}