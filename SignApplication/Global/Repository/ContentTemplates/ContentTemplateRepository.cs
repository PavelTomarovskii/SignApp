using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.ContentTemplates
{
    public class ContentTemplateRepository : IContentTemplateRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<ContentTemplate> ContentTemplates
        {
            get
            {
                return context.ContentTemplates;
            }
        }

        public void CreateContentTemplate(ContentTemplate aContentTemplate)
        {
            context.ContentTemplates.Add(aContentTemplate);
            context.SaveChanges();
        }

        public ContentTemplate GetContentTemplate(int aID)
        {
            return context.ContentTemplates.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateContentTemplate(ContentTemplate aContentTemplate)
        {
            ContentTemplate conTemp = context.ContentTemplates.FirstOrDefault(x => x.ID == aContentTemplate.ID);
            if (conTemp != null)
            {
                conTemp = aContentTemplate;
            }
            context.Entry(conTemp).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteContentTemplate(ContentTemplate aContentTemplate)
        {
            ContentTemplate conTemp = context.ContentTemplates.FirstOrDefault(x => x.ID == aContentTemplate.ID);
            if (conTemp != null)
            {
                conTemp.IsDelete = true;
            }
            context.Entry(conTemp).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}