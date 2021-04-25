using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Static
{
    public class Strike
    {
        public static bool strike;

        public static int koof;

        public static int dayOfStrike;

        static Strike()
        {
            strike = false;
            koof = 10;
            dayOfStrike = 0;
        }
    }
}