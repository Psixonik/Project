using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDCredit
    {
        BDContext db = new BDContext();

        public IEnumerable<int> GetCredits()//получить возможные кредиты
        {
            return (from c in db.Credits select c.cash).ToList();
        }
        public IEnumerable<int> GetDayOfCredits()//получить дни до погашения
        {
            return (from c in db.Credits select c.day).ToList();
        }
    }
}