using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public string CreateRequest(RequestItemView requestItem)
        {
            RequestService.SendRequest(requestItem);
            return null;
        }
    }
}
