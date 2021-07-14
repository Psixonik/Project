using Project1.BDWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Static
{
    public static class NewUser
    {
        //создание нового пользователя

        public static void CreatNewUser(int userId)
        {
            WorkInBDMoney workMoney = new WorkInBDMoney();
            WorkInBDSklad workSklad = new WorkInBDSklad();
            WorkInBDWorkes workWorkers = new WorkInBDWorkes();
            WorkInBDUtilits workUtilits = new WorkInBDUtilits();
            workMoney.СreateNewUser(userId, UserGame.Cash, UserGame.Credit, UserGame.DayForCredit);
            workUtilits.CreatNewUser(userId, UserGame.Gas, UserGame.Water, UserGame.Electro);
            workWorkers.СreateNewUser(userId, UserGame.ColWorkers, UserGame.Zp, UserGame.Al, UserGame.DayOfStrike, UserGame.Strike);
        }
    }
}