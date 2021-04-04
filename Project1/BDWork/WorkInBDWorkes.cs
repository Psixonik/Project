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

        public int GetColWorkes()
        {
            return (from c in db.Workers select c.colWorkers).FirstOrDefault();
        }

        public int GetZP()
        {
            return (from c in db.Workers select c.zp).FirstOrDefault();
        }
        /*public void AddWorker()
        {


            var col = db.Workers
                        .Where(c => c.id == 1)//Магическое число
                        .FirstOrDefault();
            // Внести изменения
            col.colWorkers++;
            // Сохранить изменения
            db.SaveChanges();
        }
        public void MinWorker()
        {

            var col = db.Workers
                        .Where(c => c.id == 1)//Магическое число
                        .FirstOrDefault();
            // Внести изменения
            col.colWorkers--;
            // Сохранить изменения
            db.SaveChanges();
        }*/
        public void ChenchWorker(string chanch)
        {
            /*int workers = (from c in db.Workers select c.colWorkers).FirstOrDefault();
            workers++;
            db.SaveChanges();*/

            /*var col = db.Workers
                        .Where(c => c.id == 1)//Магическое число
                        .FirstOrDefault();*/
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
            //col.colWorkers = col.colWorkers + x;
            // Сохранить изменения
            db.SaveChanges();
        }
    }
}