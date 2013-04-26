using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GP.Model
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        public string TrackName { get; set; }

        public string VenueName { get; set; }

        public string Event { get; set; }

        public double Length { get; set; }

        public string Region { get; set; }

        
        //public int Category

    }
}
