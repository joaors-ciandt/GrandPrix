using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace GP.Model
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(20)]
        //[Display(Name = "Name", ResourceType = typeof(LabelRes))]
        public string Name { get; set; }



    }
}
