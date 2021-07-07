using Project1.BDWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class VictoryController : Controller
    {
        //победа
        
        // GET: Victory
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Win()//заново
        {
            WorkInBDMoney workMoney = new WorkInBDMoney();
            WorkInBDSklad workSklad = new WorkInBDSklad();
            WorkInBDWorkes workWorkers = new WorkInBDWorkes();
            WorkInBDUtilits workUtilits = new WorkInBDUtilits();
            WorkInBDAuto workAuto = new WorkInBDAuto();
            WorkInBDZakaz workZakaz = new WorkInBDZakaz();

            workMoney.DeletUserAndCreateNew(Static.UserGame.userId);
            workSklad.DeletUserAndCreateNew(Static.UserGame.userId);
            workWorkers.DeletUserAndCreateNew(Static.UserGame.userId);
            workUtilits.DeletUserAndCreateNew(Static.UserGame.userId);
            workAuto.DeletUserAndCreateNew(Static.UserGame.userId);
            workZakaz.DeletAllZakaz();
            return Redirect("/Start/Index");
        }
    }
}