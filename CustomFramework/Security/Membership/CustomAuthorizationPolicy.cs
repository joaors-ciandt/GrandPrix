using System;
using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.IdentityModel.Claims;

namespace CustomFramework.Security.Membership
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {

        private string _authorizationPolicyId;

        public CustomAuthorizationPolicy()
        {
            this._authorizationPolicyId = new Guid().ToString();
        }


        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            IIdentity identity = GetIdentityFromClient(evaluationContext);
            CustomIdentity Identity = new CustomIdentity(identity.AuthenticationType, identity.Name);

            evaluationContext.Properties["Principal"] = new CustomPrincipal(Identity, SecurityHelper.GetRolesByUserName(Identity.Name), SecurityHelper.GetPermissions());           
            return true;
        }

        private static IIdentity GetIdentityFromClient(EvaluationContext evaluationContext)
        {
            IIdentity identity = null;
            object propertyIdentities = null;

            if (!evaluationContext.Properties.TryGetValue("Identities", out propertyIdentities))
                throw new Exception("Nenhuma identidade foi encontrada.");

            IList<IIdentity> identities = propertyIdentities as IList<IIdentity>;

            if (identities != null && identities.Count > 0)
                identity = identities[0];

            return identity;
        }

        public ClaimSet Issuer
        {
            get
            {
                return ClaimSet.System;
            }
        }

        public string Id
        {
            get
            {
                return this._authorizationPolicyId;
            }
        }
    }
}
