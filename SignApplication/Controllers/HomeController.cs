using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Repository;

namespace SignApplication.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        public ActionResult Index()
        {
            //var user = Repository.GetUser(1);


            var cookie = Request.Cookies["test_cookie"];


            return View();
        }

    }
}
