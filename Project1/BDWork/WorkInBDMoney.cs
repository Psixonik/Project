using Project1.Context;
using Project1.Models;
using Project1.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Project1.BDWork
{
    public class WorkInBDMoney
    {
        BDContext db = new BDContext();
        WorkInBDWorkes workWorkers = new WorkInBDWorkes();
        WorkInBDUtilits workUtilits = new WorkInBDUtilits();

        //const int ID = 1;//"магическое число" - надо избавиться

        public int GetMani(int userId)
        {
            //return db.Moneys.Where(c => c.id == ID).FirstOrDefault().cash;
            Money axez = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            return axez.cash;
        }

        internal int GetManiById(int userId)
        {
            Money money = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            return money.cash;
        }

        public Money GetManiOfRow()
        {
            return (from c in db.Moneys select c).FirstOrDefault();
        }

        public void AddMoney(Zakaz zakaz,int userId)
        {
            int moneyForZakaz = zakaz.money;
            //int money = (from c in db.Moneys select c.cash).FirstOrDefault();
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            Money moneyUpdate = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            //money = moneyUpdate.cash;

            // Внести изменения
            //money += moneyForZakaz;
            moneyUpdate.cash += moneyForZakaz;
            //Money moneyUpdate = db.Moneys.Where(p => p.id == ID).FirstOrDefault();

            /*if (moneyUpdate != null)
            {
                moneyUpdate.cash = money;
            }*/
            // Сохранить изменения
            db.SaveChanges();
        }

        public void minMani(int minMani, int userId)
        {
            //int money = (from c in db.Moneys select c.cash).FirstOrDefault();
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            // Внести изменения
            //money -= minMani;
            //moneyUpdate.cash -= minMani; ;

            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();

            if (moneyUpdate != null)
            {
                moneyUpdate.cash -= minMani;
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public void MinManiEndOfDay(int userId)
        {
            //Money mani;
            int minZpWorkers = workWorkers.GetColWorkes(userId) * workWorkers.GetZP(userId);
            int minUtilits = workUtilits.GetGas(userId) + workUtilits.GetWater(userId) + workUtilits.GetElectro(userId);
            Money moneyUpdate = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            moneyUpdate.cash -= (minZpWorkers + minUtilits);
            // Сохранить изменения
            db.SaveChanges();
        }

        public int GetCredit(int userId)
        {
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            //return moneyUpdate.credit;
            return db.Moneys.Where(c => c.userId == userId).FirstOrDefault().credit;
        }

        public int GetDayForCredit(int userId)
        {
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            //return moneyUpdate.dayForCredit;
            return db.Moneys.Where(c => c.userId == userId).FirstOrDefault().dayForCredit;
        }

        public void AddManiForCredit(int cash, int day, int userId)
        {
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            if (moneyUpdate != null)
            {
                moneyUpdate.cash += cash;
            }
            // Сохранить изменения
            db.SaveChanges();
            moneyUpdate.credit = cash;
            // Сохранить изменения
            db.SaveChanges();
            moneyUpdate.dayForCredit = day;
            // Сохранить изменения
            db.SaveChanges();
        }

        public void MinDayForCredit(int userId)
        {
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            if (moneyUpdate != null)
            {
                if (moneyUpdate.dayForCredit == 0)
                {
                    MessageBox.Show("Game Over");
                }
                else
                {
                    moneyUpdate.dayForCredit--;
                    /*if (moneyUpdate.dayForCredit == 0)
                    {
                        MinCredit(userId);
                    }*/
                }
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public void AddMoney(int cash, int userId)
        {
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            moneyUpdate.cash += cash;
            db.SaveChanges();
        }

        public void MinCredit(int userId)
        {
            //Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            moneyUpdate.credit = 0;
            db.SaveChanges();
        }

        public void СreateNewUser(int userId, int cash, int credit, int dayForCredit)
        {
            Money money = new Money(userId, cash, credit, dayForCredit);
            db.Moneys.Add(money);
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)
        {
            IList<Money> moneys = db.Moneys.Where(c => c.userId == userId).ToArray();

            if (moneys != null)
            {
                for (int i = 0; i < moneys.Count(); i++)
                {
                    db.Moneys.Remove(moneys[i]);
                    db.SaveChanges();
                }
            }
            СreateNewUser(userId, UserGame.cash, UserGame.credit, UserGame.dayForCredit);
        }
    }

}