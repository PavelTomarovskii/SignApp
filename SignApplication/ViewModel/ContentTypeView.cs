using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class ContentTypeView
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Class { get; set; }

        public bool IsDelete { get; set; }

        public float DefaultWidth { get; set; }

        public float DefaultHeight { get; set; }

        public string DefaultValue { get; set; }
    }
}