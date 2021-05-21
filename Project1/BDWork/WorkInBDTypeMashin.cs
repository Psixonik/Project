using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDTypeMashin
    {
        BDContext db = new BDContext();
        TypeMashin newMashin;//машина в заказе

        public TypeMashin GetTypeMashineByName(string name)
        {
            newMashin = db.TypeMashins
                        .Where(b => b.nameAuto == name)
                        .FirstOrDefault();
            return newMashin;
        }
        public TypeMashin GetTypeMashineById(int id)
        {
            newMashin = db.TypeMashins
                        .Where(b => b.id == id)
                        .FirstOrDefault();
            return newMashin;
        }
    }
}