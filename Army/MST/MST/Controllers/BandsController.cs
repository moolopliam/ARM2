using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MST.Models;

namespace MST.Controllers
{
    public class BandsController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Bands
        public ActionResult Index()
        {
            var data = db.Band.ToList();
            return View(data);
        }
        public ActionResult Indexl()
        {
            var data = db.Band.ToList();
            return View(data);
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

        public ActionResult Detailsl(int? id)
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
            if (data.FileUpload != null)
            {
                byte[] Temp = new byte[data.FileUpload.ContentLength];
                data.FileUpload.InputStream.Read(Temp, 0, data.FileUpload.ContentLength);
                data.bPicturebands = Temp;

            }
            try
            {
                db.Band.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }

           
            ViewBag.bBTypeID = new SelectList(db.BandType, "btBandTypeID", "btNameType", data.bBTypeID);
            ViewBag.bRecordID = new SelectList(db.Record, "rRecordID", "rRecordName", data.bRecordID);
            return View();
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

            if (ModelState.IsValid)
            {

                if (data.FileUpload != null)
                {
                    byte[] Temp = new byte[data.FileUpload.ContentLength];
                    data.FileUpload.InputStream.Read(Temp, 0, data.FileUpload.ContentLength);
                    data.bPicturebands = Temp;

                }
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewBag.bArtID = new SelectList(db.Arts, "aArtID", "aName", data.bArtID);
            //ViewBag.bBTypeID = new SelectList(db.BandTypes, "btBandTypeID", "btNameType", data.bBTypeID);
            //ViewBag.bRecordID = new SelectList(db.Records, "rRecordID", "rRecordName", data.bRecordID);
            return View(data);
        }

        //// GET: Bands/Delete/5
        public ActionResult Delete(int? bBandID)
        {
            if (bBandID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Band.Where(v => v.bBandID == bBandID).FirstOrDefault();
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Band.Find(id);
            db.Band.Remove(band);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


      
    }
}
