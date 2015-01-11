using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.ContentTemplates
{
    public interface IContentTemplateRepository
    {
        IQueryable<ContentTemplate> ContentTemplates { get; }
        void CreateContentTemplate(ContentTemplate aContentTemplate);
        ContentTemplate GetContentTemplate(int aID);
        bool UpdateContentTemplate(ContentTemplate aContentTemplate);
        bool DeleteContentTemplate(ContentTemplate aContentTemplate);
    }
}