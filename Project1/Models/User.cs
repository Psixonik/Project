using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class User
    {
        public int id { get; set; }

        public string email { get; set; }

        public string name { get; set; }

        public string pas { get; set; }

        public User()
        { }

        public User(string email, string name, string pas)
        {
            this.email = email;
            this.name = name;
            this.pas = pas;
        }
        public User(int id,string email, string name, string pas)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.pas = pas;
        }
    }
}