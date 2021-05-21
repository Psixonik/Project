﻿using Project1.BDWork;
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
                newMashin = workInBDTypeMashin.GetTypeMashineByName(item.name);
                titl.Add(newMashin.kyzov + " "+newMashin.colKyzov+" шт."+
                        "\nКолесо: " + newMashin.koleso + " " + newMashin.colKoleso + " шт.\n" +
                        newMashin.motor + " " + newMashin.colMotor + " шт.");
            }
            ViewBag.titl = titl;            
            return View(db.Zakazs);
        }

        public  ActionResult Create(Zakaz zakaz)
        {
            newMashin = workInBDTypeMashin.GetTypeMashineByName(zakaz.name);
            Kyzov(errorCrear, newMashin,zakaz);
            Koleso(errorCrear, newMashin, zakaz);
            Motor(errorCrear, newMashin, zakaz);
          
            if (fl)
            {
                workInBDZakaz.UpdateSklad(zakaz, newMashin,Static.UserGame.userId);
                workInBDZakaz.deletZacaz(zakaz.id);
                money.AddMoney(zakaz, Static.UserGame.userId);
                errorCrear.Add("Сборка заказа завершена. Вы получили "+zakaz.money +" $");
            }
            ViewBag.errorCrear = errorCrear;            
            return View();
        }

        private void Kyzov(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        {
            threKyzov = workInBDZakaz.Kyzov(newMashin,Static.UserGame.userId);
            BildZakaz(threKyzov,zakaz, "кузов", newMashin.colKyzov);
        }
        private void Koleso(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        {
            threKoleso = workInBDZakaz.Koleso(newMashin, Static.UserGame.userId);
            BildZakaz(threKoleso, zakaz, "колесо", newMashin.colKoleso);
        }
        private void Motor(List<string> errorCrear, TypeMashin newMashin, Zakaz zakaz)
        { 
            threMotor = workInBDZakaz.Motor(newMashin, Static.UserGame.userId);
            BildZakaz(threMotor, zakaz, "мотор", newMashin.colMotor);
        }

        private void BildZakaz(Detail type,Zakaz zakaz, string str, int col)
        {
            if (type == null)
            {
                fl = false;
                errorCrear.Add("На складе ненайден " + str +" типа "+ zakaz.name);
            }
            if (type != null && type.col < col * zakaz.col)
            {
                fl = false;
                errorCrear.Add("На складе недостаточьно " + str + " типа " + type.type+
                    ". В наличии " + type.col + ". Необходимо " + col * zakaz.col);
            }
        }

        public ActionResult Delet(Zakaz zakaz)
        {
            workInBDZakaz.deletZacaz(zakaz.id);
            return Redirect("/Zakaz/AllZakaz");
        }
    }
}