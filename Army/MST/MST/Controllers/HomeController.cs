using MST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MST.Controllers
{
   
    public class HomeController : Controller
    {
        readonly MusicStory5903Entities db = new MusicStory5903Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount data)
        {
            var Bank = db.UserAccount.Where(p => p.UserName == data.UserName && p.UserPassword == data.UserPassword).FirstOrDefault();
            if (Bank != null)
            {
                Session["UserBank"] = Bank;
                switch (Bank.UserTypeID)
                {
                    case 1: //ผู้จัดการ
                        return RedirectToAction("Index", "Admin");
                    case 2: //ผู้ใช้
                        return RedirectToAction("Index", "User");
                    default:
                        break;
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction(nameof(Index));
        }
    }
}