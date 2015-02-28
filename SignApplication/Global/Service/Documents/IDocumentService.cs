using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Global.Service.Documents
{
    public interface IDocumentService
    {
        IQueryable<DocumentView> GetDocuments(User aCurrentUser, string aDocFilePath);
        IQueryable<DocumentView> GetDocument(User aCurrentUser, int aDocumentID, string aDocFilePath, int aPage);
        IQueryable<ContentTemplateView> GetDocumentElements(int aDocumentID, int aPage);
        IQueryable<ContentTypeView> GetTemplateElements();

        ContentTemplateView UpdateDocumentElement(ContentTemplateView aElement);
        void UpdateDocument(DocumentView aDocument);
    }
}