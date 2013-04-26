using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomFramework.Security.Membership;
using CustomFramework.Enumerations;

namespace GP.WebSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [CustomAuthorization("Inicio", RolePermissionType.Read)]
        public ActionResult Welcome()
        {
            return View();
        }

    }
}
