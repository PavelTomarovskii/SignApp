using SignApplication.Model;

namespace SignApplication.Global.Authentication
{
    interface IUserProvider
    {
        User User { get; set; }
    }
}
