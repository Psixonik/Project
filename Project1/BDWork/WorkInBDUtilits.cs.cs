using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDUtilits
    {
        BDContext db = new BDContext();

        public int GetGas()
        {
            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.id == 1).FirstOrDefault();//"Магическое число"
            return utilits.gas;
        }
        public int GetWater()
        {
            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.id == 1).FirstOrDefault();//"Магическое число"
            return utilits.water;
        }
        public int GetElectro()
        {
            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.id == 1).FirstOrDefault();//"Магическое число"
            return utilits.electro;
        }
        public void ChancItems()
        {
            Random rnd = new Random();

            Utilits utilits = new Utilits();
            utilits = db.Utilits.Where(c => c.id == 1).FirstOrDefault();//"Магическое число"

            utilits.gas = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.water = rnd.Next(91) + 10;
            db.SaveChanges();

            utilits.electro = rnd.Next(91) + 10;
            db.SaveChanges();
        }
    }
}