using Project1.BDWork;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class ForgotController : Controller
    {
        WorkInBDUsers workUser = new WorkInBDUsers();
        List<string> error = new List<string>();
        bool reg = true;
        User user;
        // GET: Forgot
        public ActionResult Index()
        {
            error.Add("Повторная регистрация");
            ViewBag.error = error;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string name, string psw, string psw_repeat, string email)
        {
            ViewBag.error = "";
            if (name == null)
            {
                if (!workUser.Email(email))
                {
                    error.Add("Такого Email нет");
                }
                else
                {
                    if (!workUser.GetBoolEmailForEmail(email))
                    {
                        error.Add("Email не подтвержден");
                    }
                    else
                    {
                        error.Add("");
                    }
                }
                ViewBag.error = error;
                ViewBag.email = email;
            }
            else
            {
                error.Clear();
                reg = true;
                ErrorPsw(psw, psw_repeat);
                if (reg)
                {
                    psw = Hash(psw);
                }
                ErrorName(name);
                //ErrorEmail(email);
                ViewBag.error = error;
                if (reg)
                {
                    workUser.ReRegister(name, psw, email);
                    error.Add("Юзер повторно зарегестрирован");
                    return Redirect("/Home/Enter");
                }
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
        private void ErrorEmail(string email)
        {
            if (workUser.Email(email))
            {
                error.Add("Такой Email уже есть");
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
    }
}