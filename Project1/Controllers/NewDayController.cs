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

        //новый день

        // GET: NewDay
        public ActionResult Index()
        {
            workZakaz.DeletAllZakaz();
            workZakaz.CreatedNewZakaz(Static.UserGame.UserId);
            workMoney.MinManiEndOfDay(Static.UserGame.UserId);
            workAuto.ShowBrokenOrJobs(Static.UserGame.UserId);
            if (workWorkers.GetStrik(Static.UserGame.UserId))
            {
                workWorkers.MinDayOfStrike();
            }
            else
            {
                workWorkers.CheckForStrike();
            }
            int mani = workMoney.GetCredit(Static.UserGame.UserId);
            int day;
            if (mani > 0)
            {
                workMoney.MinDayForCredit(Static.UserGame.UserId);
                day = workMoney.GetDayForCredit(Static.UserGame.UserId);
                if (day == 0)
                {
                    workMoney.minMani(workMoney.GetCredit(Static.UserGame.UserId), Static.UserGame.UserId);
                    workMoney.MinCredit(Static.UserGame.UserId);
                }
            }
            if (workMoney.GetMani(Static.UserGame.UserId) <= 0)
            {
                //MessageBox.Show("Game Over");
                return View("~/Views/Start/GameOver.cshtml");
            }
            else if (workMoney.GetMani(Static.UserGame.UserId)>=Static.UserGame.ManiForWin)
            {
                return Redirect("/Victory/Index");
            }
            else
            {
                workUtilites.ChancItems(Static.UserGame.UserId);
                return Redirect("/Start/Index");
            }
        }
    }
}