using Project1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class UtilitesController : Controller
    {
        BDContext db = new BDContext();
        // GET: Utilites
        public ActionResult Index()
        {
            return View(db.Utilits);
        }
    }
}