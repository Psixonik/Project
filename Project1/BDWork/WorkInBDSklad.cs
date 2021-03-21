using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project1.Models;

namespace Project1.BDWork
{
    public class WorkInBDSklad
    {
        BDContext db = new BDContext();

        public void UpdateSklad(Zakaz zakaz, TypeMashin newMashin, Detail threKyzov, Detail threKoleso, Detail threMotor)
        {
            int newKyzov = threKyzov.col - zakaz.col;
            int newKoleso = threKoleso.col - zakaz.col;
            int newMotor = threMotor.col - zakaz.col;

            var kyzov = db.Detail
                    .Where(c => c.type == newMashin.kyzov)
                    .FirstOrDefault();
            // Внести изменения
            kyzov.col = kyzov.col - newMashin.colKyzov * zakaz.col;
            // Сохранить изменения
            db.SaveChanges();

            var koleso = db.Detail
                .Where(c => c.type == newMashin.koleso)
                .FirstOrDefault();
            // Внести изменения
            koleso.col = koleso.col - newMashin.colKoleso * zakaz.col;
            // Сохранить изменения
            db.SaveChanges();

            var motor = db.Detail
                .Where(c => c.type == newMashin.motor)
                .FirstOrDefault();
            // Внести изменения
            motor.col = motor.col - newMashin.colMotor * zakaz.col;
            // Сохранить изменения
            db.SaveChanges();
        }

        public IEnumerable<Detail> GetDeteilSomeBdByType(string type)
        {
            return db.Detail.Where(c => c.name == type);
        }
        public IEnumerable<Detail> GetDeteilAll()
        {
            return db.Detail;
        }

        public IEnumerable<string> GetSeachMenu()
        {
            IEnumerable<string> menu = (from c in db.Detail select c.name).ToList().Distinct();
            return menu;
        }

    }
}