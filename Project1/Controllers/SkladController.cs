using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

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
            ViewBag.element = " ";
            ViewBag.details = workInBDSklad.GetDeteilAll();
            return View(db.Details);
            //return View(db.Details);
        }

        private void creatSeachName()
        {
            ViewBag.ListName = "error";
            ViewBag.ListName = workInBDSklad.GetSeachMenu();

            //var axez = db.Database;
        }

        [HttpPost]
        public ActionResult Index(string dropdowntipo, string filtr)
        {
            ViewBag.element = dropdowntipo;
            creatSeachName();
            switch (dropdowntipo)
            {
                case "все":
                    {
                        ViewBag.details = workInBDSklad.GetDeteilAll();
                        return View(db.Details);
                    }
                default:
                    {
                        ViewBag.details = workInBDSklad.GetDeteilSomeBdByName(dropdowntipo);
                        return View(ViewBag.details);
                    }
            }
        }
    }
}