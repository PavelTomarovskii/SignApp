using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.SystemLogs
{
    public class SystemLogRepository : ISystemLogRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<SystemLog> SystemLogs
        {
            get
            {
                return context.SystemLogs;
            }
        }
        public void CreateSystemLog(SystemLog aSystemLog)
        {
            context.SystemLogs.Add(aSystemLog);
            context.SaveChanges();
        }

        public SystemLog GetSystemLog(int aID)
        {
            return context.SystemLogs.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateSystemLog(SystemLog aSystemLog)
        {
            SystemLog sysLog = context.SystemLogs.FirstOrDefault(x => x.ID == aSystemLog.ID);
            if (sysLog != null)
            {
                sysLog = aSystemLog;
            }
            context.Entry(sysLog).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteSystemLog(SystemLog aSystemLog)
        {
            SystemLog sysLog = context.SystemLogs.FirstOrDefault(x => x.ID == aSystemLog.ID);
            if (sysLog != null)
            {
                sysLog.IsDelete = true;
            }
            context.Entry(sysLog).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}