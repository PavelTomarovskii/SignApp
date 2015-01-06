using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignApplication.Controllers.Common;
using SignApplication.Global.Authentication;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class InfoController : BaseController
    {
        //
        // GET: /Info/

        public ActionResult Index()
        {
            return View();
        }

    }
}
