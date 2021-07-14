using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Utilits
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Gas { get; set; }

        public int Water { get; set; }

        public int Electro { get; set; }

        public Utilits(int userId, int gas, int water, int electro)
        {
            this.UserId = userId;
            this.Gas = gas;
            this.Water = water;
            this.Electro = electro;
        }
        public Utilits()
        {
        }
    }
}