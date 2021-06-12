using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public string pas { get; set; }

        public User()
        { }

        public User(string name, string pas)
        {
            this.name = name;
            this.pas = pas;
        }
        public User(int id,string name, string pas)
        {
            this.id = id;
            this.name = name;
            this.pas = pas;
        }
    }
}