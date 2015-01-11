﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using Ninject;
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

        public IQueryable<DocumentView> GetDocuments(User aCurrentUser)
        {
            var ret = from document in DocumentRepository.Documents
                   where document.UserID == aCurrentUser.ID && !document.IsDelete
                   select new DocumentView()
                   {
                       ID = document.ID,
                       Name = document.Name,
                       IsDelete = document.IsDelete,
                       StateID = document.StateID
                   };
            return ret;
        }

        public IQueryable<DocumentView> GetDocument(User aCurrentUser, int aDocumentID, string aDocFilePath) // aDocFilePath передается из BaseController.DocFilePath
        {
            var ret = from document in DocumentRepository.Documents
                    join state in SystemListValueRepository.SystemListValues on document.StateID equals state.ID
                    join documentFile in UploadedFileRepository.UploadedFiles on document.UploadedFileID equals documentFile.ID
                    where document.ID == aDocumentID && document.UserID == aCurrentUser.ID && documentFile.GroupID == (int)enumUploadedFilesGroup.Document
                    select new DocumentView()
                    {
                        ID = document.ID,
                        Name = document.Name,
                        IsDelete = document.IsDelete,
                        StateID = document.StateID,
                        State = state.Title,
                        UploadedFileID = document.UploadedFileID,
                        DocFilePath = aDocFilePath + documentFile.UserID.ToString() + "/" + documentFile.FilePath
                    };
            return ret;
        }

        public IQueryable<ContentTemplateView> GetDocumentElements(int aDocumentID)
        {
            var ret = from element in ContentTemplateRepository.ContentTemplates
                    join content in SystemListValueRepository.SystemListValues on element.ContentID equals content.ID
                    where element.DocumentID == aDocumentID
                    select new ContentTemplateView()
                    {
                        ID = element.ID,
                        DocumentID = element.DocumentID,
                        ContentID = element.ContentID,

                        Height = element.Height,
                        Width = element.Width,
                        Left = element.Left,
                        Top = element.Top,
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



            return null;
        }
    }
}