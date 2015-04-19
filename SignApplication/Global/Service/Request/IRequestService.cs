using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Request
{
    public interface IRequestService
    {
        void SendRequest(RequestItemView aRequestItem);
        IQueryable<User> GetPersons(int aUserID, string aEmailPart);
    }
}
