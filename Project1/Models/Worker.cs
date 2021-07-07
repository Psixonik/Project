using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Worker
    {
        public int id { get; set; }

        public int userId { get; set; }//идентификатор игрока

        public int colWorkers { get; set; }//количество рабочих

        public int zp { get; set; }//зарплата одного рабочего

        public int al { get; set; }//зарплата всех рабочих

        public int dayOfStrike { get; set; }//оставшихся дней забастовки

        public bool strik { get; set; }//забастовка или работа?

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