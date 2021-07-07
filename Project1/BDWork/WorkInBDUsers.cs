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

        public bool Name(string name)//Есть-ли такое имя в БД?
        {
            return db.Users.Where(c => c.name == name).Any();
        }
        public bool Email(string email)//Есть-ли такой Email в БД?
        {
            return db.Users.Where(c => c.email == email).Any();
        }

        public void SaveUser(User user)//сохранить в БД нового пользователя
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public string SearchUser(string name, string psw)//возможные ошибки при входе зарегестрированного пользователя
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

        public string GetName(int userId)//Найти в БД имя пользователя по его уникальному userId
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.name;
        }

        public User GetUser(int userId)//Найти в БД пользователя по его уникальному userId
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user;
        }

        public User GetLatest()//получить количество записей в таблице user
        {
            int lastUser = db.Users.Max(p => p.id);
            return db.Users.Find(lastUser);
        }

        public bool GetEmailBool(int userId)//Подтвержден-ли Email пользователя? (поиск в таблице по userId)
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.correctEmail;
        }

        public string GetEmailString(int userId)//получить Email пользователя
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            return user.email;
        }

        public void SetEmailBool(int userId)//Подтвердить Email пользователя
        {
            User user = db.Users.Where(c => c.id == userId).FirstOrDefault();
            user.correctEmail = true;
            db.SaveChanges();
        }

        public void ReRegister(string name, string psw, string email)//Повторная регистрация
        {
            User user = db.Users.Where(c => c.email == email).FirstOrDefault();
            user.name = name;
            user.pas = psw;
            db.SaveChanges();
        }

        public bool GetBoolEmailForEmail(string email)//Подтвержден-ли Email пользователя? (поиск в таблице по Email)
        {
            User user = db.Users.Where(c => c.email == email).FirstOrDefault();
            return user.correctEmail;
        }
    }
}