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
            Utilits utilits = db.Utilits.Where(c => c.UserId == userId).FirstOrDefault();
            return utilits.Gas;
        }
        public int GetWater(int userId)//получить цену воды
        {
            Utilits utilits = db.Utilits.Where(c => c.UserId == userId).FirstOrDefault();
            return utilits.Water;
        }
        public int GetElectro(int userId)//получить цену света
        {
            Utilits utilits = db.Utilits.Where(c => c.UserId == userId).FirstOrDefault();
            return utilits.Electro;
        }
        public void ChancItems(int userId)//новые чены
        {
            Random rnd = new Random();

            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.UserId == userId).FirstOrDefault();

            utilits.Gas = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.Water = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.Electro = rnd.Next(91) + 10;
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
            IList<Utilits> utilits = db.Utilits.Where(c => c.UserId == userId).ToArray();

            if (utilits != null)
            {
                for (int i = 0; i < utilits.Count(); i++)
                {
                    db.Utilits.Remove(utilits[i]);
                    db.SaveChanges();
                }
            }
            CreatNewUser(userId, UserGame.Gas, UserGame.Water, UserGame.Electro);
        }
    }
}