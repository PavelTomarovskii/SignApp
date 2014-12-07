using System.Linq;
using SignApplication.Model;

namespace SignApplication.Global.Repository
{
    public interface IRepository
    {
        #region Users
        IQueryable<User> Users { get; set; }
        User GetUser(int aID);
        User GetUser(string aEmail);
        bool UpdateUser(User aUser);
        User Login(string aUserName, string aPassword);
        #endregion



        
    }
}
