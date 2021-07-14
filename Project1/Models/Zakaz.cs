using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Zakaz
    {
        
        public int Id { get; set; }

        public string Name { get; set; }//какую машину надо собрать?

        public int Col { get; set; }//сколько таких машин нужно собрать?

        public int Money { get; set; }//сколько заплатят?

    }
}