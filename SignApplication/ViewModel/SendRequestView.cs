using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class RequestItemView
    {
        public int DocumentID { get; set; }

        public int UserID { get; set; }

        public List<Persons> Persons { get; set; }
    }

    public class Persons
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int UserID { get; set; }
    }
}