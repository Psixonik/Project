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
        public ActionResult Index(string str)//показ машин цеха + показ машин для покупки
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Auto = workAuto.GetAutoAll(Static.UserGame.userId);
            mymodel.NameOfMashin = workMashin.GetSeachMenuAll();
            ViewBag.rezalt = str;
            return View(mymodel);
        }
        public ActionResult Sale(int id)//продать машину
        {
            workAuto.SaleAuto(id, Static.UserGame.userId);
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
        public PartialViewResult PartialAuto(int id)//частичьное представление. Показать машины цеха + покупка новой машины
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
                //MessageBox.Show("Нет денег");//на хосте MessageBox не отрабатывает
            }
            else
            {
                workMoney.minMani(mashin.cost,Static.UserGame.userId);
                workAuto.SetAuto(Static.UserGame.userId,mashin.nameAuto,mashin.services, mashin.content, 1);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll(Static.UserGame.userId));
        }
    }
}