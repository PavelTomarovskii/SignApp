using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.ContentTypes
{
    public class ContentTypeRepository : IContentTypeRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<ContentType> ContentTypes
        {
            get
            {
                return context.ContentTypes;
            }
        }
        public void CreateContentType(ContentType aContentType)
        {
            context.ContentTypes.Add(aContentType);
            context.SaveChanges();
        }

        public ContentType GetContentTemplate(int aID)
        {
            return context.ContentTypes.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateContentType(ContentType aContentType)
        {
            ContentType conType = context.ContentTypes.FirstOrDefault(x => x.ID == aContentType.ID);
            if (conType != null)
            {
                conType = aContentType;
            }
            context.Entry(conType).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteContentType(ContentType aContentType)
        {
            ContentType conType = context.ContentTypes.FirstOrDefault(x => x.ID == aContentType.ID);
            if (conType != null)
            {
                conType.IsDelete = true;
            }
            context.Entry(conType).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}