using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using Ninject;
using SignApplication.Global.Constants;
using SignApplication.Global.Repository.ContentTemplates;
using SignApplication.Global.Repository.ContentTypes;
using SignApplication.Global.Repository.Documents;
using SignApplication.Global.Repository.SystemListValues;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Model;
using SignApplication.ViewModel;
using SignApplication.Controllers.Common;

namespace SignApplication.Global.Service.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly int DefaultZindex = 100;

        [Inject]
        public IDocumentRepository DocumentRepository { get; set; }
        [Inject]
        public ISystemListValueRepository SystemListValueRepository { get; set; }
        [Inject]
        public IUploadedFileRepository UploadedFileRepository { get; set; }
        [Inject]
        public IContentTemplateRepository ContentTemplateRepository { get; set; }
        [Inject]
        public IContentTypeRepository ContentTypeRepository { get; set; }
        [Inject]
        public IFileService FileService { get; set; }

        public IQueryable<DocumentView> GetDocuments(User aCurrentUser, string aDocFilePath)
        {
            var ret = from document in DocumentRepository.Documents
                      join state in SystemListValueRepository.SystemListValues on document.StateID equals state.ID
                      join documentFile in UploadedFileRepository.UploadedFiles on document.ID equals documentFile.DocumentID
                      where document.UserID == aCurrentUser.ID && !document.IsDelete && documentFile.GroupID == (int)enumUploadedFilesGroup.SmallPage
                         && documentFile.Page == 1
                      select new DocumentView()
                      {
                          ID = document.ID,
                          Name = document.Name,
                          IsDelete = document.IsDelete,
                          StateID = document.StateID,
                          State = state.Title,
                          UploadDate = document.UploadDate,
                          DocFilePath = aDocFilePath + "/" + aCurrentUser.ID.ToString() + "/" + document.ID + "/" + FileService.SmallFilesPath + "/" + documentFile.FileName,
                          PageCount = document.PageCount,
                          UserID = document.UserID
                      };
            return ret;
        }

        public IQueryable<DocumentView> GetDocument(User aCurrentUser, int aDocumentID, string aDocFilePath, int aPage) // aDocFilePath передается из BaseController.DocFilePath
        {
            var path = FileService.GetFilesDirectory(enumUploadedFilesGroup.LargePage, aDocFilePath, aCurrentUser.ID, aDocumentID);
            var ret = from document in DocumentRepository.Documents
                    join state in SystemListValueRepository.SystemListValues on document.StateID equals state.ID
                    join documentFile in UploadedFileRepository.UploadedFiles on document.ID equals documentFile.DocumentID
                    where document.ID == aDocumentID && document.UserID == aCurrentUser.ID && documentFile.GroupID == (int)enumUploadedFilesGroup.LargePage
                        && documentFile.Page == aPage
                    select new DocumentView()
                    {
                        ID = document.ID,
                        Name = document.Name,
                        IsDelete = document.IsDelete,
                        StateID = document.StateID,
                        State = state.Title,
                        PageCount = document.PageCount,
                        Page = documentFile.Page,
                        UploadedFileID = documentFile.ID,
                        UserID = document.UserID,
                        UploadDate = document.UploadDate,
                        IsReadyToSend = document.StateID == (int)enumDocumentState.ReadyToSend,
                        DocFilePath = path + "/" + documentFile.FileName
                    };
            return ret;
        }

        public IQueryable<ContentTemplateView> GetDocumentElements(int aDocumentID, int aPage)
        {
            var ret = from element in ContentTemplateRepository.ContentTemplates
                    join content in SystemListValueRepository.SystemListValues on element.ContentID equals content.ID
                    where element.DocumentID == aDocumentID && element.Page == aPage
                    select new ContentTemplateView()
                    {
                        ID = element.ID,
                        DocumentID = element.DocumentID,
                        ContentID = element.ContentID,
                        Page = element.Page,

                        Height = element.Height,
                        Width = element.Width,
                        Left = element.Left,
                        Top = element.Top,
                        Zindex = element.Zindex,
                        IsRequired = element.IsRequired,
                        Text = element.Text
                    };
            return ret;
        }

        public IQueryable<ContentTypeView> GetTemplateElements()
        {
            var ret = from elem in ContentTypeRepository.ContentTypes
                where !elem.IsDelete
                select new ContentTypeView()
                {
                    ID = elem.ID,
                    Title = elem.Title,
                    Class = elem.Class,
                    DefaultHeight = elem.DefaultHeight,
                    DefaultWidth = elem.DefaultWidth,
                    DefaultValue = elem.DefaultValue,
                    IsDelete = elem.IsDelete
                };
            return ret;
        }

        public ContentTemplateView UpdateDocumentElement(ContentTemplateView aElement)
        {
            var elem = new ContentTemplate()
            {
                ID = aElement.ID,
                ContentID = aElement.ContentID,
                DocumentID = aElement.DocumentID,
                Page = aElement.Page,
                Height = aElement.Height,
                Width = aElement.Width,
                Left = aElement.Left,
                Top = aElement.Top,
                Zindex = aElement.Zindex,
                Text = aElement.Text,
                IsDelete = aElement.IsDelete,
                IsRequired = aElement.IsRequired
            };
            if (elem.ID < 0)
            {
                var zindexes = from item in ContentTemplateRepository.ContentTemplates
                    where !item.IsDelete && item.DocumentID == elem.DocumentID
                    select item.Zindex;

                int zIndex = DefaultZindex;
                if (zindexes.Any())
                    zIndex = zindexes.Max() + 1;
                elem.Zindex = zIndex;

                ContentTemplateRepository.CreateContentTemplate(elem);
            }
            else
            {
                ContentTemplateRepository.UpdateContentTemplate(elem);
            }
            return new ContentTemplateView()
            {
                ID = elem.ID,
                DocumentID = elem.DocumentID,
                ContentID = elem.ContentID,
                Page = elem.Page,
                Height = elem.Height,
                Width = elem.Width,
                Left = elem.Left,
                Top = elem.Top,
                Zindex = elem.Zindex,
                IsRequired = elem.IsRequired,
                Text = elem.Text
            };
        }

        public void UpdateDocument(DocumentView aDocument)
        {
            var elem = new Document()
            {
                ID = aDocument.ID,
                IsDelete = aDocument.IsDelete,
                Name = aDocument.Name,
                PageCount = aDocument.PageCount,
                UploadDate = aDocument.UploadDate,
                UserID = aDocument.UserID
            };

            elem.StateID = aDocument.IsReadyToSend
                ? (int) enumDocumentState.ReadyToSend
                : (int) enumDocumentState.Edit;

            DocumentRepository.UpdateDocument(elem);
        }
    }
}