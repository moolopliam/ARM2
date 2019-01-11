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
    public class BandsController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Bands
        public ActionResult Index(int i = 0)
        {
            var band = db.Band.Include(b => b.BandType).Include(b => b.Record);
            TempData["error3"] = null;
            if (i != 0)
            {
                TempData["error3"] = i;
            }
            return View(band.ToList());
        }

        // GET: Bands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Bands/Create
        public ActionResult Create()
        {
            ViewBag.bBTypeID = new SelectList(db.BandType, "btBandTypeID", "btNameType");
            ViewBag.bRecordID = new SelectList(db.Record, "rRecordID", "rRecordName");
            return View();
        }

        // POST: Bands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Band data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.bPicturebands = Temp;
            }

            if (ModelState.IsValid)
            {
                db.Band.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 1 });
            }

            ViewBag.bBTypeID = new SelectList(db.BandType, "btBandTypeID", "btNameType", data.bBTypeID);
            ViewBag.bRecordID = new SelectList(db.Record, "rRecordID", "rRecordName", data.bRecordID);
            return View(data);
        }

        // GET: Bands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            ViewBag.bBTypeID = new SelectList(db.BandType, "btBandTypeID", "btNameType", band.bBTypeID);
            ViewBag.bRecordID = new SelectList(db.Record, "rRecordID", "rRecordName", band.bRecordID);
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Band data)
        {
            if (data.UpLoad != null)
            {
                byte[] Temp = new byte[data.UpLoad.ContentLength];
                data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                data.bPicturebands = Temp;
            }
            else
            {
                data.bPicturebands = data.bPicturebands;
            }
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { i = 2 });
            }
            ViewBag.bBTypeID = new SelectList(db.BandType, "btBandTypeID", "btNameType", data.bBTypeID);
            ViewBag.bRecordID = new SelectList(db.Record, "rRecordID", "rRecordName", data.bRecordID);
            return View(data);
        }

        // GET: Bands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hk = db.Albums.Where(a => a.alBandID == id).ToList();
            if (hk.Count == 0)
            {
                Band band = db.Band.Find(id);
                db.Band.Remove(band);
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
