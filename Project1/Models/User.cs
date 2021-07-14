using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class User
    {
        public int id { get; set; }//primary key

        public string Name { get; set; }//имя игрока

        public string Pas { get; set; }//пароль игрока

        public string Email { get; set; }//Email игрока

        public bool CorrectEmail { get; set; }//подтвержден или нет Email


        public User()
        { }

        public User(string name, string pas)
        {
            this.Name = name;
            this.Pas = pas;
        }
        public User(int id,string name, string pas, string email, bool correctEmail)
        {
            this.id = id;
            this.Name = name;
            this.Pas = pas;
            this.Email = email;
            this.CorrectEmail = correctEmail;
        }
    }
}