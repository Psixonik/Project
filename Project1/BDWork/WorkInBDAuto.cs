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

        public IEnumerable<Auto> GetAutoAll(int userId)//получить все машины игрока
        {
            IEnumerable<Auto> axez=db.Autoes.Where(c =>  c.UserId == userId);
            return axez;
        }
        public void SetAuto(int userId,string nameAuto, int services, int content, sbyte broken)//игрок купил новую машину
        {
            Auto auto = new Auto { UserId=userId,NameAuto = nameAuto, Services = services, Content = content, Broken = broken };
            db.Autoes.Add(auto);
            db.SaveChanges();
        }

        public Auto GetAutoById(int id,int userId)//конкретная машина игрока
        {
            return db.Autoes.Where(c => (c.Id == id && c.UserId==userId)).FirstOrDefault();
        }

        public void JobsEnd(int id, int userId)//машина отработала
        {
            Auto mashina =db.Autoes.Where(c => (c.Id == id && c.UserId == userId)).FirstOrDefault();
            mashina.Broken = 0;//Магическое число
            db.SaveChanges();
        }

        public void Broken(int id, int userId)//машина сламалась
        {
            Auto mashina = db.Autoes.Where(c => (c.Id == id && c.UserId == userId)).FirstOrDefault();
            mashina.Broken = -1;//Магическое число
            db.SaveChanges();
        }

        public int GetContent(int id, int userId)//сколько машина может заработать
        {
            Auto mashina = db.Autoes.Where(c => (c.Id == id && c.UserId == userId)).FirstOrDefault();
            return mashina.MaxContent;
        }

        public void SetBroken(int broken, int id, int userId)//состояние машины (отработала, сламалась)
        {
            Auto mashina = db.Autoes.Where(c => (c.Id == id && c.UserId == userId)).FirstOrDefault();
            mashina.Broken = broken;
            db.SaveChanges();
        }

        public void ShowBrokenOrJobs(int userId)//если машина не сломана, установить для неё статус - "готова к работе"
        {
            List<int> arr = new List<int>();
            Auto[] autos = db.Autoes.ToArray();
            foreach (Auto item in db.Autoes)
            {
                if (item.Broken == 0)
                {
                    arr.Add(item.Id);
                }
            }
            for (int i = 0; i < arr.Count; i++)
            {
                int axez = arr.ElementAt(i);
                Auto auto = db.Autoes.Where(c => (c.Id == axez && c.UserId == userId)).FirstOrDefault();
                if (auto != null)
                {
                    auto.Broken = 1;
                }
                db.SaveChanges();
            }
        }

        public void DeletUserAndCreateNew(int userId)//удаление машин игрока
        {
            IList<Auto> autoes = db.Autoes.Where(c => c.UserId == userId).ToArray();

            if (autoes != null)
            {
                for (int i = 0; i < autoes.Count(); i++)
                {
                    db.Autoes.Remove(autoes[i]);
                    db.SaveChanges();
                }
            }
        }

        public void SaleAuto(int idMashin, int userId)//продажа машины
        {
            Auto mashina = db.Autoes.Where(c => (c.Id == idMashin && c.UserId == userId)).FirstOrDefault();
            db.Autoes.Remove(mashina);
            db.SaveChanges();
            workMoney.AddMoney(mashina.Content/2, userId);
        }
    }
}