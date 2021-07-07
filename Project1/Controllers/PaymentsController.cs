using Project1.BDWork;
using Project1.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class PaymentsController : Controller
    {
        BDContext db = new BDContext();
        WorkInBDWorkes workWorkers = new WorkInBDWorkes();
        WorkInBDUtilits workUtilits = new WorkInBDUtilits();

        //показ затрат цеха
        
        // GET: Payments
        public ActionResult Index()
        {
            ViewBag.zp = workWorkers.GetAll(Static.UserGame.userId);

            ViewBag.gas = workUtilits.GetGas(Static.UserGame.userId);
            ViewBag.water = workUtilits.GetWater(Static.UserGame.userId);
            ViewBag.electro = workUtilits.GetElectro(Static.UserGame.userId);
            ViewBag.all = ViewBag.zp + ViewBag.gas + ViewBag.water + ViewBag.electro;
            return View();
        }
    }
}