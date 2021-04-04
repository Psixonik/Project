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
        public ActionResult Index()
        {
            ViewBag.Day = Static.Day.day;
            return View(db.Bazaars);
        }


        public ActionResult Buy(string id, string col)
        {
            /*string MyCookieValue;
            // сначала нам требуется проверить на null наличие cookie
            if (Request.Cookies["MyCookieName"] != null)
                MyCookieValue = Request.Cookies["MyCookieName"].Value;*/

            //int mani;
            int maniForBuy;
            int maniOfShop;
            int idInBD = Convert.ToInt32(id);
            int colBuy = Convert.ToInt32(col);


            //maniForBuy = db.Bazaar.Where(c => c.id == idInBD).FirstOrDefault().money * colBuy;
            maniForBuy = workBazaar.GetDetailDbId(idInBD).money * colBuy;
            maniOfShop = workMoney.GetMani()*colBuy;
            if (maniForBuy > maniOfShop)
            {
                MessageBox.Show("Мало денег");
            }
            else
            {
                string typeOfDetailInBazaar;
                string detailInSclad;
                typeOfDetailInBazaar = workBazaar.getTypeDetailById(idInBD);

                try
                {
                    detailInSclad = workSklad.GetDeteilSomeBdByType(typeOfDetailInBazaar).type;
                    workSklad.UpdateForBuy(typeOfDetailInBazaar, colBuy);
                }
                catch(Exception e)
                {
                    Bazaar newBazaar = workBazaar.GetDetailDbId(idInBD);
                    workSklad.newDetail(newBazaar.name, newBazaar.type, colBuy);
                }
                workMoney.minMani(maniForBuy);
                MessageBox.Show("Покупка совершена");
            }


            return Redirect("\\Bazaar\\Index");
        }
    }
}
