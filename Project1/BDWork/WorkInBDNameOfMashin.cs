using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.BDWork
{
    public class WorkInBDNameOfMashin
    {
        BDContext db = new BDContext();

        public IEnumerable<string> GetSeachMenu()
        {
            IEnumerable<string> menu = (from c in db.Auto select c.NameAuto).ToList().Distinct();
            IEnumerable<string> resultado;
            resultado = db.Auto.Select(c => c.NameAuto + " Цена: " + c.Cost).ToList();

            return resultado;
        }

        public List<NameOfMashin> GetSeachMenuAll()
        {
            var axez= db.Auto.ToList();
            return db.Auto.ToList();
        }

        public NameOfMashin GetMashonById(int id)
        {
            return db.Auto.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}