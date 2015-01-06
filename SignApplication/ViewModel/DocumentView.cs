using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class DocumentView
    {

        public int ID { set; get; }

        public string Name { set; get; }

        public DateTime? UploadDate { set; get; }

        public bool IsDelete { set; get; }

        public int StateID { set; get; }

        public int UploadedFileID { get; set; }

    }
}