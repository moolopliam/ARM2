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
    public class AlbumsController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Albums
        public ActionResult Index()
        {
            var data = db.Albums.ToList();
            return View(data);
        }

        public ActionResult Indexl()
        {
            var data = db.Albums.ToList();
            return View(data);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Where(a => a.alABID == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        public ActionResult Detailsl(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Where(a => a.alABID == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Albums data)
        {
            if (data.FileUpload != null)
            {
                byte[] Temp = new byte[data.FileUpload.ContentLength];
                data.FileUpload.InputStream.Read(Temp, 0, data.FileUpload.ContentLength);
                data.alPictureAlbums = Temp;

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

            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName", data.alBandID);
            return View(data);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Where(a => a.alABID == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName", album.alBandID);
            return View(album);
        }


        [HttpPost]
        public ActionResult Edit(Albums data)
        {
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName", data.alBandID);

            if (ModelState.IsValid)
            {

                if (data.FileUpload != null)
                {
                    byte[] Temp = new byte[data.FileUpload.ContentLength];
                    data.FileUpload.InputStream.Read(Temp, 0, data.FileUpload.ContentLength);
                    data.alPictureAlbums = Temp;

                }
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(data);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = db.Albums.Where(a => a.alABID == id).FirstOrDefault();
            //Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albums album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
