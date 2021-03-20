using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class MoreDeteils
    {
        List<Detail> arr = new List<Detail>();

        public MoreDeteils(List<Detail> arr)
        {
            this.arr = arr;
        }
        public MoreDeteils()
        { }

        public Detail item { get; set; }
    }
}