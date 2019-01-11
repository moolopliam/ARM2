using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheMusic.Models;

namespace TheMusic.Controllers
{
    public class AuthorsController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Authors
        public ActionResult Index(int i = 0)
        {
            TempData["error7"] = null;
            if (i != 0)
            {
                TempData["error7"] = i;
            }
            return View(db.Author.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Author data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.atPicture = Temp;
            }

            if (ModelState.IsValid)
            {
                db.Author.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 1 });
            }

            return View(data);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.atPicture = Temp;
            }
            else
            {
                data.atPicture = data.atPicture;
            }
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 2 });
            }
            return View(data);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hk = db.Music.Where(a => a.msAuthorID == id).ToList();
            if (hk.Count == 0)
            {
                Author author = db.Author.Find(id);
                db.Author.Remove(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { i = 5 });
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
