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
    public class MusicStylesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: MusicStyles
        public ActionResult Index(int i = 0)
        {
            TempData["error6"] = null;
            if (i != 0)
            {
                TempData["error6"] = i;
            }
            return View(db.MusicStyle.ToList());
        }

        // GET: MusicStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicStyle musicStyle = db.MusicStyle.Find(id);
            if (musicStyle == null)
            {
                return HttpNotFound();
            }
            return View(musicStyle);
        }

        // GET: MusicStyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusicStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mstMusicStyleID,mstStyleName")] MusicStyle musicStyle)
        {
            if (ModelState.IsValid)
            {
                db.MusicStyle.Add(musicStyle);
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 1 });
            }

            return View(musicStyle);
        }

        // GET: MusicStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicStyle musicStyle = db.MusicStyle.Find(id);
            if (musicStyle == null)
            {
                return HttpNotFound();
            }
            return View(musicStyle);
        }

        // POST: MusicStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mstMusicStyleID,mstStyleName")] MusicStyle musicStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 2 });
            }
            return View(musicStyle);
        }

        // GET: MusicStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicStyle musicStyle = db.MusicStyle.Find(id);
            if (musicStyle == null)
            {
                return HttpNotFound();
            }
            return View(musicStyle);
        }

        // POST: MusicStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hk = db.Music.Where(a => a.msMStyleID == id).ToList();
            if (hk.Count == 0)
            {
                MusicStyle musicStyle = db.MusicStyle.Find(id);
                db.MusicStyle.Remove(musicStyle);
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
