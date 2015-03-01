using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class RequestView
    {
        public int ID { get; set; }

        public int SenderID { get; set; }

        public DateTime? Date { get; set; }

        public int DocumentID { get; set; }

        public int StatusID { get; set; }

        public string Status { get; set; }
    }
}