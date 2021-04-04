using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Money
    {
        public int id { get; set; }

        public int cash { get; set; }

        public int credit { get; set; }

        public int dayForCredit { get; set; }
    }
}