using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace CustomFramework.Security.Membership
{
    public class CustomIdentity : IIdentity
    {
        private string _authenticationType;
        private bool _isAuthenticated;
        private string _name;

        public CustomIdentity(string authenticationType, string name)
        {
            this._authenticationType = authenticationType;
            this._name = name;
            this._isAuthenticated = (name != string.Empty);
        }


        public string AuthenticationType
        {
            get
            {
                return this._authenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this._isAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
}
