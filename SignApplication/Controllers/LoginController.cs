using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Model;

namespace SignApplication.Controllers
{
    public class LoginController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtEmail, string txtPassword, bool chkRememberMe = false)
        {
            // TODO : Validate it
            var user = Auth.Login(txtEmail, txtPassword, true);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

    }
}
