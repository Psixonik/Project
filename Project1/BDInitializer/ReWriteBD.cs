using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDInitializer
{
    public class ReWriteBD
    {
        //использовалось для тестирования
        BDContext db = new BDContext();
        public void re()
        {
            db.Details.RemoveRange(db.Details);
            db.SaveChanges();
            db.Moneys.RemoveRange(db.Moneys);
            db.SaveChanges();
            db.Zakazs.RemoveRange(db.Zakazs);
            db.SaveChanges();
            db.TypeMashins.RemoveRange(db.TypeMashins);
            db.SaveChanges();
            db.Bazaars.RemoveRange(db.Bazaars);
            db.SaveChanges();
            db.Auto.RemoveRange(db.Auto);
            db.SaveChanges();
            db.Workers.RemoveRange(db.Workers);
            db.SaveChanges();
            db.Credits.RemoveRange(db.Credits);
            db.SaveChanges();

            Detail p1 = new Detail { Name = "кузов", Type = "МАЗ", Col = 10 };
            Detail p2 = new Detail { Name = "кузов", Type = "КрАЗ", Col = 10 };
            Detail p3 = new Detail { Name = "кузов", Type = "БТР", Col = 10 };
            Detail p4 = new Detail { Name = "колесо", Type = "260", Col = 10 };
            Detail p5 = new Detail { Name = "колесо", Type = "320", Col = 10 };
            Detail p6 = new Detail { Name = "мотор", Type = "Мотор для МАЗа", Col = 10 };
            Detail p7 = new Detail { Name = "мотор", Type = "Мотор для КрАЗа", Col = 10 };
            //Detail p8 = new Detail { name = "мотор", type = "Мотор для ЗИЛа", col = 1 };
            db.Details.Add(p1);
            db.Details.Add(p2);
            db.Details.Add(p3);
            db.Details.Add(p4);
            db.Details.Add(p5);
            db.Details.Add(p6);
            db.Details.Add(p7);
            //db.Detail.Add(p8);
            db.SaveChanges();

            Money money = new Money { Cash = 1000, Credit = 0, DayForCredit = 0 };
            db.Moneys.Add(money);
            db.SaveChanges();

            Zakaz z1 = new Zakaz { Name = "КрАЗ", Col = 1, Money = 100 };
            Zakaz z2 = new Zakaz { Name = "МАЗ", Col = 1, Money = 200 };
            Zakaz z3 = new Zakaz { Name = "БТР", Col = 1, Money = 300 };
            db.Zakazs.Add(z1);
            db.Zakazs.Add(z2);
            db.Zakazs.Add(z3);
            db.SaveChanges();

            TypeMashin t1 = new TypeMashin
            {
                Kyzov = "КрАЗ",
                ColKyzov = 1,
                Koleso = "260",
                ColKoleso = 4,
                Motor = "Мотор для КрАЗа",
                ColMotor = 1
            };
            TypeMashin t2 = new TypeMashin
            {
                Kyzov = "МАЗ",
                ColKyzov = 1,
                Koleso = "260",
                ColKoleso = 4,
                Motor = "Мотор для МАЗа",
                ColMotor = 1
            };
            TypeMashin t3 = new TypeMashin
            {
                Kyzov = "ЗИЛ",
                ColKyzov = 1,
                Koleso = "260",
                ColKoleso = 4,
                Motor = "Мотор для ЗИЛа",
                ColMotor = 1
            };
            TypeMashin t4 = new TypeMashin
            {
                Kyzov = "БТР",
                ColKyzov = 1,
                Koleso = "320",
                ColKoleso = 8,
                Motor = "Мотор для КрАЗа",
                ColMotor = 2
            };
            db.TypeMashins.Add(t1);
            db.TypeMashins.Add(t2);
            db.TypeMashins.Add(t3);
            db.TypeMashins.Add(t4);
            db.SaveChanges();



            Bazaar bazaar1 = new Bazaar { Name = "кузов", Type = "МАЗ", Money = 10 };
            Bazaar bazaar2 = new Bazaar { Name = "кузов", Type = "КрАЗ", Money = 20 };
            Bazaar bazaar3 = new Bazaar { Name = "кузов", Type = "БТР", Money = 30 };

            Bazaar bazaar4 = new Bazaar { Name = "колесо", Type = "260", Money = 10 };
            Bazaar bazaar5 = new Bazaar { Name = "колесо", Type = "320", Money = 20 };

            Bazaar bazaar6 = new Bazaar { Name = "мотор", Type = "Мотор для МАЗа", Money = 10 };
            Bazaar bazaar7 = new Bazaar { Name = "мотор", Type = "Мотор для КрАЗа", Money = 20 };
            Bazaar bazaar8 = new Bazaar { Name = "мотор", Type = "Мотор для ЗИЛа", Money = 30 };

            db.Bazaars.Add(bazaar1);
            db.Bazaars.Add(bazaar2);
            db.Bazaars.Add(bazaar3);
            db.Bazaars.Add(bazaar4);
            db.Bazaars.Add(bazaar5);
            db.Bazaars.Add(bazaar6);
            db.Bazaars.Add(bazaar7);
            db.Bazaars.Add(bazaar8);
            db.SaveChanges();

            Worker workers = new Worker { ColWorkers = 3, Zp = 50 };
            db.Workers.Add(workers);
            db.SaveChanges();

            Credit credit1 = new Credit { Cash = 5000, Day = 5 };
            Credit credit2 = new Credit { Cash = 10000, Day = 10 };
            Credit credit3 = new Credit { Cash = 15000, Day = 15 };
            db.Credits.Add(credit1);
            db.Credits.Add(credit2);
            db.Credits.Add(credit3);
            db.SaveChanges();

            NameOfMashin nameOfMashin1 = new NameOfMashin { NameAuto = "ЗИЛ", Cost = 1000, Services = 100, Content = 100 };
            NameOfMashin nameOfMashin2 = new NameOfMashin { NameAuto = "МАЗ", Cost = 5000, Services = 150, Content = 150 };
            NameOfMashin nameOfMashin3 = new NameOfMashin { NameAuto = "КрАЗ", Cost = 25000, Services = 300, Content = 300 };
            db.Auto.Add(nameOfMashin1);
            db.Auto.Add(nameOfMashin2);
            db.Auto.Add(nameOfMashin3);
            db.SaveChanges();

            Project1.Static.Strike.strike = false;
        }
    }
}