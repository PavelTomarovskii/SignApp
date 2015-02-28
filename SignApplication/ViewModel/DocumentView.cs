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

        public bool IsDelete { set; get; }

        public int StateID { set; get; }

        public bool IsReadyToSend { set; get; }

        public string State { get; set; }

        public int UploadedFileID { get; set; }

        public string DocFilePath { get; set; }

        public int PageCount { get; set; }

        public int Page { get; set; }

        public DateTime? UploadDate { get; set; }

        public string FileName { get; set; }

        public int UserID { get; set; }

    }
}