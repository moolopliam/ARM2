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
    public class BandTypesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: BandTypes
        public ActionResult Index(int i = 0)
        {
            TempData["error5"] = null;
            if (i != 0)
            {
                TempData["error5"] = i;
            }
            return View(db.BandType.ToList());
        }

        // GET: BandTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandType bandType = db.BandType.Find(id);
            if (bandType == null)
            {
                return HttpNotFound();
            }
            return View(bandType);
        }

        // GET: BandTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BandTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "btBandTypeID,btNameType")] BandType bandType)
        {
            if (ModelState.IsValid)
            {
                db.BandType.Add(bandType);
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 1 });
            }

            return View(bandType);
        }

        // GET: BandTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandType bandType = db.BandType.Find(id);
            if (bandType == null)
            {
                return HttpNotFound();
            }
            return View(bandType);
        }

        // POST: BandTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "btBandTypeID,btNameType")] BandType bandType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bandType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 2 });
            }
            return View(bandType);
        }

        // GET: BandTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BandType bandType = db.BandType.Find(id);
            if (bandType == null)
            {
                return HttpNotFound();
            }
            return View(bandType);
        }

        // POST: BandTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = db.Band.Where(a => a.bBTypeID == id).ToList();
            if (data.Count == 0)
            {
                BandType bandType = db.BandType.Find(id);
                db.BandType.Remove(bandType);
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
