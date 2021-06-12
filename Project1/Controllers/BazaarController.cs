using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class BazaarController : Controller
    {
        BDContext db = new BDContext();
        WorkInBDMoney workMoney = new WorkInBDMoney();
        WorkInBDBazaar workBazaar = new WorkInBDBazaar();
        WorkInBDSklad workSklad = new WorkInBDSklad();

        // GET: Bazaar
        [HttpGet]
        public ActionResult Index(string str)
        {
            ViewBag.rezalt = str;
            return View(db.Bazaars);
        }


        public ActionResult Buy(string id, string col)
        {
            int maniForBuy;
            int maniOfShop;
            int colBuy;
            string str;
            int idInBD = Convert.ToInt32(id);
            bool success = Int32.TryParse(col, out colBuy);
            if (!success)
            {
                str = "Что-то пошло не так. Попробуйте снова.";
                return Redirect("\\Bazaar\\Index?str=" + str);
            }
           
            maniForBuy = workBazaar.GetDetailDbId(idInBD).money * colBuy;
            //maniOfShop = workMoney.GetMani(Static.UserGame.userId) *colBuy;
            maniOfShop = workMoney.GetMani(Static.UserGame.userId);
            if (maniForBuy > maniOfShop)
            {
                //MessageBox.Show("Мало денег");
                str= "Для покупки не хватает денег"; 
            }
            else
            {
                string typeOfDetailInBazaar;
                string detailInSclad;
                typeOfDetailInBazaar = workBazaar.getTypeDetailById(idInBD);

                try
                {
                    detailInSclad = workSklad.GetDeteilSomeBdByType(typeOfDetailInBazaar, Static.UserGame.userId).type;
                    workSklad.UpdateForBuy(typeOfDetailInBazaar, colBuy, Static.UserGame.userId);
                }
                catch(Exception e)
                {
                    Bazaar newBazaar = workBazaar.GetDetailDbId(idInBD);
                    workSklad.newDetail(newBazaar.name, newBazaar.type, colBuy, Static.UserGame.userId);
                }
                workMoney.minMani(maniForBuy,Static.UserGame.userId);
                //MessageBox.Show("Покупка совершена");
                str = "Покупка совершена";
            }


            return Redirect("\\Bazaar\\Index?str="+str);
        }

        public ActionResult Back()
        {
            return Redirect("/Home/Index");
        }
    }
}
