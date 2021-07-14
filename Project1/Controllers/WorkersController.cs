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

            ViewBag.worker = workWorkes.GetColWorkes(Static.UserGame.UserId);
            if (zp != null)
            {
                ViewBag.allZP = zp * ViewBag.worker;
                ViewBag.zp = zp;
                workWorkes.ChenchZP((int)zp, Static.UserGame.UserId);
            }
            else
            {
                ViewBag.allZP = workWorkes.GetZP(Static.UserGame.UserId) * ViewBag.worker;
                ViewBag.zp = workWorkes.GetZP(Static.UserGame.UserId);
            }
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId);
            return View(workers);
        }

        public PartialViewResult WorkesPartial(string change)
        {
            ViewBag.ColWorcers = workWorkes.GetColWorkes(Static.UserGame.UserId);
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId);
            if (ViewBag.ColWorcers >= 3 && change == "add")
            {
                return PartialView("WorkesPartial", workers);
            }
            if (ViewBag.ColWorcers > 0 || change == "add")
            {
                workWorkes.ChenchWorker(change, Static.UserGame.UserId);
                workWorkes.changAllZp(Static.UserGame.UserId);
            }
            workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId);
            return PartialView("WorkesPartial", workers);
        }

        public PartialViewResult ZpPartial(int zp)
        {
            workWorkes.ChenchZP(zp, Static.UserGame.UserId);
            workWorkes.changAllZp(Static.UserGame.UserId);
            IEnumerable<Worker> workers = db.Workers.Where(c => c.userId == Static.UserGame.UserId);
            return PartialView("ZpPartial", workers);
        }
    }
}