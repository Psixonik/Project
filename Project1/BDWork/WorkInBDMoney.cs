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

        public int GetMani(int userId)//получить наличьность игрока
        {
            Money axez = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            return axez.cash;
        }
        public void AddMoney(Zakaz zakaz,int userId)//увеличить деньги игрока
        {
            int moneyForZakaz = zakaz.money;
            Money moneyUpdate = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            moneyUpdate.cash += moneyForZakaz;
            db.SaveChanges();
        }

        public void minMani(int minMani, int userId)//уменьшить деньги игрока
        {

            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            if (moneyUpdate != null)
            {
                moneyUpdate.cash -= minMani;
            }
            db.SaveChanges();
        }

        public void MinManiEndOfDay(int userId)//уменьшить деньги игрока в конце дня
        {
            int minZpWorkers = workWorkers.GetColWorkes(userId) * workWorkers.GetZP(userId);
            int minUtilits = workUtilits.GetGas(userId) + workUtilits.GetWater(userId) + workUtilits.GetElectro(userId);
            Money moneyUpdate = db.Moneys.Where(c => c.userId == userId).FirstOrDefault();
            moneyUpdate.cash -= (minZpWorkers + minUtilits);
            db.SaveChanges();
        }

        public int GetCredit(int userId)//получить кредит игрока
        {
            return db.Moneys.Where(c => c.userId == userId).FirstOrDefault().credit;
        }

        public int GetDayForCredit(int userId)//получить количество дней до попогашения кредита игроком
        {
            return db.Moneys.Where(c => c.userId == userId).FirstOrDefault().dayForCredit;
        }

        public void AddManiForCredit(int cash, int day, int userId)//игрок взял кредит
        {
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            if (moneyUpdate != null)
            {
                moneyUpdate.cash += cash;
            }
            db.SaveChanges();
            moneyUpdate.credit = cash;
            db.SaveChanges();
            moneyUpdate.dayForCredit = day;
            db.SaveChanges();
        }

        public void MinDayForCredit(int userId)//уменьшить количество дней до погашения кредита
        {
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
                }
            }
            db.SaveChanges();
        }

        public void AddMoney(int cash, int userId)//увеличить деньги игрока
        {
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            moneyUpdate.cash += cash;
            db.SaveChanges();
        }

        public void MinCredit(int userId)//вычесть кредит
        {
            Money moneyUpdate = db.Moneys.Where(p => p.userId == userId).FirstOrDefault();
            moneyUpdate.credit = 0;
            db.SaveChanges();
        }

        public void СreateNewUser(int userId, int cash, int credit, int dayForCredit)//новый игрок
        {
            Money money = new Money(userId, cash, credit, dayForCredit);
            db.Moneys.Add(money);
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)//удалить игрока
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