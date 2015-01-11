using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.SystemLogs
{
    public interface ISystemLogRepository
    {
        IQueryable<SystemLog> SystemLogs { get; }
        void CreateSystemLog(SystemLog aSystemLog);
        SystemLog GetSystemLog(int aID);
        bool UpdateSystemLog(SystemLog aSystemLog);
        bool DeleteSystemLog(SystemLog aSystemLog);
    }
}