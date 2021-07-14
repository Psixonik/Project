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
            return db.Bazaars.Where(c => c.Id == id).FirstOrDefault();
        }

        public string getTypeDetailByNameAndType(string name, string type)//получить деталь по её типу
        {
            return db.Bazaars.Where(c => c.Type == type).FirstOrDefault().Type;
        }
        public string getTypeDetailById(int id)//получить деталь по её id
        {
            return db.Bazaars.Where(c => c.Id == id).FirstOrDefault().Type;
        }


    }
}