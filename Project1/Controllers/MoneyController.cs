using Project1.BDWork;
using Project1.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{

    public class MoneyController : Controller
    {
        WorkInBDMoney workMoney = new WorkInBDMoney();
        WorkInBDCredit workCredit = new WorkInBDCredit();
        BDContext db = new BDContext();

        //меню банка

        // GET: Cash
        public ActionResult Index()
        {
            ViewBag.mani = workMoney.GetMani(Static.UserGame.UserId);//деньги игрока
            ViewBag.credit = workMoney.GetCredit(Static.UserGame.UserId);//возможные кредиты
            ViewBag.day = workMoney.GetDayForCredit(Static.UserGame.UserId);//дни до погашиния кредита

            return View(db.Credits);
        }

        public ActionResult Credit(string filtr)//взять кредит или нет?
        {
            if (filtr != "no")
            {
                string[] arr = filtr.Split(' ');
                int cash = Convert.ToInt32(arr[0]);
                int day = Convert.ToInt32(arr[1]);
                workMoney.AddManiForCredit(cash, day, Static.UserGame.UserId);
            }
            return Redirect("\\Money\\Index");
        }
    }
}