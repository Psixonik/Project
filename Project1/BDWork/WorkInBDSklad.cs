using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project1.Models;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Activities.Expressions;

namespace Project1.BDWork
{
    public class WorkInBDSklad
    {
        BDContext db = new BDContext();

        public void UpdateSklad(Zakaz zakaz, TypeMashin newMashin, Detail threKyzov, Detail threKoleso, Detail threMotor, int userId)
        {
            int newKyzov = threKyzov.col - zakaz.col;
            int newKoleso = threKoleso.col - zakaz.col;
            int newMotor = threMotor.col - zakaz.col;

            var kyzov = db.Details
                    .Where(c => (c.type == newMashin.kyzov&&c.userId==userId))
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
                .Where(c => (c.type == newMashin.koleso&&c.userId==userId))
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
                .Where(c => (c.type == newMashin.motor&&c.userId==userId))
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

        public Detail GetDeteilSomeBdByType(string type, int userId)
        {
            Detail axez = db.Details.Where(c => (c.type == type && c.userId == userId)).FirstOrDefault();
            return axez;
        }

        public IEnumerable<Detail> GetDeteilSomeBdByName(string name, int userId)
        {
            IEnumerable<Detail> axez = db.Details.Where(c => (c.name == name && c.userId == userId));

            return db.Details.Where(c => (c.name == name && c.userId == userId));
        }

        public IEnumerable<Detail> GetDeteilAll(int userId)
        {
            IEnumerable<Detail> axez = db.Details.Where(c => c.userId == userId);
            return axez;
        }

        public IEnumerable<string> GetSeachMenu()
        {

            IEnumerable<string> concatenated = new List<string> { " " };
            IEnumerable<string> menu = (from c in db.Bazaars select c.name).ToList().Distinct();
            concatenated = concatenated.Concat(menu);
            concatenated = concatenated.Concat(new List<string> { "все" });

            return concatenated;
        }

        public void UpdateForBuy(string type, int colBuy, int userId)
        {
            Detail col;
            col = db.Details.Where(c => c.type == type).FirstOrDefault();
            col.col += colBuy;
            db.SaveChanges();
        }

        public void newDetail(string newName, string newType, int newCol, int userId)
        {
            // Создать новую деталь
            Detail newDetail = new Detail
            {
                userId = userId,
                name = newName,
                type = newType,
                col = newCol
            };

            // Добавить в DbSet
            db.Details.Add(newDetail);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }

        public void СreateNewUser(int userId)
        {
            // Создать новую деталь
            Detail newDetail = new Detail
            {
                userId = userId,
                name = "",
                type = "",
                col = 0
            };

            // Добавить в DbSet
            db.Details.Add(newDetail);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)
        {
            //Detail detail = db.Details.Where(c => c.userId == userId).FirstOrDefault();
            IList<Detail> details = db.Details.Where(c => c.userId == userId).ToArray();
            
            if (details != null)
            {
                for (int i = 0; i < details.Count(); i++)
                {
                    db.Details.Remove(details[i]);
                    db.SaveChanges();
                }
            }
            //СreateNewUser(userId);
        }
    }
}