using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Global.Repository;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {

        public HomeController()
            :base(true)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
