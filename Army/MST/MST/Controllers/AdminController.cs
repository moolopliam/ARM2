using MST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MST.Controllers
{
    public class AdminController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

    }
}