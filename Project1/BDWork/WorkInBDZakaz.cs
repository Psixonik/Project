using Project1.BDInitializer;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Project1.BDWork
{



    public class WorkInBDZakaz
    {
        Detail threKyzov;//количество кузовов на складе
        Detail threKoleso;//количество колес на складе
        Detail threMotor;//количество моторов на складе
        WorkInBDSklad workInBDSklad = new WorkInBDSklad();
        WorkInBDWorkes workWorkers = new WorkInBDWorkes();
        const int COL_MASHIN = 3;//магическое число. Количество машин

        /*static void SkladContext()
        {
            Database.SetInitializer<BDContext>(new Initializer());
        }*/
        BDContext db = new BDContext();

        public Detail Kyzov(TypeMashin newMashin, int userId)
        {
            threKyzov = db.Details
                        .Where(b => (b.type == newMashin.kyzov && b.userId == userId))
                        .FirstOrDefault();
            return threKyzov;
        }
        public Detail Koleso(TypeMashin newMashin, int userId)
        {

            threKoleso = db.Details
                         .Where(b => (b.type == newMashin.koleso && b.userId == userId))
                         .FirstOrDefault();
            return threKoleso;
        }
        public Detail Motor(TypeMashin newMashin, int userId)
        {
            threMotor = db.Details
                        .Where(b => (b.type == newMashin.motor && b.userId == userId))
                        .FirstOrDefault();
            return threMotor;
        }

        public void UpdateSklad(Zakaz zakaz, TypeMashin newMashin,int userId)
        {
            workInBDSklad.UpdateSklad(zakaz, newMashin, threKyzov, threKoleso, threMotor,userId);
        }

        public void deletZacaz(int id)
        {
            Zakaz forDelet = db.Zakazs
                            .Where(o => o.id == id)
                            .FirstOrDefault();
            db.Zakazs.Remove(forDelet);
            db.SaveChanges();
        }

        public void DeletAllZakaz()
        {
            //db.Zakaz.ExecuteSqlCommand("delete from Zakaz");
            foreach (var entity in db.Zakazs)
                db.Zakazs.Remove(entity);
            db.SaveChanges();
        }

        public void CreatedNewZakaz(int userId)
        {
            int colWorkers;//Количество рабочих
            Zakaz zakaz = new Zakaz();
            Random rnd = new Random();
            colWorkers = workWorkers.GetColWorkes(userId);
            IEnumerable<string> nameOfMashin = (from c in db.TypeMashins select c.nameAuto);
            var arrNameOfMashin = nameOfMashin.ToArray();

            for (int i = 0; i < colWorkers; i++)//Количество заказов.
            {
                zakaz.name = arrNameOfMashin[rnd.Next(COL_MASHIN)];
                zakaz.col = rnd.Next(4)+1;//магическое число. Количество машин в заказе.
                zakaz.money = rnd.Next(100)+1;//магическое число. Цена заказа.

                db.Zakazs.Add(zakaz);
                db.SaveChanges();
            }
        }

    }
}