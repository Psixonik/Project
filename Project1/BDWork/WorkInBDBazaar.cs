using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDBazaar
    {
        BDContext db = new BDContext();

        public Bazaar GetDetailDbId(int id)
        {
            return db.Bazaars.Where(c => c.id == id).FirstOrDefault();
        }

        public string getTypeDetailByNameAndType(string name, string type)
        {
            return db.Bazaars.Where(c => c.type == type).FirstOrDefault().type;
        }
        public string getTypeDetailById(int id)
        {
            return db.Bazaars.Where(c => c.id == id).FirstOrDefault().type;
        }


    }
}