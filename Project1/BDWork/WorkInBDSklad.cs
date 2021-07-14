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
            int newKyzov = threKyzov.Col - zakaz.Col;
            int newKoleso = threKoleso.Col - zakaz.Col;
            int newMotor = threMotor.Col - zakaz.Col;

            var kyzov = db.Details
                    .Where(c => (c.Type == newMashin.Kyzov&&c.UserId==userId))
                    .FirstOrDefault();
            // Внести изменения
            kyzov.Col = kyzov.Col - newMashin.ColKyzov * zakaz.Col;
            if (kyzov.Col == 0)
            {
                db.Details.Remove(kyzov);
            }
            // Сохранить изменения
            db.SaveChanges();

            var koleso = db.Details
                .Where(c => (c.Type == newMashin.Koleso&&c.UserId==userId))
                .FirstOrDefault();
            // Внести изменения
            koleso.Col = koleso.Col - newMashin.ColKoleso * zakaz.Col;
            if (koleso.Col == 0)
            {
                db.Details.Remove(koleso);
            }
            // Сохранить изменения
            db.SaveChanges();

            var motor = db.Details
                .Where(c => (c.Type == newMashin.Motor&&c.UserId==userId))
                .FirstOrDefault();
            // Внести изменения
            motor.Col = motor.Col - newMashin.ColMotor * zakaz.Col;
            if (motor.Col == 0)
            {
                db.Details.Remove(motor);
            }
            // Сохранить изменения
            db.SaveChanges();
        }

        public Detail GetDeteilSomeBdByType(string type, int userId)//получить деталь по типу
        {
            Detail axez = db.Details.Where(c => (c.Type == type && c.UserId == userId)).FirstOrDefault();
            return axez;
        }

        public IEnumerable<Detail> GetDeteilSomeBdByName(string name, int userId)//получить деталь по названию
        {
            IEnumerable<Detail> axez;
            if (name == "все")
            {
                axez = GetDeteilAll(userId);
            }
            else
            {
                axez = db.Details.Where(c => (c.Name == name && c.UserId == userId));
            }
            return axez;
        }

        public IEnumerable<Detail> GetDeteilAll(int userId)//получить все детали игрока
        {
            IEnumerable<Detail> axez = db.Details.Where(c => c.UserId == userId);
            return axez;
        }

        public IEnumerable<string> GetSeachMenu()//создать меню поиска
        {

            IEnumerable<string> concatenated = new List<string> { " " };
            IEnumerable<string> menu = (from c in db.Bazaars select c.Name).ToList().Distinct();
            concatenated = concatenated.Concat(menu);
            concatenated = concatenated.Concat(new List<string> { "все" });

            return concatenated;
        }

        public void UpdateForBuy(string type, int colBuy, int userId)//изменить количество при покупке
        {
            Detail col;
            col = db.Details.Where(c => c.Type == type && c.UserId == userId).FirstOrDefault();
            col.Col += colBuy;
            db.SaveChanges();
        }

        public void newDetail(string newName, string newType, int newCol, int userId)//новая деталь
        {
            // Создать новую деталь
            Detail newDetail = new Detail
            {
                UserId = userId,
                Name = newName,
                Type = newType,
                Col = newCol
            };

            // Добавить в DbSet
            db.Details.Add(newDetail);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }

        public void СreateNewUser(int userId)//новый игрок 
        {
            Detail newDetail = new Detail
            {
                UserId = userId,
                Name = "",
                Type = "",
                Col = 0
            };

            // Добавить в DbSet
            db.Details.Add(newDetail);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }

        public void DeletUserAndCreateNew(int userId)//играть заново
        {
            IList<Detail> details = db.Details.Where(c => c.UserId == userId).ToArray();
            
            if (details != null)
            {
                for (int i = 0; i < details.Count(); i++)
                {
                    db.Details.Remove(details[i]);
                    db.SaveChanges();
                }
            }
        }
    }
}