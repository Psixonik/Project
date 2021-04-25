using Project1.Context;
using Project1.Models;
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

        const int ID = 1;//"магическое число" - надо избавиться

        public int GetMani()
        {
            //return db.Moneys.Where(c => c.id == ID).FirstOrDefault().cash;
            return (from c in db.Moneys select c.cash).FirstOrDefault();
        }

        public Money GetManiOfRow()
        {
            return (from c in db.Moneys select c).FirstOrDefault();
        }

        public void AddMoney(Zakaz zakaz)
        {
            int moneyForZakaz = zakaz.money;
            //int money = (from c in db.Moneys select c.cash).FirstOrDefault();
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            //money = moneyUpdate.cash;

            // Внести изменения
            //money += moneyForZakaz;
            moneyUpdate.cash  += moneyForZakaz;
            //Money moneyUpdate = db.Moneys.Where(p => p.id == ID).FirstOrDefault();

            /*if (moneyUpdate != null)
            {
                moneyUpdate.cash = money;
            }*/
            // Сохранить изменения
            db.SaveChanges();
        }

        public void minMani(int minMani)
        {
            //int money = (from c in db.Moneys select c.cash).FirstOrDefault();
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            // Внести изменения
            //money -= minMani;
            moneyUpdate.cash -= minMani; ;

            /*Money moneyUpdate = db.Moneys.Where(p => p.id == ID).FirstOrDefault();

            if (moneyUpdate != null)
            {
                moneyUpdate.cash = money;
            }*/
            // Сохранить изменения
            db.SaveChanges();
        }

        public void MinManiEndOfDay()
        {
            //Money mani;
            int min = workWorkers.GetColWorkes() * workWorkers.GetZP();
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            moneyUpdate.cash-= min;
            //mani = db.Moneys.Where(c => c.id == ID).FirstOrDefault();
            //mani.cash -= min;
            // Сохранить изменения
            db.SaveChanges();
        }

        public int GetCredit()
        {
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            return moneyUpdate.credit;
            //return db.Moneys.Where(c => c.id == ID).FirstOrDefault().credit;
        }

        public int GetDayForCredit()
        {
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            return moneyUpdate.dayForCredit;
            //return db.Moneys.Where(c => c.id == ID).FirstOrDefault().dayForCredit;
        }

        public void AddManiForCredit(int cash, int day)
        {
            //Money moneyUpdate = db.Moneys.Where(p => p.id == ID).FirstOrDefault();
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
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

        public void MinDayForCredit()
        {
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            //Money moneyUpdate = db.Moneys.Where(p => p.id == ID).FirstOrDefault();
            if (moneyUpdate != null)
            {
                if (moneyUpdate.dayForCredit == 0)
                {
                    MessageBox.Show("Game Over");
                }
                else
                {
                    moneyUpdate.dayForCredit--;
                }
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public void AddMoney(int cash)
        {
            Money moneyUpdate = (from c in db.Moneys select c).FirstOrDefault();
            moneyUpdate.cash += cash;
            db.SaveChanges();
        }
    }
}