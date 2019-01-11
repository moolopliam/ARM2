using MST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MST.Controllers
{
    public class UserController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            var data = db.UserAccount.ToList();
            return View(data);
        }
    }
}
