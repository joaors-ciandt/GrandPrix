using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomFramework.Security.Membership;
using CustomFramework.Enumerations;

namespace GP.SiteBasic.Controllers
{
    public class HomeController : Controller
    {


        [CustomAuthorization("Inicio", RolePermissionType.Read)]
        public ActionResult Welcome()
        {
            ViewBag.Title = ((CustomPrincipal)User).Roles[0];

            return View();

        }
    }
}
