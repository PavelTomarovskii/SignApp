using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.RequestDocContents
{
    public class RequestDocContentRepository : IRequestDocContentRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<RequestDocContent> RequestDocContents
        {
            get
            {
                return context.RequestDocContents;
            }
        }

        public void CreateRequestDocContent(RequestDocContent aRequestDocContent)
        {
            context.RequestDocContents.Add(aRequestDocContent);
            context.SaveChanges();
        }

        public RequestDocContent GetRequestDocContent(int aID)
        {
            return context.RequestDocContents.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateRequestDocContent(RequestDocContent aRequestDocContent)
        {
            context.RequestDocContents.Attach(aRequestDocContent);
            var entry = context.Entry(aRequestDocContent);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteRequestDocContent(RequestDocContent aRequestDocContent)
        {
            aRequestDocContent.IsDelete = true;
            context.RequestDocContents.Attach(aRequestDocContent);
            var entry = context.Entry(aRequestDocContent);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}