using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Authentication;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Global.Repository.Users;
using SignApplication.Model;

namespace SignApplication.Controllers.Common
{
    public class BaseController : Controller
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IAuthentication Auth { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        }

        private bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

    }
}
