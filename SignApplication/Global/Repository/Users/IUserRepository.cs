using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.Users
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; set; }
        User GetUser(int aID);
        User GetUser(string aEmail);
        bool UpdateUser(User aUser);
        bool DeleteUser(User aUser);
        User Login(string aUserName, string aPassword);
    }
}
