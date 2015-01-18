using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class ContentTemplateView
    {
        public int ID { get; set; }

        public int DocumentID { get; set; }

        public int ContentID { get; set; }

        public string ContentType { get; set; }

        public float Left { get; set; }

        public float Top { get; set; }

        public int Zindex { get; set; }

        public float Width { get; set; }

        public float Height { get; set; }

        public string Text { get; set; }

        public bool IsRequired { get; set; }

        public bool IsDelete { get; set; }
    }
}