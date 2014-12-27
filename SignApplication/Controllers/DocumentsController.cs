using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignApplication.Global.Authentication;

namespace SignApplication.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : Controller
    {
        //
        // GET: /Documents/

        public ActionResult List()
        {
            return View();
        }

    }
}
