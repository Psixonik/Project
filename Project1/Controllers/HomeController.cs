using Project1.BDInitializer;
using Project1.BDWork;
using Project1.Context;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Net.Mail;

namespace Project1.Controllers
{

    public class HomeController : Controller
    {
        WorkInBDUsers workUser = new WorkInBDUsers();
        List<string> error = new List<string>();
        bool reg = true;
        public ActionResult Index()
        {
            ViewBag.error = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string psw,string psw_repeat)
        {
            error.Clear();
            reg = true;
            ErrorPsw(psw, psw_repeat);
            if (reg)
            {
                psw=Hash(psw);
            }
            ErrorName(name);
            ViewBag.error = error;
            if (reg)
            {
                User user = new User(Static.UserGame.userId, name, psw);
                workUser.SaveUser(user);
                Static.NewUser.CreatNewUser(user.id);
                error.Add("Юзер добавлен");
            }
            return View();
        }

        private void ErrorPsw(string psw, string psw_repeat)
        {
            if (psw != psw_repeat)
            {
                error.Add("Пароль и его подтверждение не совпадают");
                reg = false;
            }
        }
        private void ErrorName(string name)
        {
            if (workUser.Name(name))
            {
                error.Add("Такой пользователь уже есть");
                reg = false;
            }
        }
        private string Hash(string psw)
        {
            byte[] data = Encoding.Default.GetBytes(psw);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            psw = Convert.ToBase64String(result);
            return psw;
        }
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(string name, string psw)
        {
            psw=Hash(psw);
            string ansver = workUser.SearchUser(name, psw);
            try
            {
                int id = Convert.ToInt32(ansver);
                Static.UserGame.userId = id;

                return Redirect("/Start/Index");
            }
            catch (Exception e)
            {
                ViewBag.ansver = ansver;
                return View();
            }

        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
 