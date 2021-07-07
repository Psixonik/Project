using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Auto
    {
        public int id { get; set; }

        public int userId { get; set; }//идентификатор игрока

        public string nameAuto { get; set;}//тип машины

        public int services { get; set; }//цена машины (используется при продаже)

        public int maxContent { get; set; }//сколько максимально может зароботать машина

        public int content { get; set; }//сколько заработает машина за день

        public int broken { get; set; }//сломана, рабочая или работа выполнена
    }
}