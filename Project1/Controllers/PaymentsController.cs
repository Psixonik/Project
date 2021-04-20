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

        // GET: Payments
        public ActionResult Index()
        {
            ViewBag.zp = workWorkers.GetAll();

            ViewBag.gas = workUtilits.GetGas();
            ViewBag.water = workUtilits.GetWater();
            ViewBag.electro = workUtilits.GetElectro();

            return View();
        }
    }
}