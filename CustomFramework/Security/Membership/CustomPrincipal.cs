using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace CustomFramework.Security.Membership
{
    public class CustomPrincipal : IPrincipal
    {
       private List<string> _roles;
        private CustomIdentity _identity;
        private Dictionary<string, int> _Permissions;

        public CustomPrincipal(CustomIdentity identity, List<string> roles, Dictionary<string, int> permissions)
        {
            this._identity = identity;
            this._roles = roles;
            this._Permissions = permissions;
        }

        public IIdentity Identity
        {
            get
            {
                return this._identity;
            }
        }

        public List<string> Roles
        {
            get
            {
                return this._roles;
            }
        }

        public Dictionary<string, int> Permissions
        {
            get
            {
                return this._Permissions;
            }
        }

        public bool IsInRole(string role)
        {
            return (from r in this.Roles where r == role select r).Count() > 0;
        }

        public bool HasPermission(string feature, int permissionLevel)
        {
            return (from r in this.Permissions where r.Key == feature && r.Value == permissionLevel select r).Count() > 0;
        }

        
    }
}
