using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.SystemLists
{
    public class SystemListRepository : ISystemListRepository
    {
        [Inject]
        public SignAppContext context { get; set; }


        public IQueryable<SystemList> SystemLists
        {
            get
            {
                return context.SystemLists;
            }
        }
        public void CreateSystemList(SystemList aSystemList)
        {
            context.SystemLists.Add(aSystemList);
            context.SaveChanges();
        }

        public SystemList GetSystemList(int aID)
        {
            return context.SystemLists.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateSystemList(SystemList aSystemList)
        {
            context.SystemLists.Attach(aSystemList);
            var entry = context.Entry(aSystemList);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteSystemList(SystemList aSystemList)
        {
            aSystemList.IsDelete = true;
            context.SystemLists.Attach(aSystemList);
            var entry = context.Entry(aSystemList);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}