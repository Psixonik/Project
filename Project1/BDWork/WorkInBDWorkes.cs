using Project1.Context;
using Project1.Models;
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

        public int GetColWorkes()
        {
            return (from c in db.Workers select c.colWorkers).FirstOrDefault();
        }

        public int GetZP()
        {
            return (from c in db.Workers select c.zp).FirstOrDefault();
        }

        public int GetAll()
        {
            //int colWorkerw= (from c in db.Workers select c.colWorkers).FirstOrDefault();
            //int colZP= (from c in db.Workers select c.zp).FirstOrDefault();
            //return colWorkerw * colZP;
            return (from c in db.Workers select c.al).FirstOrDefault();
        }

        public int GetDayOfStrike()
        {
            return (from c in db.Workers select c.dayOfStrike).FirstOrDefault();
        }

        public void SetDayOfStrike()
        {
            Worker workers = (from c in db.Workers select c).FirstOrDefault();
            workers.dayOfStrike = DAY_OF_STRIKE;
            db.SaveChanges();
        }

        public void changAllZp()
        {
            int colWorkerw = (from c in db.Workers select c.colWorkers).FirstOrDefault();
            int colZP = (from c in db.Workers select c.zp).FirstOrDefault();
            int AllZp = colWorkerw * colZP;
            Worker workers = (from c in db.Workers select c).FirstOrDefault();
            workers.al = AllZp;
            db.SaveChanges();
        }

        public void ChenchWorker(string chanch)
        {
            Worker workers = (from c in db.Workers select c).FirstOrDefault();
            // Внести изменения
            switch (chanch)
            {
                case "add":
                    {
                        workers.colWorkers++;
                        break;
                    }
                case "min":
                    {
                        workers.colWorkers--;
                        break;
                    }
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public void ChenchZP(int zp)
        {
            Worker workers = (from c in db.Workers select c).FirstOrDefault();
            workers.zp = zp;
            db.SaveChanges();
            workers.dayOfStrike = 0;
            db.SaveChanges();
            Project1.Static.Strike.dayOfStrike = 0;
            Project1.Static.Strike.strike = false;
        }

        public void CheckForStrike()
        {
                int zp = GetZP();
                int koof = Project1.Static.Strike.koof;
                //koof = zp;
                Random rnd = new Random();
                int value = rnd.Next(zp + 1);
                if (value >= koof)
                {
                Project1.Static.Strike.strike = false;
                }
                else
                {
                Project1.Static.Strike.strike = true;
                    SetDayOfStrike();

                }
        }

        public void MinDayOfStrike()
        {
            Worker workers = (from c in db.Workers select c).FirstOrDefault();
            workers.dayOfStrike -= 1;
            db.SaveChanges();
        }
    }
}