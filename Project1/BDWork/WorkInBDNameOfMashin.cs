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

            //IEnumerable<string> concatenated = new List<string>();
            IEnumerable<string> menu = (from c in db.Auto select c.nameAuto).ToList().Distinct();
            //concatenated = concatenated.Concat(menu);
            //concatenated = concatenated.Concat(new List<string> { "все" });
            IEnumerable<string> resultado;
            resultado = db.Auto.Select(c => c.nameAuto + " Цена: " + c.cost).ToList();

            return resultado;
        }

        public List<NameOfMashin> GetSeachMenuAll()
        {
            //List<NameOfMashin> arr2 = db.NameOfMashins.ToList();
            var axez= db.Auto.ToList();
            return db.Auto.ToList();
        }

        public NameOfMashin GetMashonById(int id)
        {
            return db.Auto.Where(c => c.id == id).FirstOrDefault();
        }
    }
}