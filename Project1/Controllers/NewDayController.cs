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
        // GET: NewDay
        public ActionResult Index()
        {
            workZakaz.DeletAllZakaz();
            workZakaz.CreatedNewZakaz();
            workMoney.MinManiEndOfDay();

            if (Project1.Static.Strike.strike)
            {
                workWorkers.MinDayOfStrike();
            }
            else
            {
                workWorkers.CheckForStrike();
            }
            int mani = workMoney.GetCredit();
            int day;
            if (mani > 0)
            {
                workMoney.MinDayForCredit();
                day = workMoney.GetDayForCredit();
                if (day == 0)
                {
                    workMoney.minMani(workMoney.GetCredit());
                }
            }
            if (workMoney.GetMani() <= 0)
            {
                //MessageBox.Show("Game Over");
                return Redirect("/Home/NewGame");
            }
            else
            {
                workUtilites.ChancItems();
                return Redirect("/Home/Index");
            }
        }
    }
}