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
    public class MelodiesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Melodies
        public ActionResult Index(int i = 0)
        {
            TempData["error8"] = null;
            if (i != 0)
            {
                TempData["error8"] = i;
            }
            return View(db.Melody.ToList());
        }

        // GET: Melodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melody melody = db.Melody.Find(id);
            if (melody == null)
            {
                return HttpNotFound();
            }
            return View(melody);
        }

        // GET: Melodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Melodies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Melody data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.mlLPic = Temp;
            }
            if (ModelState.IsValid)
            {
                db.Melody.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 1 });
            }

            return View(data);
        }

        // GET: Melodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melody melody = db.Melody.Find(id);
            if (melody == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", new { i = 2 });
        }

        // POST: Melodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Melody data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.mlLPic = Temp;
            }
            else
            {
                data.mlLPic = data.mlLPic;
            }
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // GET: Melodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melody melody = db.Melody.Find(id);
            if (melody == null)
            {
                return HttpNotFound();
            }
            return View(melody);
        }

        // POST: Melodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hk = db.Music.Where(a => a.msMelodyID == id).ToList();
            if (hk.Count == 0)
            {
                Melody melody = db.Melody.Find(id);
                db.Melody.Remove(melody);
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
