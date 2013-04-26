using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomFramework.Enumerations;
using System.ComponentModel.DataAnnotations;
using CustomFramework.Resources;


namespace CustomFramework.Security.Membership.Model
{
    public partial class Permission : ModelBase
    {
     

        public virtual Feature Feature { get; set; }

        public virtual Role Role { get; set; }

        [Display(Name = "AccessLevel", ResourceType = typeof(LabelRes))]
        [Required(ErrorMessageResourceName = "AccessLevelRequired", ErrorMessageResourceType = typeof(Messages))]
        public int AccessLevel { get; set; }

        [Display(Name = "HierarchyLevel", ResourceType = typeof(LabelRes))]
        [Required(ErrorMessageResourceName = "HierarchyLevelRequired", ErrorMessageResourceType = typeof(Messages))]
        public int HierarchyLevel { get; set; }




        
        public RolePermissionType AccessLevelType
        {
            get
            {
                return (RolePermissionType)Enum.Parse(typeof(RolePermissionType), AccessLevel.ToString());
            }
            set
            {
                AccessLevel = (int)value;
            }
        }


  
        public HierarchyLevelAccess HierarchyLevelType
        {
            get
            {
                return (HierarchyLevelAccess)Enum.Parse(typeof(HierarchyLevelAccess), HierarchyLevel.ToString());
            }
            set
            {
                HierarchyLevel = (int)value;
            }
        }

    }
}
