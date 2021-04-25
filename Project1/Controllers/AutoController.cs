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
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Auto = workAuto.GetAutoAll();
            mymodel.NameOfMashin = workMashin.GetSeachMenuAll();

            return View(mymodel);
        }
        public PartialViewResult PartialAuto(int id)
        {
            //Thread.Sleep(1000);
            NameOfMashin mashin = workMashin.GetMashonById(id);
            int cash = workMoney.GetMani();
            if (cash < mashin.cost)
            {
                MessageBox.Show("Нет денег");
            }
            else
            {
                workMoney.minMani(mashin.cost);
                workAuto.SetAuto(mashin.nameAuto,mashin.services, mashin.content, 1);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll());
        }
        public PartialViewResult PartialAutoWork(int id)
        {
            Random rnd = new Random();
            Auto mashin = workAuto.GetAutoById(id);
            workMoney.AddMoney(mashin.services);
            workAuto.JobsEnd(id);
            if (rnd.Next(101) < 25)
            {
                workAuto.Broken(id);
                int content = workAuto.GetContent(id);
                int axez = rnd.Next(content + 1);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll());
        }
        public PartialViewResult PartialAutoRepair(int id)
        {
            Money cash = workMoney.GetManiOfRow();
            Auto mashin = workAuto.GetAutoById(id);
            int cashForRepair = mashin.content;
            if (cash.cash < cashForRepair)
            {
                MessageBox.Show("Нет денег");
            }
            else
            {
                workMoney.minMani(cashForRepair);
                workAuto.SetBroken(0, id);
            }
            return PartialView("PartialAuto", workAuto.GetAutoAll());
        }
    }
}