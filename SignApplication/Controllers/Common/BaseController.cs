using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Authentication;
using SignApplication.Global.Repository;
using SignApplication.Model;

namespace SignApplication.Controllers.Common
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

        }

        public BaseController(bool IsCheckAuth)
        {

        }

        private bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

    }
}
