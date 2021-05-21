using Project1.BDWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class NewDayController : Controller
    {
        WorkInBDZakaz workZakaz = new WorkInBDZakaz();
        WorkInBDMoney workMoney = new WorkInBDMoney();
        WorkInBDWorkes workWorkers = new WorkInBDWorkes();
        WorkInBDUtilits workUtilites = new WorkInBDUtilits();
        WorkInBDAuto workAuto = new WorkInBDAuto();
        // GET: NewDay
        public ActionResult Index()
        {
            workZakaz.DeletAllZakaz();
            workZakaz.CreatedNewZakaz(Static.UserGame.userId);
            workMoney.MinManiEndOfDay(Static.UserGame.userId);
            workAuto.ShowBrokenOrJobs(Static.UserGame.userId);
            if (workWorkers.GetStrik(Static.UserGame.userId))
            {
                workWorkers.MinDayOfStrike();
            }
            else
            {
                workWorkers.CheckForStrike();
            }
            int mani = workMoney.GetCredit(Static.UserGame.userId);
            int day;
            if (mani > 0)
            {
                workMoney.MinDayForCredit(Static.UserGame.userId);
                day = workMoney.GetDayForCredit(Static.UserGame.userId);
                if (day == 0)
                {
                    workMoney.minMani(workMoney.GetCredit(Static.UserGame.userId), Static.UserGame.userId);
                    workMoney.MinCredit(Static.UserGame.userId);
                }
            }
            if (workMoney.GetMani(Static.UserGame.userId) <= 0)
            {
                //MessageBox.Show("Game Over");
                //return Redirect("/Start/GameOver");
                return View("~/Views/Start/GameOver.cshtml");
            }
            else
            {
                workUtilites.ChancItems(Static.UserGame.userId);
                return Redirect("/Start/Index");
            }
        }
    }
}