﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Worker
    {
        public int id { get; set; }

        public int userId { get; set; }

        public int colWorkers { get; set; }

        public int zp { get; set; }

        public int al { get; set; }

        public int dayOfStrike { get; set; }

        public bool strik { get; set; }

        public Worker(int userId, int colWorkers, int zp, int al, int dayOfStrike, bool strik)
        {
            this.userId = userId;
            this.colWorkers = colWorkers;
            this.zp = zp;
            this.al = al;
            this.dayOfStrike = dayOfStrike;
            this.strik = strik;
        }
        public Worker()
        {
        }
    }
}