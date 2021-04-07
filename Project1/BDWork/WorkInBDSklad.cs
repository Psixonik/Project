using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project1.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

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

            var kyzov = db.Details
                    .Where(c => c.type == newMashin.kyzov)
                    .FirstOrDefault();
            // Внести изменения
            kyzov.col = kyzov.col - newMashin.colKyzov * zakaz.col;
            if (kyzov.col == 0)
            {
                db.Details.Remove(kyzov);
            }
            // Сохранить изменения
            db.SaveChanges();

            var koleso = db.Details
                .Where(c => c.type == newMashin.koleso)
                .FirstOrDefault();
            // Внести изменения
            koleso.col = koleso.col - newMashin.colKoleso * zakaz.col;
            if (koleso.col == 0)
            {
                db.Details.Remove(koleso);
            }
            // Сохранить изменения
            db.SaveChanges();

            var motor = db.Details
                .Where(c => c.type == newMashin.motor)
                .FirstOrDefault();
            // Внести изменения
            motor.col = motor.col - newMashin.colMotor * zakaz.col;
            if (motor.col == 0)
            {
                db.Details.Remove(motor);
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public Detail GetDeteilSomeBdByType(string type)
        {
            return db.Details.Where(c => c.type == type).FirstOrDefault();
        }
        public IEnumerable<Detail> GetDeteilSomeBdByName(string name)
        {
            return db.Details.Where(c => c.name == name);
        }

        public IEnumerable<Detail> GetDeteilAll()
        {
            return db.Details;
        }

        public IEnumerable<string> GetSeachMenu()
        {

            IEnumerable<string> concatenated= new List<string> { " " };
            IEnumerable<string> menu = (from c in db.Details select c.name).ToList().Distinct();
            concatenated = concatenated.Concat(menu);
            concatenated = concatenated.Concat(new List<string> { "все" });

            return concatenated;
        }

        public void UpdateForBuy(string type, int colBuy)
        {
            Detail col;
            col = db.Details.Where(c => c.type == type).FirstOrDefault();
            col.col += colBuy;
            db.SaveChanges();
        }

        public void newDetail(string newName,string newType, int newCol)
        {
            // Создать новую деталь
            Detail newDetail = new Detail
            {
                name = newName,
                type = newType,
                col = newCol
            };

            // Добавить в DbSet
            db.Details.Add(newDetail);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }
    }
}