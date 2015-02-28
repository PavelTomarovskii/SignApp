using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Global.Constants;
using SignApplication.Global.Mappers;
using SignApplication.Global.Repository.Documents;
using SignApplication.Global.Repository.SystemListValues;
using SignApplication.Global.Repository.UploadedFiles;
using SignApplication.Global.Service.Documents;
using SignApplication.Model;
using SignApplication.ViewModel;
using WebGrease.Css.Extensions;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : BaseController
    {

        [Inject]
        public IDocumentService DocumentService { get; set; }

        [Inject]
        public IFileService FileService { get; set; }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public string GetDocuments()
        {
            var docs = DocumentService.GetDocuments(CurrentUser, DocFilePath);
            var serializedObject = JsonConvert.SerializeObject(docs);
            return serializedObject;
        }

        [HttpGet]
        public string GetDocument(int documentID, int page)
        {
            var doc = DocumentService.GetDocument(CurrentUser, documentID, DocFilePath, page);
            var serializedObject = JsonConvert.SerializeObject(doc);
            return serializedObject;
        }

        [HttpGet]
        public string GetDocumentElements(int documentID, int page)
        {
            var doc = DocumentService.GetDocumentElements(documentID, page);
            var serializedObject = JsonConvert.SerializeObject(doc);
            return serializedObject;
        }

        public string GetTemplateElements()
        {
            var doc = DocumentService.GetTemplateElements();
            var serializedObject = JsonConvert.SerializeObject(doc);
            return serializedObject;
        }

        [HttpPost]
        public string UpdateDocumentElement(ContentTemplateView element)
        {
            var doc = DocumentService.UpdateDocumentElement(element);
            var serializedObject = JsonConvert.SerializeObject(doc);
            return serializedObject;
        }

        [HttpPost]
        public void UpdateDocument(DocumentView document)
        {
            DocumentService.UpdateDocument(document);
        }

    }
}
