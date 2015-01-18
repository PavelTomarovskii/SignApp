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
            context.ContentTemplates.Attach(aContentTemplate);
            var entry = context.Entry(aContentTemplate);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteContentTemplate(ContentTemplate aContentTemplate)
        {
            aContentTemplate.IsDelete = true;
            context.ContentTemplates.Attach(aContentTemplate);
            var entry = context.Entry(aContentTemplate);
            entry.State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}