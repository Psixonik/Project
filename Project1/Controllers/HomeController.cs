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
using System.Net;

namespace Project1.Controllers
{

    public class HomeController : Controller
    {
        WorkInBDUsers workUser = new WorkInBDUsers();
        List<string> error = new List<string>();
        User user;
        bool reg = true;
        public ActionResult Index()
        {
            ViewBag.error = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string psw, string psw_repeat, string email)
        {
            error.Clear();
            reg = true;
            ErrorPsw(psw, psw_repeat);           
            if (reg)
            {
                psw = Hash(psw);
            }
            ErrorName(name);
            ErrorEmail(email);          
            ViewBag.error = error;
            if (reg)
            {
                user = new User(Static.UserGame.userId, name, psw, email, false);
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
        public ActionResult Enter()
        {
            return View();
        }
        public ActionResult ViewRegisterEmail()
        {
            ViewBag.user = workUser.GetLatest();
            return View();
        }
        public ActionResult RegisterEmail(string email)
        {

            ViewBag.txt = "";
            try
            {
                Random rnd = new Random();
                Static.Items.correctEmail = rnd.Next(Static.Items.minRnd, Static.Items.maxRnd);
                var fromAddress = new MailAddress("solovejv.1979@gmail.com");
                var fromPassword = "oaxktugkzezmkiyd";
                var toAddress = new MailAddress(email);


                string subject = "Код подтверждения";
                string body = Static.Items.correctEmail.ToString();

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })

                    smtp.Send(message);
                ViewBag.txt = "Yes";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), ex.Message);
                ViewBag.txt = ex.Message.ToString();
            }

            return View();
        }
        public ActionResult correctEmail(string code)
        {
            try
            {
                if (Static.Items.correctEmail == Convert.ToInt32(code))
                {
                    workUser.SetEmailBool(Static.UserGame.userId);
                }
            }
            catch { }
            return Redirect("/Start/Index");
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
 