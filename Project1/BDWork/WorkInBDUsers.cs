using Project1.Context;
using Project1.Models;
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
    }
}