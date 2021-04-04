using Project1.BDWork;
using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class WorkersController : Controller
    {
        BDContext db = new BDContext();
        WorkInBDWorkes workWorkes = new WorkInBDWorkes();

        // GET: Workers
        public ActionResult Index()
        {
            ViewBag.worker = workWorkes.GetColWorkes();
            ViewBag.zp = workWorkes.GetZP() * ViewBag.worker;
            return View(db.Workers);
        }

        [HttpPost]
        public ActionResult Сhange(string change)
        {
            workWorkes.ChenchWorker(change);
            /*switch (change)
            {
                case "add":
                    {
                        workWorkes.ChenchWorker(+1);
                        //workWorkes.AddWorker();
                        break;
                    }
                case "min":
                    {
                        workWorkes.ChenchWorker(-1);
                        //workWorkes.MinWorker();
                        break;
                    }
            }*/
            return Redirect("/Workers/Index");
        }
    }
}