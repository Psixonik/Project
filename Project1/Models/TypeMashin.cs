using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class TypeMashin
    {
        public int id { get; set; }

        public string nameAuto { get; set; }//тип машины

        public string kyzov { set; get; }//тип кузова

        public int colKyzov { set; get; }//количество кузовов

        public string koleso { set; get; }//тип колес

        public int colKoleso { set; get; }//количество колес

        public string motor { set; get; }//тип мотора

        public int colMotor { set; get; }//количество моторов
    }
}