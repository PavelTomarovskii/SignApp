using System;
using System.Linq;
using SignApplication.Model;

namespace SignApplication.Global.Repository
{
    public partial class Repository
    {
        public IQueryable<User> Users { get; set; }

        public User GetUser(int aID)
        {
            return context.Users.FirstOrDefault(x => x.ID == aID);
        }

        public User GetUser(string aEmail)
        {
            return context.Users.FirstOrDefault(x => x.EMail == aEmail);
        }

        public bool UpdateUser(User aUser)
        {
            throw new NotImplementedException();
        }

        public User Login(string aUserName, string aPassword)
        {
            return context.Users.FirstOrDefault(x => x.EMail == aUserName && x.Password == aPassword);
        }
    }
}
