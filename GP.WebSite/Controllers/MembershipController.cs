using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomFramework.Security.Membership;
using GP.Domain.Service;
using CustomFramework.Security.Membership.Model;
using System.Web.Security;
using CustomFramework.Enumerations;

namespace GP.WebSite.Controllers
{
    public class MembershipController : Controller
    {

        MembershipService service = new MembershipService();

        #region LogIn_LogOut

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DoLogin(User model)
        {

            var user = service.Login(model.UserName, model.Password);
            if (user != null)
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(model.UserName, false, 1);
                string encriptTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encriptTicket);
                Response.Cookies.Add(authCookie);
                HttpContext.Application.Add("USER", user);

                return RedirectToAction("Welcome", "home");
            }
            else
            {
                ModelState.AddModelError("", "Usuário ou Senha incorretos.");
                return View("Login", model);
            }
        }

        [AllowAnonymous]
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        #endregion

        #region FEATURE


        [CustomAuthorization("Funcionalidade", RolePermissionType.Read)]
        public ActionResult ListFeatures()
        {
            return View(service.ListFeatures());
        }



        [HttpPost]
        [CustomAuthorization("Funcionalidade", RolePermissionType.ReadWrite)]
        public ActionResult CreateFeature(Feature model)
        {
            service.CreateFeature(model);
            return RedirectToAction("ListFeatures");

        }

        [CustomAuthorization("Funcionalidade", RolePermissionType.ReadWrite)]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization("Funcionalidade", RolePermissionType.ReadWrite)]
        public ActionResult EditFeature(Feature model)
        {
            service.UpdateFeature(model);
            return RedirectToAction("ListFeatures");
        }

        [CustomAuthorization("Funcionalidade", RolePermissionType.ReadWrite)]
        public ActionResult EditFeature(int id)
        {
            return View(service.FindFeatureById(id));
        }



        [CustomAuthorization("Funcionalidade", RolePermissionType.Full)]
        public ActionResult DeleteFeature(int id)
        {
            service.DeleteFeature(id);
            return RedirectToAction("ListFeatures");
        }



        #endregion

        #region USER

        [CustomAuthorization("Usuario", RolePermissionType.Read)]
        public ActionResult ListUsers()
        {
            return View(service.ListUsers());
        }



        [HttpPost]
        [CustomAuthorization("Usuario", RolePermissionType.ReadWrite)]
        public ActionResult CreateUser(User model)
        {
            service.CreateUser(model);
            return RedirectToAction("ListUsers");

        }

        [CustomAuthorization("Usuario", RolePermissionType.ReadWrite)]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization("Usuario", RolePermissionType.ReadWrite)]
        public ActionResult EditUser(Feature model)
        {
            service.UpdateFeature(model);
            return RedirectToAction("ListFeatures");
        }

        [CustomAuthorization("Usuario", RolePermissionType.ReadWrite)]
        public ActionResult EditUser(int id)
        {
            return View(service.FindFeatureById(id));
        }



        [CustomAuthorization("Usuario", RolePermissionType.Full)]
        public ActionResult DeleteUser(int id)
        {
            service.DeleteFeature(id);
            return RedirectToAction("ListFeatures");
        }


        #endregion

        #region Perfil


        [CustomAuthorization("Perfil", RolePermissionType.Read)]
        public ActionResult ListRoles()
        {
            return View(service.ListRoles());

        }



        [HttpPost]
        [CustomAuthorization("Perfil", RolePermissionType.ReadWrite)]
        public ActionResult CreateRole(Role model)
        {
            //service.Createro();
            return RedirectToAction("ListRoles");

        }

        [CustomAuthorization("Perfil", RolePermissionType.ReadWrite)]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization("Perfil", RolePermissionType.ReadWrite)]
        public ActionResult EditRole(Role model)
        {
            //service.UpdateFeature(model);
            return RedirectToAction("ListRoles");
        }

        [CustomAuthorization("Perfil", RolePermissionType.ReadWrite)]
        public ActionResult EditRole(int id)
        {
            //return View(service.FindFeatureById(id));
            return View();
        }



        [CustomAuthorization("Perfil", RolePermissionType.Full)]
        public ActionResult DeleteRole(int id)
        {
            //service.DeleteFeature(id);
            return RedirectToAction("ListRoles");
        }

        #endregion


    }
}
