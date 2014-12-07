using System.Security.Principal;
using Ninject;
using SignApplication.Global.Repository;
using SignApplication.Model;

namespace SignApplication.Global.Authentication
{
    public class UserIndentity : IIdentity, IUserProvider
    {

        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }

        public User User { get; set; }
        

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.EMail;
                }
                //иначе аноним
                return "anonym";
            }
        }

    }
}