using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomFramework.Enumerations
{
    public enum RolePermissionType
    {
        None = 0,
        Read = 1,
        ReadWrite = 2,
        Full = 3
    }


    public enum HierarchyLevelAccess
    {
        None = 0,
        Ownership = 1,
        Hierarchy = 2,
        All = 3
    }

}
