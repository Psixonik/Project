using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace Project1.Controllers
{
    public class ZakazController : Controller
    {
        BDContext db = new BDContext();
        List<string> errorCrear = new List<string>();
        TypeMashin newMashin;//машина в заказе
        Detail threKyzov;//количество кузовов на складе
        Detail threKoleso;//количество колес на складе
        Detail threMotor;//количество моторов на складе
        bool fl = true;
        WorkInBDZakaz workInBDZakaz = new WorkInBDZakaz();
        WorkInBDTypeMashin workInBDTypeMashin = new WorkInBDTypeMashin();
        WorkInBDMoney money = new WorkInBDMoney();

        List<string> titl = new List<string>();

        // GET: Zakaz
        public ActionResult AllZakaz()
        {
            foreach (var item in db.Zakazs)
            {
                newMashin = workInBDTypeMashin.GetTypeMashineByName(item.Name);
                titl.Add(newMashin.Kyzov + " "+newMashin.ColKyzov+" шт."+
                        "\nКолесо: " + newMashin.Koleso + " " + newMashin.ColKoleso + " шт.\n" +
                        newMashin.Motor + " " + newMashin.ColMotor + " шт.");
            }
            ViewBag.titl = titl;            
            return View(db.Zakazs);
        }

        public  ActionResult Create(Zakaz zakaz)
        {
            newMashin = workInBDTypeMashin.GetTypeMashineByName(zakaz.Name);
            Kyzov(errorCrear, newMashin,zakaz);
            Koleso(errorCrear, newMashin, zakaz);
            Motor(errorCrear, newMashin, zakaz);
          
            if (fl)
            {
                workInBDZakaz.UpdateSklad(zakaz, newMashin,Static.UserGame.UserId);
                workInBDZakaz.deletZacaz(zakaz.Id);
                money.AddMoney(zakaz, Static.UserGame.UserId);
                errorCrear.Add("Сборка заказа завершена. Вы получили "+zakaz.Money +" $");
            }
            ViewBag.errorCrear = errorCrear;            
            return View();
        }

        private void Kyzov(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        {
            threKyzov = workInBDZakaz.Kyzov(newMashin,Static.UserGame.UserId);
            BildZakaz(threKyzov,zakaz, "кузов", newMashin.ColKyzov);
        }
        private void Koleso(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        {
            threKoleso = workInBDZakaz.Koleso(newMashin, Static.UserGame.UserId);
            BildZakaz(threKoleso, zakaz, "колесо", newMashin.ColKoleso);
        }
        private void Motor(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        { 
            threMotor = workInBDZakaz.Motor(newMashin, Static.UserGame.UserId);
            BildZakaz(threMotor, zakaz, "мотор", newMashin.ColMotor);
        }

        private void BildZakaz(Detail type,Zakaz zakaz, string str, int col)
        {
            if (type == null)
            {
                fl = false;
                errorCrear.Add("На складе ненайден " + str +" типа "+ zakaz.Name);
            }
            if (type != null && type.Col < col * zakaz.Col)
            {
                fl = false;
                errorCrear.Add("На складе недостаточьно " + str + " типа " + type.Type+
                    ". В наличии " + type.Col + ". Необходимо " + col * zakaz.Col);
            }
        }

        public ActionResult Delet(Zakaz zakaz)
        {
            workInBDZakaz.deletZacaz(zakaz.Id);
            return Redirect("/Zakaz/AllZakaz");
        }
    }
}