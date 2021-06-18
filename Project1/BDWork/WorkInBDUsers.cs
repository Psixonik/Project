using Project1.Context;
using Project1.Models;
using Project1.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDUsers
    {
        BDContext db = new BDContext();

        public bool Name(string name)
        {
            return db.Users.Where(c => c.name == name).Any();
        }

        public bool Email(string email)
        {
            return db.Users.Where(c => c.email == email).Any();
        }

        public void SaveUser(User user)
        {
            // Добавить в DbSet
            db.Users.Add(user);

            // Сохранить изменения в базе данных
            db.SaveChanges();
        }

        public string SearchUser(string name, string psw)
        {
            User user = db.Users.Where(c => c.name == name).FirstOrDefault();
            if (user != null)
            {
                if (user.pas == psw)
                {
                    return user.id.ToString();
                }
                return "Пароль неверен";
            }
            else
            {
                return "Такого юзера нет";
            }

        }

        public string GetName(int userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.name;
        }

        public User GetUser(int userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user;
        }

        public User GetLatest()
        {
            int lastUser = db.Users.Max(p => p.id);
            return db.Users.Find(lastUser);
        }

        public bool GetEmailBool(int userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.correctEmail;
        }

        public string GetEmailString(int userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.email;
        }

        public void SetEmailBool(int userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            user.correctEmail = true;
            db.SaveChanges();
        }

        public void ReRegister(string name, string psw, string email)
        {
            User user = db.Users.Where(c => c.email == email).FirstOrDefault();
            user.name = name;
            user.pas = psw;
            db.SaveChanges();
        }

        public bool GetBoolEmailForEmail(string email)
        {
            User user = db.Users.Where(c => c.email == email).FirstOrDefault();
            //db.Users.Where(c => c.email == email).Any();
            return user.correctEmail;
        }
    }
}