using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class SkladController : Controller
    {
        WorkInBDSklad workInBDSklad = new WorkInBDSklad();
        BDContext db = new BDContext();

        // асинхронный метод
        /*public async Task<ActionResult> Index()
        {
            creatSeachName();
            ViewBag.details = await (from c in db.Details select c).ToListAsync();
            return View(db.Details);
        }*/
        // синхронный метод
        public ActionResult Index()
        {
            creatSeachName();
            ViewBag.details = workInBDSklad.GetDeteilAll(); ;
            return View(db.Details);
        }
        private void creatSeachName()
        {
            ViewBag.ListName = "error";
            ViewBag.ListName = workInBDSklad.GetSeachMenu();
        }

        [HttpPost]
        public ActionResult Index(string dropdowntipo, string filtr)
        {
            creatSeachName();
            switch (filtr)
            {
                case "all":
                    {
                        ViewBag.details = workInBDSklad.GetDeteilAll();
                        return View(db.Details);
                    }
                default:
                    {
                        ViewBag.details = workInBDSklad.GetDeteilSomeBdByType(dropdowntipo);
                        return View(ViewBag.details);
                    }
            }
        }
    }
}