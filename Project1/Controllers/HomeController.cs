using Project1.BDInitializer;
using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{

    public class HomeController : Controller
    {      
        WorkInBDMoney workMani = new WorkInBDMoney();
        public ActionResult Index()
        {
            int mani = workMani.GetMani();
            ViewBag.mani = mani;
            return View();
        }
        public ActionResult NewGame()
        {
            return View();
        }
        public ActionResult GameOver(string ansver)
        {
            switch (ansver)
            {
                case ("No"):
                    {
                        Environment.Exit(0);
                        return Redirect("/Home/index");
                        
                    }
                case ("Yes"):
                    {
                        /*Initializer init = new Initializer();
                        Database.SetInitializer<BDContext>(new Initializer());
                        BDContext db = new BDContext();
                        init.InitializeDatabase(db);*/
                        BDContext db = new BDContext();
                        ReWriteBD re = new ReWriteBD();
                        re.re();
                        return Redirect("/Home/index");
                    }
                default:
                    {
                        MessageBox.Show("Что-то пошло не так");
                        return Redirect("/Home/index");
                    }
            }
        }
        public ActionResult Regulations()
        {
            return View();
        }
    }
}
 