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
        public ActionResult Index(string str)//показать базар
        {
            ViewBag.rezalt = str;
            return View(db.Bazaars);
        }


        public ActionResult Buy(string id, string col)//покупка
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
           
            maniForBuy = workBazaar.GetDetailDbId(idInBD).Money * colBuy;
            maniOfShop = workMoney.GetMani(Static.UserGame.UserId);
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
                    detailInSclad = workSklad.GetDeteilSomeBdByType(typeOfDetailInBazaar, Static.UserGame.UserId).Type;
                    workSklad.UpdateForBuy(typeOfDetailInBazaar, colBuy, Static.UserGame.UserId);
                }
                catch(Exception e)
                {
                    e.ToString();
                    Bazaar newBazaar = workBazaar.GetDetailDbId(idInBD);
                    workSklad.newDetail(newBazaar.Name, newBazaar.Type, colBuy, Static.UserGame.UserId);
                }
                workMoney.minMani(maniForBuy,Static.UserGame.UserId);
                //MessageBox.Show("Покупка совершена");
                str = "Покупка совершена";
            }


            return Redirect("\\Bazaar\\Index?str="+str);
        }

        public ActionResult Back()//вернуться назад
        {
            return Redirect("/Home/Index");
        }
    }
}
