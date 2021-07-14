using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Credit
    {
        public int Id { get; set; }

        public int Cash { get; set; }//сумма кредита

        public int Day { get; set; }//дней до погашения кредита
    }
}