using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CustomFramework.Resources;


namespace CustomFramework.Security.Membership.Model
{

    public partial class User : ModelBase
    {
     

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserFirstNameRequired", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(20)]
        [Display(Name="FirstName", ResourceType = typeof(LabelRes))]
        public string FirstName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserLastNameRequired", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(40)]
        [Display(Name="LastName", ResourceType = typeof(LabelRes))]
        public string LastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(10)]
        [Display(Name = "UserName", ResourceType = typeof(LabelRes))]        
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(100)]
        [Display(Name = "Password", ResourceType = typeof(LabelRes))]
        public string Password { get; set; }


        [Display(Name="Picture", ResourceType = typeof(LabelRes))]
        public byte[] Picture { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}
