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
            using (context)
            {
                context.Documents.Add(aDocument);
                context.SaveChanges();
            }
        }

        public Document GetDocument(int aID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocument(Document aDocument)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocument(Document aDocument)
        {
            throw new NotImplementedException();
        }
    }
}