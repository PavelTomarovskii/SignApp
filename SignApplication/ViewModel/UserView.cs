using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignApplication.ViewModel
{
    public class UserView
    {
        public int ID { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string PatronymicName { set; get; }

        public string EMail { set; get; }

        public string Password { set; get; }

        public bool IsDelete { set; get; }
    }
}