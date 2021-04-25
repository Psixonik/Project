using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.BDInitializer
{
   public class Initializer : DropCreateDatabaseAlways<BDContext>
    {

        protected override void Seed(BDContext db)
        {
            Detail p1 = new Detail { name = "кузов", type = "МАЗ", col = 10 };
            Detail p2 = new Detail { name = "кузов", type = "КрАЗ", col = 10 };
            Detail p3 = new Detail { name = "кузов", type = "БТР", col = 10 };
            Detail p4 = new Detail { name = "колесо", type = "260", col = 10 };
            Detail p5 = new Detail { name = "колесо", type = "320", col = 10 };
            Detail p6 = new Detail { name = "мотор", type = "Мотор для МАЗа", col = 10 };
            Detail p7 = new Detail { name = "мотор", type = "Мотор для КрАЗа", col = 10 };
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

            Money money = new Money { cash = 100000, credit = 0, dayForCredit = 0 };
            db.Moneys.Add(money);      
            db.SaveChanges();

            Zakaz z1 = new Zakaz { name = "КрАЗ", col = 1, money = 100 };
            Zakaz z2 = new Zakaz { name = "МАЗ", col = 1, money = 200 };
            Zakaz z3 = new Zakaz { name = "БТР", col = 1, money = 300 };
            db.Zakazs.Add(z1);
            db.Zakazs.Add(z2);
            db.Zakazs.Add(z3);
            db.SaveChanges();

            TypeMashin t1 = new TypeMashin{
                kyzov ="КрАЗ",colKyzov=1, koleso= "260", colKoleso=4, motor="Мотор для КрАЗа", colMotor=1
            };
            TypeMashin t2 = new TypeMashin{
                kyzov = "МАЗ",colKyzov = 1,koleso = "260",colKoleso = 4,motor = "Мотор для МАЗа",colMotor = 1
            };
            TypeMashin t3 = new TypeMashin{
                kyzov = "ЗИЛ",colKyzov = 1,koleso = "260",colKoleso = 4,motor = "Мотор для ЗИЛа",colMotor = 1
            };
            TypeMashin t4 = new TypeMashin{
                kyzov = "БТР",colKyzov = 1,koleso = "320",colKoleso = 8,motor = "Мотор для КрАЗа",colMotor = 2
            };
            db.TypeMashins.Add(t1);
            db.TypeMashins.Add(t2);
            db.TypeMashins.Add(t3);
            db.TypeMashins.Add(t4);
            db.SaveChanges();

            Bazaar bazaar1 = new Bazaar { name = "кузов", type = "МАЗ", money = 10 };
            Bazaar bazaar2 = new Bazaar { name = "кузов", type = "КрАЗ", money = 20 };
            Bazaar bazaar3 = new Bazaar { name = "кузов", type = "БТР",  money = 30 };

            Bazaar bazaar4 = new Bazaar { name = "колесо", type = "260",  money = 10 };
            Bazaar bazaar5 = new Bazaar { name = "колесо", type = "320",  money = 20 };

            Bazaar bazaar6 = new Bazaar { name = "мотор", type = "Мотор для МАЗа",  money = 10 };
            Bazaar bazaar7 = new Bazaar { name = "мотор", type = "Мотор для КрАЗа", money = 20 };
            Bazaar bazaar8 = new Bazaar { name = "мотор", type = "Мотор для ЗИЛа", money = 30 };

            db.Bazaars.Add(bazaar1);
            db.Bazaars.Add(bazaar2);
            db.Bazaars.Add(bazaar3);
            db.Bazaars.Add(bazaar4);
            db.Bazaars.Add(bazaar5);
            db.Bazaars.Add(bazaar6);
            db.Bazaars.Add(bazaar7);
            db.Bazaars.Add(bazaar8);
            db.SaveChanges();

            Worker workers = new Worker { colWorkers = 2, zp = 50, al = 100, dayOfStrike = 0 };
            db.Workers.Add(workers);
            db.SaveChanges();

            Credit credit1 = new Credit { cash = 5000, day = 5 };
            Credit credit2 = new Credit { cash = 10000, day = 10 };
            Credit credit3 = new Credit { cash = 15000, day = 15 };
            db.Credits.Add(credit1);
            db.Credits.Add(credit2);
            db.Credits.Add(credit3);
            db.SaveChanges();

            Utilits utilits = new Utilits { gas = 100, water = 100, electro = 100 };
            db.Utilits.Add(utilits);
            db.SaveChanges();

            NameOfMashin nameOfMashin1 = new NameOfMashin { nameAuto = "ЗИЛ", cost = 1000, services = 100, content = 1000 };
            NameOfMashin nameOfMashin2 = new NameOfMashin { nameAuto = "МАЗ", cost = 5000, services = 150, content = 1500 };
            NameOfMashin nameOfMashin3 = new NameOfMashin { nameAuto = "КрАЗ", cost = 25000, services = 300, content = 3000 };
            db.Auto.Add(nameOfMashin1);
            db.Auto.Add(nameOfMashin2);
            db.Auto.Add(nameOfMashin3);
            db.SaveChanges();

            /*Auto auto1 = new Auto { nameAuto="ЗИЛ", cost = 1000, services=100, content=100, koofId=100 };
            Auto auto2 = new Auto { nameAuto = "МАЗ", cost = 5000, services = 150, content = 150, koofId = 100 };
            Auto auto3 = new Auto { nameAuto = "КрАЗ", cost = 25000, services = 300, content = 300, koofId = 100 };
            db.Autos.Add(auto1);
            db.Autos.Add(auto2);
            db.Autos.Add(auto3);*/

            //Auto auto1 = new Auto { nameAuto = "---", services = 0, content = 0, koofId = 0 };
            Auto auto1 = new Auto { nameAuto = "ЗИЛ", services = 100,maxContent=1000, content = 0, broken=1 };
            //Auto auto2 = new Auto { nameAuto = "МАЗ", services = 150, maxContent = 1500, content = 1000, broken = -1 };
            //Auto auto3 = new Auto { nameAuto = "КрАЗ", services = 300, maxContent = 3000, content = 0, broken = 1 };
            db.Autoes.Add(auto1);
            //db.Autos.Add(auto2);
            //db.Autos.Add(auto3);
            db.SaveChanges();
            Auto axez= db.Autoes.Where(c => c.id == 1).FirstOrDefault();
            db.Autoes.Remove(axez);
            db.SaveChanges();

            Project1.Static.Strike.strike = false;
        }
    }
}