using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Repository;
using SignApplication.Model;

namespace SignApplication.Global.Authentication
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        [Inject] 
        public IRepository repository;

        public string RequiredRole;
        public int YourCustomValue;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            if (httpContext.User.Identity.IsAuthenticated == false) return false;
            try
            {
                //User user = _db.Users.Include("UserRoles").Single(u => u.username == httpContext.User.Identity.Name);
                //return user.MemberOf(RequiredRole);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}