using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.SystemLists
{
    public interface ISystemListRepository
    {
        IQueryable<SystemList> SystemLists { get; }
        void CreateSystemList(SystemList aSystemList);
        SystemList GetSystemList(int aID);
        bool UpdateSystemList(SystemList aSystemList);
        bool DeleteSystemList(SystemList aSystemList);
    }
}