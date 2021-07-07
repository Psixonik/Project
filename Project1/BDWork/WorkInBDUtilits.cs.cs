using Project1.Context;
using Project1.Models;
using Project1.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDUtilits
    {
        BDContext db = new BDContext();

        public int GetGas(int userId)//получить цену газа
        {
            Utilits utilits = db.Utilits.Where(c => c.userId == userId).FirstOrDefault();
            return utilits.gas;
        }
        public int GetWater(int userId)//получить цену воды
        {
            Utilits utilits = db.Utilits.Where(c => c.userId == userId).FirstOrDefault();
            return utilits.water;
        }
        public int GetElectro(int userId)//получить цену света
        {
            Utilits utilits = db.Utilits.Where(c => c.userId == userId).FirstOrDefault();
            return utilits.electro;
        }
        public void ChancItems(int userId)//новые чены
        {
            Random rnd = new Random();

            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.userId == userId).FirstOrDefault();

            utilits.gas = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.water = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.electro = rnd.Next(91) + 10;
            db.SaveChanges();
        }

        public void CreatNewUser(int userId, int gas, int water, int electro)//новый пользователь
        {
            Utilits utilits = new Utilits(userId,gas,water,electro);
            db.Utilits.Add(utilits);
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)//удалить игрока
        {
            IList<Utilits> utilits = db.Utilits.Where(c => c.userId == userId).ToArray();

            if (utilits != null)
            {
                for (int i = 0; i < utilits.Count(); i++)
                {
                    db.Utilits.Remove(utilits[i]);
                    db.SaveChanges();
                }
            }
            CreatNewUser(userId, UserGame.gas, UserGame.water, UserGame.electro);
        }
    }
}