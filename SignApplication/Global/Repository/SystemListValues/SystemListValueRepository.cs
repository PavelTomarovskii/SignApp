using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.SystemListValues
{
    public class SystemListValueRepository : ISystemListValueRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<SystemListValue> SystemListValues
        {
            get
            {
                return context.SystemListValues;
            }
        }

        public void CreateSystemListValue(SystemListValue aSystemListValue)
        {
            context.SystemListValues.Add(aSystemListValue);
            context.SaveChanges();
        }

        public SystemListValue GetSystemListValue(int aID)
        {
            return context.SystemListValues.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateSystemListValue(SystemListValue aSystemListValue)
        {
            context.SystemListValues.Attach(aSystemListValue);
            var entry = context.Entry(aSystemListValue);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteSystemListValue(SystemListValue aSystemListValue)
        {
            aSystemListValue.IsDelete = true;
            context.SystemListValues.Attach(aSystemListValue);
            var entry = context.Entry(aSystemListValue);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}