using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Static
{
    public static class UserGame
    {
        public static int userId { get; set; }

        public static int cash { get; set; } = 10000;
        public static int credit { get; set; } = 0;
        public static int dayForCredit { get; set; } = 0;

        public static int gas { get; set; } = 100;
        public static int water { get; set; } = 100;
        public static int electro { get; set; } = 100;

        public static int colWorkers { get; set; } = 0;
        public static int zp { get; set; } = 0;
        public static int al { get; set; } = 0;
        public static int dayOfStrike { get; set; } = 0;
        public static bool strike { get; set; } = false;

        public static int maniForWin { get; set; } = 1000000;
    }
}