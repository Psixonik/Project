using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Money
    {
        public int id { get; set; }

        public int userId { get; set; }//идентификатор игрока

        public int cash { get; set; }//наличьность игрока

        public int credit { get; set; }//сумма кредита

        public int dayForCredit { get; set; }//дней до погашения кредита

        public Money(int userId, int cash, int credit, int dayForCredit)
        {
            this.userId = userId;
            this.cash = cash;
            this.credit = credit;
            this.dayForCredit = dayForCredit;
        }
        public Money()
        {
        }
    }
}