using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Bazaar
    {
        public int Id { get; set; }//primary key

        public string Name { get; set; }//Наименование детали ("Мотор для КРаЗ","Мотор для МАЗ")

        public string Type { get; set; }//тип детали ("Кузов","колесо")

        public int Money { get; set; }//стоимость
    }
}