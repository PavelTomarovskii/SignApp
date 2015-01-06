using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Global.Mappers;
using SignApplication.Global.Repository.Documents;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : BaseController
    {

        [Inject]
        public IDocumentRepository documentRepository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

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
            var docs = from document in documentRepository.Documents
                        where document.UserID == CurrentUser.ID && !document.IsDelete
                        select new DocumentView()
                        {
                            ID = document.ID,
                            Name = document.Name,
                            IsDelete = document.IsDelete,
                            StateID = document.StateID,
                            UploadDate = document.UploadDate,
                            UploadedFileID = document.UploadedFileID
                        };

            var serializedObject = JsonConvert.SerializeObject(docs);
            return serializedObject;
        }

    }
}
