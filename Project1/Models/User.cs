using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class User
    {
        public int id { get; set; }//primary key

        public string name { get; set; }//имя игрока

        public string pas { get; set; }//пароль игрока

        public string email { get; set; }//Email игрока

        public bool correctEmail { get; set; }//подтвержден или нет Email


        public User()
        { }

        public User(string name, string pas)
        {
            this.name = name;
            this.pas = pas;
        }
        public User(int id,string name, string pas, string email, bool correctEmail)
        {
            this.id = id;
            this.name = name;
            this.pas = pas;
            this.email = email;
            this.correctEmail = correctEmail;
        }
    }
}