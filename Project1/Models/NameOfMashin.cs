using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class NameOfMashin
    {
        public int Id { get; set; }

        public string NameAuto { get; set; }//название

        public int Cost { get; set; }//цена

        public int Services { get; set; }//цена услуги

        public int Content { get; set; }//содержание

    }
}