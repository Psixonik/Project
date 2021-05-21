using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Auto
    {
        public int id { get; set; }

        public int userId { get; set; }

        public string nameAuto { get; set;}

        public int services { get; set; }

        public int maxContent { get; set; }

        public int content { get; set; }

        public int broken { get; set; }
    }
}