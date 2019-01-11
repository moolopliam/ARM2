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
    public class BandTypesController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: BandTypes
        public ActionResult Index()
        {
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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
            BandType bandType = db.BandType.Find(id);
            db.BandType.Remove(bandType);
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
