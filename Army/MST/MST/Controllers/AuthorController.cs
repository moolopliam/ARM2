using MST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MST.Controllers
{
   
    public class AuthorController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();
        // GET: Author
        public ActionResult Index()
        {
            var data = db.Author.ToList();
            return View(data);
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create (Author data)
        {
            if (data.FileUpload != null)
            {
                byte[] Temp = new byte[data.FileUpload.ContentLength];
                data.FileUpload.InputStream.Read(Temp, 0, data.FileUpload.ContentLength);
                data.atPicture = Temp;

            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Albums.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch
            {

            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
