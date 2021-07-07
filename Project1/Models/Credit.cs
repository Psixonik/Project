using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Credit
    {
        public int id { get; set; }

        public int cash { get; set; }//сумма кредита

        public int day { get; set; }//дней до погашения кредита
    }
}