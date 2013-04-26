using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using CustomFramework.Resources;



namespace CustomFramework.Security.Membership.Model
{  
    public partial class Feature : ModelBase
    {     

        
        [Required(AllowEmptyStrings = false,  ErrorMessageResourceName="FeatureNameRequired", ErrorMessageResourceType=typeof(Messages))]
        [StringLength(50)]
        [Display(Name="Name", ResourceType=typeof(LabelRes))]
        public string Name { get; set; }


        public virtual List<Permission> Permissions { get; set; }


    }
}
