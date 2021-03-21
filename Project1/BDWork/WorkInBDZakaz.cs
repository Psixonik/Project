using Project1.BDInitializer;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{



    public class WorkInBDZakaz
    {
        Detail threKyzov;//количество кузовов на складе
        Detail threKoleso;//количество колес на складе
        Detail threMotor;//количество моторов на складе
        WorkInBDSklad workInBDSklad = new WorkInBDSklad();

        /*static void SkladContext()
        {
            Database.SetInitializer<BDContext>(new Initializer());
        }*/
        BDContext db = new BDContext();

        public Detail Kyzov(TypeMashin newMashin)
        {
            threKyzov = db.Detail
                        .Where(b => b.type == newMashin.kyzov)
                        .FirstOrDefault();
            return threKyzov;
        }
        public Detail Koleso(TypeMashin newMashin)
        {

            threKoleso = db.Detail
                         .Where(b => b.type == newMashin.koleso)
                         .FirstOrDefault();
            return threKoleso;
        }
        public Detail Motor(TypeMashin newMashin)
        {
            threMotor = db.Detail
                        .Where(b => b.type == newMashin.motor)
                        .FirstOrDefault();
            return threMotor;
        }

        public void UpdateSklad(Zakaz zakaz, TypeMashin newMashin)
        {
            workInBDSklad.UpdateSklad(zakaz, newMashin, threKyzov, threKoleso, threMotor);
        }

        public void deletZacaz(int id)
        {
            Zakaz forDelet = db.Zakaz
                            .Where(o => o.id == id)
                            .FirstOrDefault();
            db.Zakaz.Remove(forDelet);
            db.SaveChanges();
        }
    }
}