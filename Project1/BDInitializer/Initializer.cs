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
            Detail p1 = new Detail { name = "кузов", type = "МАЗ", col = 3, money = 10.60M };
            Detail p2 = new Detail { name = "кузов", type = "КрАЗ", col = 7, money = 15.00M };
            Detail p3 = new Detail { name = "кузов", type = "БТР", col = 10, money = 23.00M };
            Detail p4 = new Detail { name = "колесо", type = "260", col = 7, money = 5.36M };
            Detail p5 = new Detail { name = "колесо", type = "320", col = 30, money = 7.80M };
            Detail p6 = new Detail { name = "мотор", type = "Мотор для МАЗа", col = 0, money = 17.80M };
            Detail p7 = new Detail { name = "мотор", type = "Мотор для КрАЗа", col = 10, money = 25.90M };
            Detail p8 = new Detail { name = "мотор", type = "Мотор для ЗИЛа", col = 1, money = 10.00M };
            db.Detail.Add(p1);
            db.Detail.Add(p2);
            db.Detail.Add(p3);
            db.Detail.Add(p4);
            db.Detail.Add(p5);
            db.Detail.Add(p6);
            db.Detail.Add(p7);
            db.Detail.Add(p8);
            db.SaveChanges();

            Zakaz z1 = new Zakaz { name = "КрАЗ", col = 1, money = 100.00M, typeMashiID = 1 };
            Zakaz z2 = new Zakaz { name = "МАЗ", col = 7, money = 603.78M, typeMashiID = 2 };
            Zakaz z3 = new Zakaz { name = "БТР", col = 3, money = 98.40M, typeMashiID = 4 };
            db.Zakaz.Add(z1);
            db.Zakaz.Add(z2);
            db.Zakaz.Add(z3);
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
            db.TypeMashin.Add(t1);
            db.TypeMashin.Add(t2);
            db.TypeMashin.Add(t3);
            db.TypeMashin.Add(t4);
            db.SaveChanges();
        }
    }
}