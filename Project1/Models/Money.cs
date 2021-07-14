using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Money
    {
        public int Id { get; set; }

        public int UserId { get; set; }//идентификатор игрока

        public int Cash { get; set; }//наличьность игрока

        public int Credit { get; set; }//сумма кредита

        public int DayForCredit { get; set; }//дней до погашения кредита

        public Money(int userId, int cash, int credit, int dayForCredit)
        {
            this.UserId = userId;
            this.Cash = cash;
            this.Credit = credit;
            this.DayForCredit = dayForCredit;
        }
        public Money()
        {
        }
    }
}