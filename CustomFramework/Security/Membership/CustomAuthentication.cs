using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Text;
using System.IdentityModel.Tokens;
using System.ServiceModel;


namespace CustomFramework.Security.Membership
{
    public class CustomAuthentication : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (SecurityHelper.ValidateUser(userName, password))                
                throw new FaultException("Erro ao validar usuário");
        }
    }
}
