using Project1.BDInitializer;
using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class StartController : Controller
    {
        WorkInBDMoney workMani = new WorkInBDMoney();
        WorkInBDWorkes workWorkers = new WorkInBDWorkes();
        WorkInBDUsers workUser = new WorkInBDUsers();
        BDContext db = new BDContext();

        //главное окно

        public ActionResult Index()
        {
            ViewBag.Name = workUser.GetName(Static.UserGame.UserId);
            ViewBag.mani = workMani.GetMani(Static.UserGame.UserId);
            ViewBag.emailBool = workUser.GetEmailBool(Static.UserGame.UserId);
            ViewBag.emailString = workUser.GetEmailString(Static.UserGame.UserId);
            if (workMani.GetMani(Static.UserGame.UserId) > Static.UserGame.ManiForWin)
            {
                return Redirect("/Victory/Index");
            }
            int mani = workMani.GetMani(Static.UserGame.UserId);
            if (mani < 0)
            {
                return View("~/Views/Start/GameOver.cshtml");
            }
            ViewBag.mani = mani;
            ViewBag.strike = workWorkers.GetStrik(Static.UserGame.UserId);
            if (ViewBag.strike)
            {
                ViewBag.DayOfStrike = workWorkers.GetDayOfStrike();
            }
            if (ViewBag.DayOfStrike == 0)
            {
                Project1.Static.Strike.strike = false;
            }
            return View();
        }

        public ActionResult NewGame()
        {
            return View();
        }

        public ActionResult CreateNewGame()
        {
            WorkInBDMoney workMoney = new WorkInBDMoney();
            WorkInBDSklad workSklad = new WorkInBDSklad();
            WorkInBDWorkes workWorkers = new WorkInBDWorkes();
            WorkInBDUtilits workUtilits = new WorkInBDUtilits();
            WorkInBDAuto workAuto = new WorkInBDAuto();
            WorkInBDZakaz workZakaz = new WorkInBDZakaz();

            workMoney.DeletUserAndCreateNew(Static.UserGame.UserId);
            workSklad.DeletUserAndCreateNew(Static.UserGame.UserId);
            workWorkers.DeletUserAndCreateNew(Static.UserGame.UserId);
            workUtilits.DeletUserAndCreateNew(Static.UserGame.UserId);
            workAuto.DeletUserAndCreateNew(Static.UserGame.UserId);
            workZakaz.DeletAllZakaz();
            return Redirect("/Start/index"); 
        }


        public ActionResult Over()
        {
            return View("~/Views/Start/GameOver.cshtml");
        }

        public ActionResult GameOver(string ansver)
        {
            switch (ansver)
            {
                case ("No"):
                    {
                        Environment.Exit(0);
                        return Redirect("/Home/index");

                    }
                case ("Yes"):
                    {
                        CreateNewGame();
                        return Redirect("/Start/index");
                    }
                default:
                    {
                        //MessageBox.Show("Что-то пошло не так");
                        return Redirect("/Home/index");
                    }
            }
        }

        public ActionResult Regulations()
        {
            return View();
        }

        public PartialViewResult StrikePartial()
        {
            return PartialView("StrikePartial");
        }

        public ActionResult Liders()
        {
            IList<Liders> arrLiders = new List<Liders>();
            int cash;
            string name;
            foreach (var item in db.Users)
            {
                cash = workMani.GetMani(item.id);
                name = item.Name;
                arrLiders.Add(new Liders() { Name = name,Cash=cash });
            }
            sortList(arrLiders);
            ViewBag.liders = arrLiders;
            ViewData["liders"] = arrLiders;
            return View();
        }

        public void sortList(IList<Liders> arrLiders)
        {
            Liders tmp;
            for (int i = 0; i < arrLiders.Count()-1; i++)
            {
                for (int j = i + 1; j < arrLiders.Count(); j++)
                {
                    if (arrLiders[i].Cash < arrLiders[j].Cash)
                    {
                        tmp = arrLiders[i];
                        arrLiders[i] = arrLiders[j];
                        arrLiders[j] = tmp;
                    }
                }
            }
        }

        public ActionResult Autors()
        {
            return View();
        }
    }
}