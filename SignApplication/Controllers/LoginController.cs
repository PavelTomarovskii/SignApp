using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Authentication;
using SignApplication.Model;

namespace SignApplication.Controllers
{
    public class LoginController : BaseController
    {

        public LoginController()
            :base(false)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string email = Request.Form["Email"];
            string pass = Request.Form["Password"];

            var user = Auth.Login(email, pass, true);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        public void Test()
        {
            if (Request.IsAjaxRequest())
            {

            }
            

            
            //return Json(new { resultMessage = "Ваш комментарий добавлен успешно!" });
            Response.Write("testResponse");
            Response.End();
            
        }

    }
}
