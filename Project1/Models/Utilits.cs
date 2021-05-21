using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Utilits
    {
        public int id { get; set; }

        public int userId { get; set; }

        public int gas { get; set; }

        public int water { get; set; }

        public int electro { get; set; }

        public Utilits(int userId, int gas, int water, int electro)
        {
            this.userId = userId;
            this.gas = gas;
            this.water = water;
            this.electro = electro;
        }
        public Utilits()
        {
        }
    }
}