using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.SystemListValues
{
    public interface ISystemListValueRepository
    {
        IQueryable<SystemListValue> SystemListValues { get; }
        void CreateSystemListValue(SystemListValue aSystemListValue);
        SystemListValue GetSystemListValue(int aID);
        bool UpdateSystemListValue(SystemListValue aSystemListValue);
        bool DeleteSystemListValue(SystemListValue aSystemListValue);
    }
}
