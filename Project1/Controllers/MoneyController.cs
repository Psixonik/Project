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
        // GET: Cash
        public ActionResult Index()
        {
            /*ViewBag.Credits = workCredit.GetCredits();
            ViewBag.Day = workCredit.GetDayOfCredits();
            ViewBag.Lengt = db.Credits.Count();*/

            ViewBag.mani = workMoney.GetMani();
            ViewBag.credit = workMoney.GetCredit();
            ViewBag.day = workMoney.GetDayForCredit();

            return View(db.Credits);
        }

        public ActionResult Credit(string filtr)
        {
            if (filtr != "no")
            {
                string[] arr = filtr.Split(' ');
                int cash = Convert.ToInt32(arr[0]);
                int day = Convert.ToInt32(arr[1]);
                workMoney.AddManiForCredit(cash, day);
            }
            return Redirect("\\Money\\Index");
        }
    }
}