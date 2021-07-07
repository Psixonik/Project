using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class WorkersController : Controller
    {
        BDContext db = new BDContext();
        WorkInBDWorkes workWorkes = new WorkInBDWorkes();

        //рабочии
        
        // GET: Home
        public ActionResult Index(int? zp)
        {

            ViewBag.worker = workWorkes.GetColWorkes(Static.UserGame.userId);
            if (zp != null)
            {
                ViewBag.allZP = zp * ViewBag.worker;
                ViewBag.zp = zp;
                workWorkes.ChenchZP((int)zp, Static.UserGame.userId);
            }
            else
            {
                ViewBag.allZP = workWorkes.GetZP(Static.UserGame.userId) * ViewBag.worker;
                ViewBag.zp = workWorkes.GetZP(Static.UserGame.userId);
            }
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.userId);
            return View(workers);
        }

        public PartialViewResult WorkesPartial(string change)
        {
            ViewBag.ColWorcers = workWorkes.GetColWorkes(Static.UserGame.userId);
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.userId);
            if (ViewBag.ColWorcers >= 3 && change == "add")
            {
                return PartialView("WorkesPartial", workers);
            }
            if (ViewBag.ColWorcers > 0 || change == "add")
            {
                workWorkes.ChenchWorker(change, Static.UserGame.userId);
                workWorkes.changAllZp(Static.UserGame.userId);
            }
            workers = db.Workers.Where(c => c.userId == Static.UserGame.userId);
            return PartialView("WorkesPartial", workers);
        }

        public PartialViewResult ZpPartial(int zp)
        {
            workWorkes.ChenchZP(zp, Static.UserGame.userId);
            workWorkes.changAllZp(Static.UserGame.userId);
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.userId);
            return PartialView("ZpPartial", workers);
        }
    }
}