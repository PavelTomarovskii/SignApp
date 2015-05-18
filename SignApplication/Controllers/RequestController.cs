using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ninject;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;
using SignApplication.Global.Service.Request;
using SignApplication.Model;
using SignApplication.ViewModel;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class RequestController : BaseController
    {

        [Inject]
        public IRequestService RequestService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public string CreateRequest(RequestItemView requestItem)
        {
            RequestService.SendRequest(requestItem);
            return null;
        }

        [HttpGet]
        public string GetPersons(string partEmail)
        {
            var per = RequestService.GetPersons(CurrentUser.ID, partEmail);
            var serializedObject = JsonConvert.SerializeObject(per);
            return serializedObject;
        }
    }
}
