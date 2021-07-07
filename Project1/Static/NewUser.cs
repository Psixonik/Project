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
            workMoney.СreateNewUser(userId, UserGame.cash, UserGame.credit, UserGame.dayForCredit);
            workUtilits.CreatNewUser(userId, UserGame.gas, UserGame.water, UserGame.electro);
            workWorkers.СreateNewUser(userId, UserGame.colWorkers, UserGame.zp, UserGame.al, UserGame.dayOfStrike, UserGame.strike);
        }
    }
}