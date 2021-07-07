using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Zakaz
    {
        
        public int id { get; set; }

        public string name { get; set; }//какую машину надо собрать?

        public int col { get; set; }//сколько таких машин нужно собрать?

        public int money { get; set; }//сколько заплатят?

    }
}