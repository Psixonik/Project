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

        // GET: Home
        public ActionResult Index(int? zp)
        {

            ViewBag.worker = workWorkes.GetColWorkes();
            if (zp != null)
            {
                ViewBag.allZP = zp * ViewBag.worker;
                ViewBag.zp = zp;
                workWorkes.ChenchZP((int)zp);
            }
            else
            {
                ViewBag.allZP = workWorkes.GetZP() * ViewBag.worker;
                ViewBag.zp = workWorkes.GetZP();
            }
            return View(db.Workers);
        }

        public PartialViewResult WorkesPartial(string change)
        {
            ViewBag.ColWorcers = workWorkes.GetColWorkes();
            
            if (ViewBag.ColWorcers >0 || change=="add")
            {
                workWorkes.ChenchWorker(change);
                //ViewBag.allZP = workWorkes.GetColWorkes() * workWorkes.GetZP();
                workWorkes.changAllZp();
            }
            //Thread.Sleep(1000);
            return PartialView("WorkesPartial", db.Workers);
        }

        public PartialViewResult ZpPartial(int zp)
        {
            workWorkes.ChenchZP(zp);
            workWorkes.changAllZp();
            //Thread.Sleep(1000);
            return PartialView("ZpPartial", db.Workers);
        }
    }
}