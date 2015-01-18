using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.Requests
{
    public class RequestRepository : IRequestRepository
    {

        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<Request> Requests
        {
            get
            {
                return context.Requests;
            }
        }
        public void CreateRequest(Request aRequest)
        {
            context.Requests.Add(aRequest);
            context.SaveChanges();
        }

        public Request GetRequest(int aID)
        {
            return context.Requests.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateRequest(Request aRequest)
        {
            context.Requests.Attach(aRequest);
            var entry = context.Entry(aRequest);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteRequest(Request aRequest)
        {
            aRequest.IsDelete = true;
            context.Requests.Attach(aRequest);
            var entry = context.Entry(aRequest);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}