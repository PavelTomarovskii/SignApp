using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        [Inject]
        public SignAppContext context { get; set; }

        public IQueryable<Document> Documents
        {
            get
            {
                return context.Documents;
            }
        }

        public void CreateDocument(Document aDocument)
        {
            context.Documents.Add(aDocument);
            context.SaveChanges();
        }

        public Document GetDocument(int aID)
        {
            return context.Documents.FirstOrDefault(x => x.ID == aID);
        }

        public bool UpdateDocument(Document aDocument)
        {
            Document doc = context.Documents.FirstOrDefault(x => x.ID == aDocument.ID);
            if (doc != null)
            {
                doc = aDocument;
            }
            context.Entry(doc).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool DeleteDocument(Document aDocument)
        {
            Document doc = context.Documents.FirstOrDefault(x => x.ID == aDocument.ID);
            if (doc != null)
            {
                doc.IsDelete = true;
            }
            context.Entry(doc).State = System.Data.Entity.EntityState.Modified;
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}