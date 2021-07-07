using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Detail
    {
        public int id { get; set; }

        public int userId { get; set; }//идентификатор игрока

        public string name { get; set; }//Наименование детали ("Мотор для КРаЗ","Мотор для МАЗ")

        public string type { get; set; }//тип детали ("Кузов","колесо")

        public int col { get; set; }//количество деталей

    }
}