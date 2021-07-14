using Project1.Context;
using Project1.Models;
using Project1.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{

    public class WorkInBDWorkes
    {
        BDContext db = new BDContext();
        const int DAY_OF_STRIKE = 5;

        public int GetColWorkes(int userId)//получить количество рабочих
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            return workers.ColWorkers;
        }

        public int GetZP(int userId)//получить зп одного рабочего
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            return workers.Zp;
        }

        public int GetAll(int userId)
        {
            Worker worker = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            return worker.Al;
        }

        public int GetDayOfStrike()//получить количество дней забастовки
        {
            Worker workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId).FirstOrDefault();
            return workers.DayOfStrike;
        }

        public void SetDayOfStrike(int userId)//задать количество дней забастовки
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            workers.DayOfStrike = DAY_OF_STRIKE;
            db.SaveChanges();
        }

        public void changAllZp(int userId)//изменить общую зп
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            int colWorkerw = workers.ColWorkers;
            int colZP = workers.Zp;
            int AllZp = colWorkerw * colZP;
            workers.Al = AllZp;
            db.SaveChanges();
        }

        public void ChenchWorker(string chanch, int userId)//изменить количество рабочих
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            // Внести изменения
            switch (chanch)
            {
                case "add":
                    {
                        workers.ColWorkers++;
                        break;
                    }
                case "min":
                    {
                        workers.ColWorkers--;
                        break;
                    }
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public void ChenchZP(int zp, int userId)//изменить зп рабочих при забастовке
        {
            int oldZp;
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            oldZp = workers.Zp;
            workers.Zp = zp;
            db.SaveChanges();
            if (oldZp < zp)
            {
                workers.DayOfStrike = 0;
                workers.Strik = false;
                db.SaveChanges();
            }
        }

        public void CheckForStrike()//Забостуют или нет?
        {
            Worker workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId).FirstOrDefault();
            if (workers.ColWorkers == 0) return;
            int zp = GetZP(Static.UserGame.UserId);
            int koof = Static.Strike.koof;
            Random rnd = new Random();
            int value = rnd.Next(zp + 1);
            
            if (value >= koof)
            {
                workers.Strik = false;
                db.SaveChanges();
            }
            else
            {
                workers.Strik = true;
                SetDayOfStrike(Static.UserGame.UserId);
                db.SaveChanges();
            }
        }

        public void MinDayOfStrike()//уменьшить количество дней забастовки
        {
            Worker workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId).FirstOrDefault();
            workers.DayOfStrike -= 1;
            if (workers.DayOfStrike == 0)
            {
                DeletOfStrik();
            }
            db.SaveChanges();
        }

        public void СreateNewUser(int userId, int colWorkers, int zp, int al, int dayOfStrike, bool strike)//новый игрок
        {
            Worker worker = new Worker(userId, colWorkers, zp, al, dayOfStrike, strike);
            db.Workers.Add(worker);
            db.SaveChanges();
        }

        public bool GetStrik(int userId)//Забостовка или нет?
        {
            Worker workers = db.Workers.Where(c => c.userId == userId).FirstOrDefault();
            return workers.Strik;
        }

        public void DeletOfStrik()//забостовка закончена
        {
            Worker workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId).FirstOrDefault();
            workers.Strik = false;
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)//заново
        {
            IList<Worker> workers = db.Workers.Where(c => c.userId == userId).ToArray();

            if (workers != null)
            {
                for (int i = 0; i < workers.Count(); i++)
                {
                    db.Workers.Remove(workers[i]);
                    db.SaveChanges();
                }
            }
            СreateNewUser(userId, UserGame.ColWorkers, UserGame.Zp, UserGame.Al, UserGame.DayOfStrike, UserGame.Strike);
        }
    }
}