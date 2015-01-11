using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;

namespace SignApplication.Global.Repository.ContentTypes
{
    public interface IContentTypeRepository
    {
        IQueryable<ContentType> ContentTypes { get; }
        void CreateContentType(ContentType aContentType);
        ContentType GetContentTemplate(int aID);
        bool UpdateContentType(ContentType aContentType);
        bool DeleteContentType(ContentType aContentType);
    }
}