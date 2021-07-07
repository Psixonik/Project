using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Bazaar
    {
        public int id { get; set; }//primary key

        public string name { get; set; }//Наименование детали ("Мотор для КРаЗ","Мотор для МАЗ")

        public string type { get; set; }//тип детали ("Кузов","колесо")

        public int money { get; set; }//стоимость
    }
}