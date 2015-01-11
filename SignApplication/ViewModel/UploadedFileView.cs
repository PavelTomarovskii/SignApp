using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class UploadedFileView
    {
        public int ID { get; set; }

        public int GroupID { get; set; }

        public string Group { get; set; }

        public DateTime? UploadedDate { get; set; }

        public bool IsDelete { get; set; }

        public string FilePath { get; set; }

        public string ContentType { get; set; }

        public int UserID { get; set; }
    }
}