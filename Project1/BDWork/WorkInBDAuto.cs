using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Project1.BDWork
{
    public class WorkInBDAuto
    {
        BDContext db = new BDContext();

        public List<Auto> GetAutoAll()
        {
            return db.Autoes.ToList();
        }

        public void SetAuto(string nameAuto, int services, int content, sbyte broken)
        {
            Auto auto = new Auto { nameAuto = nameAuto, services = services, content = content, broken = broken };

            db.Autoes.Add(auto);

            db.SaveChanges();
        }

        public Auto GetAutoById(int id)
        {
            return db.Autoes.Where(c => c.id == id).FirstOrDefault();
        }

        public void JobsEnd(int id)
        {
            Auto mashina =db.Autoes.Where(c => c.id == id).FirstOrDefault();
            mashina.broken = 0;//Магическое число
            db.SaveChanges();
        }

        public void Broken(int id)
        {
            Auto mashina = db.Autoes.Where(c => c.id == id).FirstOrDefault();
            mashina.broken = -1;//Магическое число
            db.SaveChanges();
        }

        public int GetContent(int id)
        {
            Auto mashina = db.Autoes.Where(c => c.id == id).FirstOrDefault();
            return mashina.maxContent;
        }

        public void SetBroken(int broken, int id)
        {
            Auto mashina = db.Autoes.Where(c => c.id == id).FirstOrDefault();
            mashina.broken = broken;
            db.SaveChanges();
        }

        public void ShowBrokenOrJobs()
        {
            List<int> arr = new List<int>();
            Auto[] autos = db.Autoes.ToArray();
            //MessageBox.Show(autos.Length.ToString());
            foreach (Auto item in db.Autoes)
            {
                if (item.broken == 0)
                {
                    arr.Add(item.id);
                }
            }
            for (int i = 0; i < arr.Count; i++)
            {
                int axez = arr.ElementAt(i);
                Auto auto = db.Autoes.Where(c => c.id == axez).FirstOrDefault();
                auto.broken = 1;
                db.SaveChanges();
            }
        }
    }
}