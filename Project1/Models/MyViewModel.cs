using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Models
{
    public class MyViewModel
    {
        public string SelectedOption { get; set; }
        public IEnumerable<SelectListItem> SelectOptions { get; set; }
    }
}