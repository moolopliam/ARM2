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
    public class MusicStylesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: MusicStyles
        public ActionResult Index()
        {
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
            MusicStyle musicStyle = db.MusicStyle.Find(id);
            db.MusicStyle.Remove(musicStyle);
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
