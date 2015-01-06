using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignApplication.Model;

namespace SignApplication.Global.Repository.Documents
{
    public interface IDocumentRepository
    {
        IQueryable<Document> Documents { get; }
        void CreateDocument(Document aDocument);
        Document GetDocument(int aID);
        bool UpdateDocument(Document aDocument);
        bool DeleteDocument(Document aDocument);
    }
}
