using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class RequestDocContentView
    {
        public int ID { get; set; }

        public int RequestID { get; set; }

        public int ContentTemplateID { get; set; }

        public string Value { get; set; } // либо 1/0; текст;id image
    }
}