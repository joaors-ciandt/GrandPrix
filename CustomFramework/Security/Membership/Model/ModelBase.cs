﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.Security.Membership.Model
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
