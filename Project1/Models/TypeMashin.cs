using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class TypeMashin
    {
        public int Id { get; set; }

        public string NameAuto { get; set; }//тип машины

        public string Kyzov { set; get; }//тип кузова

        public int ColKyzov { set; get; }//количество кузовов

        public string Koleso { set; get; }//тип колес

        public int ColKoleso { set; get; }//количество колес

        public string Motor { set; get; }//тип мотора

        public int ColMotor { set; get; }//количество моторов
    }
}