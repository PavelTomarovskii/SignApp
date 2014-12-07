using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SignApplication.Model;
using SignApplication.Model.DBConnection;

namespace SignApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //using (var ctx = new SignAppContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //{
            //    Document doc = ctx.Documents.FirstOrDefault(x => x.ID == 1);/*.Include(x => x.User);*/

            //    User user = ctx.Users.FirstOrDefault(x => x.ID == 1);

            //    //ctx.Entry(doc).Reference(x => x.User).Load();
            //    //User u = doc.User;
            //}
        }
    }
}