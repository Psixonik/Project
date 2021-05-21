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
        WorkInBDMoney workMoney = new WorkInBDMoney();

        public IEnumerable<Auto> GetAutoAll(int userId)
        {
            IEnumerable<Auto> axez=db.Autoes.Where(c =>  c.userId == userId);

            return axez;
        }

        public void SetAuto(int userId,string nameAuto, int services, int content, sbyte broken)
        {
            Auto auto = new Auto { userId=userId,nameAuto = nameAuto, services = services, content = content, broken = broken };

            db.Autoes.Add(auto);

            db.SaveChanges();
        }

        public Auto GetAutoById(int id,int userId)
        {
            return db.Autoes.Where(c => (c.id == id && c.userId==userId)).FirstOrDefault();
        }

        public void JobsEnd(int id, int userId)
        {
            Auto mashina =db.Autoes.Where(c => (c.id == id && c.userId == userId)).FirstOrDefault();
            mashina.broken = 0;//Магическое число
            db.SaveChanges();
        }

        public void Broken(int id, int userId)
        {
            Auto mashina = db.Autoes.Where(c => (c.id == id && c.userId == userId)).FirstOrDefault();
            mashina.broken = -1;//Магическое число
            db.SaveChanges();
        }

        public int GetContent(int id, int userId)
        {
            Auto mashina = db.Autoes.Where(c => (c.id == id && c.userId == userId)).FirstOrDefault();
            return mashina.maxContent;
        }

        public void SetBroken(int broken, int id, int userId)
        {
            Auto mashina = db.Autoes.Where(c => (c.id == id && c.userId == userId)).FirstOrDefault();
            mashina.broken = broken;
            db.SaveChanges();
        }

        public void ShowBrokenOrJobs(int userId)
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
                Auto auto = db.Autoes.Where(c => (c.id == axez && c.userId == userId)).FirstOrDefault();
                if (auto != null)
                {
                    auto.broken = 1;
                }
                db.SaveChanges();
            }
        }

        public void DeletUserAndCreateNew(int userId)
        {
            IList<Auto> autoes = db.Autoes.Where(c => c.userId == userId).ToArray();

            if (autoes != null)
            {
                for (int i = 0; i < autoes.Count(); i++)
                {
                    db.Autoes.Remove(autoes[i]);
                    db.SaveChanges();
                }
            }
            //СreateNewUser(userId, UserGame.colWorkers, UserGame.zp, UserGame.al, UserGame.dayOfStrike, UserGame.strike);
        }

        public void SaleAuto(int idMashin, int userId)
        {
            Auto mashina = db.Autoes.Where(c => (c.id == idMashin && c.userId == userId)).FirstOrDefault();
            db.Autoes.Remove(mashina);
            db.SaveChanges();
            workMoney.AddMoney(mashina.content/2, userId);
        }
    }
}