using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Worker
    {
        public int Id { get; set; }

        public int userId { get; set; }//идентификатор игрока

        public int ColWorkers { get; set; }//количество рабочих

        public int Zp { get; set; }//зарплата одного рабочего

        public int Al { get; set; }//зарплата всех рабочих

        public int DayOfStrike { get; set; }//оставшихся дней забастовки

        public bool Strik { get; set; }//забастовка или работа?

        public Worker(int userId, int colWorkers, int zp, int al, int dayOfStrike, bool strik)
        {
            this.userId = userId;
            this.ColWorkers = colWorkers;
            this.Zp = zp;
            this.Al = al;
            this.DayOfStrike = dayOfStrike;
            this.Strik = strik;
        }
        public Worker()
        {
        }
    }
}