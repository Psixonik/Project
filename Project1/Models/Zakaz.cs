using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Zakaz
    {
        

        public int id { get; set; }

        public string name { get; set; }

        public int col { get; set; }

        public decimal money { get; set; }

        public int typeMashiID { get; set; }
    }
}