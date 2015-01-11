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
            Request req = context.Requests.FirstOrDefault(x => x.ID == aRequest.ID);
            if (req != null)
            {
                req = aRequest;
            }
            context.Entry(req).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteRequest(Request aRequest)
        {
            Request req = context.Requests.FirstOrDefault(x => x.ID == aRequest.ID);
            if (req != null)
            {
                req.IsDelete = true;
            }
            context.Entry(req).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}