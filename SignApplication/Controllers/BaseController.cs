using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Authentication;
using SignApplication.Global.Repository;
using SignApplication.Model;

namespace SignApplication.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        public BaseController()
        {
            //if (!IsAuthenticated())
            //{
            //    Response.Redirect("~/Login/Index");
            //}
        }

        public BaseController(bool IsCheckAuth)
        {
            //if (IsCheckAuth)
            //{
            //    if (!IsAuthenticated())
            //    {
            //        Response.Redirect("~/Login/Index");
            //    }
            //}
        }

        private bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

    }
}
