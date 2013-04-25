using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CustomFramework.Runtime;


namespace CustomFramework.Security.Membership
{
    public class SecurityHelper
    {

        public static bool ValidateUser(string userName, string password)
        {
            ICustomMembership objMembership = GetUserMembershipType();
            return objMembership.ValidateUser(userName, password);
        }

        public static List<string> GetRolesByUserName(string userName)
        {
            return null;
        }

        public static Dictionary<string, int> GetPermissions()
        {
            return null;
        }

        public static ICustomMembership GetUserMembershipType()
        {
            string assembly = ConfigurationManager.AppSettings["BusinessAssembly"];
            string type = ConfigurationManager.AppSettings["UserType"];
            return (ICustomMembership)AssemblyLoader.LoadAssembly(assembly, type);
        }



    }
}
