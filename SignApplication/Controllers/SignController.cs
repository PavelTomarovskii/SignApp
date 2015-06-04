using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SignApplication.Global.Repository.Documents;
using SignApplication.Global.Repository.RequestDocContents;
using SignApplication.Global.Repository.Requests;
using SignApplication.Global.Service.Crypto;
using SignApplication.Global.Service.Documents;
using SignApplication.Global.Service.Request;

namespace SignApplication.Controllers
{
    public class SignController : Controller
    {
        //
        // GET: /Sign/

        [Inject]
        public ICryptoService CryptoService { get; set; }

        [Inject]
        public IRequestRepository RequestRepository { get; set; }

        [Inject]
        public IDocumentRepository DocumentRepository { get; set; }

        [Inject]
        public IDocumentService DocumentService { get; set; }

        public ActionResult Sign(string aID)
        {
            aID = "CNJe0K4ZWSUrf9juhoK4ag==";
            var requestId = CryptoService.Decrypt(aID);
            var request = RequestRepository.GetRequest(Convert.ToInt32(requestId));
            //var document = DocumentRepository.GetDocument(request.DocumentID);
            //var content = DocumentService.GetDocumentElements(request.DocumentID, 1);
            return View(request.DocumentID);
        }



    }
}
