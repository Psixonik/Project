using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Detail
    {
        public int Id { get; set; }

        public int UserId { get; set; }//идентификатор игрока

        public string Name { get; set; }//Наименование детали ("Мотор для КРаЗ","Мотор для МАЗ")

        public string Type { get; set; }//тип детали ("Кузов","колесо")

        public int Col { get; set; }//количество деталей

    }
}