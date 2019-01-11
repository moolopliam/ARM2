using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MST.Models;

namespace MST.Controllers
{
    public class MelodiesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Melodies
        public ActionResult Index()
        {
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
        public ActionResult Create([Bind(Include = "mlMelodyID,mlMelodyName")] Melody melody)
        {
            if (ModelState.IsValid)
            {
                db.Melody.Add(melody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(melody);
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
            return View(melody);
        }

        // POST: Melodies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mlMelodyID,mlMelodyName")] Melody melody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(melody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(melody);
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
            Melody melody = db.Melody.Find(id);
            db.Melody.Remove(melody);
            db.SaveChanges();
            return RedirectToAction("Index");
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
