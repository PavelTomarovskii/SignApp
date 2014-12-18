using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignApplication.Controllers
{
    public class DocumentsController : Controller
    {
        //
        // GET: /Documents/

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileWrapper qqfile)
        {
            return Json(new { result = "ok", success = true });
        }

    }
}
