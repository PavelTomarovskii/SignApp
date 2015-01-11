using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.Requests
{
    public interface IRequestRepository
    {
        IQueryable<Request> Requests { get; }
        void CreateRequest(Request aRequest);
        Request GetRequest(int aID);
        bool UpdateRequest(Request aRequest);
        bool DeleteRequest(Request aRequest);
    }
}