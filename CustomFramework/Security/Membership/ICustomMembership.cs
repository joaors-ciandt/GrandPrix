using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomFramework.Security.Membership
{
    public interface ICustomMembership
    {
        bool ValidateUser(string userName, string password);
    }
}
