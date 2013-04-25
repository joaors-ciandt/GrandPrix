using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace GP.Model
{
    public class Lap
    {
        [Key]
        public int Id { get; set; }


        public int LapTime { get; set; }

        public string FormattedLapTime { get; set; }




    }
}
