using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Static
{
    public static class UserGame
    {

        //данные нового игрока

        public static int UserId { get; set; }

        public static int Counaxez { get; set; } = 1;

        public static int Cash { get; set; } = 10000;
        public static int Credit { get; set; } = 0;
        public static int DayForCredit { get; set; } = 0;

        public static int Gas { get; set; } = 100;
        public static int Water { get; set; } = 100;
        public static int Electro { get; set; } = 100;

        public static int ColWorkers { get; set; } = 0;
        public static int Zp { get; set; } = 0;
        public static int Al { get; set; } = 0;
        public static int DayOfStrike { get; set; } = 0;
        public static bool Strike { get; set; } = false;

        public static int ManiForWin { get; set; } = 1000000;
    }
}