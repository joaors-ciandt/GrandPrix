using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using CustomFramework.Security.Membership.Model;

namespace CustomFramework.Security.Membership
{
    public sealed class CustomAuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {            
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest); 
        }


        private void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                User user = (User)HttpContext.Current.Application["USER"];
                List<string> Roles = (from r in user.Roles select new { r.Name }.Name).ToList<string>();

                Dictionary<string, int> Permissions = new Dictionary<string, int>();

                foreach (var role in user.Roles)
                {
                    foreach (var permission in role.Permissions)
                    {
                        if (Permissions.ContainsKey(permission.Feature.Name))
                        {
                            if (Permissions[permission.Feature.Name] < (int)permission.AccessLevel)
                            {
                                Permissions[permission.Feature.Name] = (int)permission.AccessLevel;
                            }
                        }
                        else
                        {
                            Permissions.Add(permission.Feature.Name, (int)permission.AccessLevel);
                        }
                    }
                }
                HttpContext.Current.User = new CustomPrincipal(new CustomIdentity("Forms", user.UserName), Roles, Permissions);
            }

        }
    }
}