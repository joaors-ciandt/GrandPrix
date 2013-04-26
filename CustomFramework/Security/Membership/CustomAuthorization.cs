using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CustomFramework.Enumerations;

namespace CustomFramework.Security.Membership
{
    public class CustomAuthorizationAttribute : AuthorizeAttribute
    {

        private string _feature;
        private RolePermissionType _minimumPermissionLevel;

        public CustomAuthorizationAttribute(string Feature, RolePermissionType MinimumPermissionLevel)
        {
            _feature = Feature;
            _minimumPermissionLevel = MinimumPermissionLevel;
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {

            if (base.AuthorizeCore(httpContext))
            {
                if (httpContext.User != null && httpContext.User is CustomPrincipal)
                {
                    CustomPrincipal user = (CustomPrincipal)httpContext.User;
                    return (user.Permissions.ContainsKey(_feature) &&
                        user.Permissions[_feature] >= (int)_minimumPermissionLevel);
                }
                else
                    return true;
                
            }
            return false;
                
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);            
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {           
             base.OnAuthorization(filterContext);
        }

        protected override System.Web.HttpValidationStatus OnCacheAuthorization(System.Web.HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);           
        }
    }
}
