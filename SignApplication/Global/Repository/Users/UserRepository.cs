using System;
using System.Linq;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<User> Users { get; set; }

        public void CreateUser(User aUser)
        {
            context.Users.Add(aUser);
            context.SaveChanges();
        }

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
            context.Users.Attach(aUser);
            var entry = context.Entry(aUser);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteUser(User aUser)
        {
            aUser.IsDelete = true;
            context.Users.Attach(aUser);
            var entry = context.Entry(aUser);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public User Login(string aUserName, string aPassword)
        {
            return context.Users.FirstOrDefault(x => x.EMail == aUserName && x.Password == aPassword);
        }
    }
}
