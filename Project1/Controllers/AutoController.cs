using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class AutoController : Controller
    {
        BDContext db = new BDContext();
        WorkInBDNameOfMashin workMashin = new WorkInBDNameOfMashin();
        WorkInBDAuto workAuto = new WorkInBDAuto();
        WorkInBDMoney workMoney = new WorkInBDMoney();

        // GET: Auto
        public ActionResult Index(string str)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Auto = workAuto.GetAutoAll(Static.UserGame.userId);
            mymodel.NameOfMashin = workMashin.GetSeachMenuAll();
            ViewBag.rezalt = str;
            return View(mymodel);
        }
        public ActionResult Sale(int id)
        {
            workAuto.SaleAuto(id, Static.UserGame.userId);
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
        public PartialViewResult PartialAuto(int id)
        {
            string str;
            var colAutoUser = workAuto.GetAutoAll(Static.UserGame.userId);
            if (colAutoUser.Count() >= 3)
            {
                return PartialView("PartialAuto", colAutoUser);
            }
            NameOfMashin mashin = workMashin.GetMashonById(id);
            int cash = workMoney.GetMani(Static.UserGame.userId);
            if (cash < mashin.cost)
            {
                //MessageBox.Show("Нет денег");
            }
            else
            {
                workMoney.minMani(mashin.cost,Static.UserGame.userId);
                workAuto.SetAuto(Static.UserGame.userId,mashin.nameAuto,mashin.services, mashin.content, 1);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
        public PartialViewResult PartialAutoWork(int id)
        {
            Random rnd = new Random();
            Auto mashin = workAuto.GetAutoById(id, Static.UserGame.userId);
            workMoney.AddMoney(mashin.services,Static.UserGame.userId);
            workAuto.JobsEnd(id, Static.UserGame.userId);
            if (rnd.Next(101) < 25)
            {
                workAuto.Broken(id, Static.UserGame.userId);
                int content = workAuto.GetContent(id, Static.UserGame.userId);
                int axez = rnd.Next(content + 1);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
        public PartialViewResult PartialAutoRepair(int id)
        {
            int cash = workMoney.GetMani(Static.UserGame.userId);
            Auto mashin = workAuto.GetAutoById(id, Static.UserGame.userId);
            int cashForRepair = mashin.content;
            if (cash < cashForRepair)
            {
                //MessageBox.Show("Нет денег");
            }
            else
            {
                workMoney.minMani(cashForRepair,Static.UserGame.userId);
                workAuto.SetBroken(0, id, Static.UserGame.userId);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
    }
}