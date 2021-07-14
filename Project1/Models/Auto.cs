using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Auto
    {
        public int Id { get; set; }

        public int UserId { get; set; }//идентификатор игрока

        public string NameAuto { get; set;}//тип машины

        public int Services { get; set; }//цена машины (используется при продаже)

        public int MaxContent { get; set; }//сколько максимально может зароботать машина

        public int Content { get; set; }//сколько заработает машина за день

        public int Broken { get; set; }//сломана, рабочая или работа выполнена
    }
}