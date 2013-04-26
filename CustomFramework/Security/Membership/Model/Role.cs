using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CustomFramework.Resources;


namespace CustomFramework.Security.Membership.Model
{
    public partial class Role : ModelBase
    {
       

        [Required(AllowEmptyStrings = false,  ErrorMessageResourceName="RoleNameRequired", ErrorMessageResourceType=typeof(Messages))]
        [StringLength(30)]
        [Display(Name="Name", ResourceType = typeof(LabelRes))]
        public string Name { get; set; }


        public virtual List<User> Users {get; set;}
        public virtual List<Permission> Permissions { get; set; }
    }
}
