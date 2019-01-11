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
    public class MusicsController : Controller
    {
        private MusicStory5903Entities db = new MusicStory5903Entities();

        // GET: Musics
        public ActionResult Index()
        {
            var data = db.Music.ToList();
            return View(data);
        }

        public ActionResult Indexl()
        {
            var data = db.Music.ToList();
            return View(data);
        }
        // GET: Musics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        public ActionResult Detailsl(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }
        // GET: Musics/Create
        public ActionResult Create()
        {
            ViewBag.msAlbumsID = new SelectList(db.Albums, "msAlbumsID", "alAlbumsName");
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName");
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName");
            ViewBag.msBandID = new SelectList(db.Band, "bBandID", "bBandName");
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName");
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName");
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Music data)
        {

            if (data.FileUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(data.FileUpload.FileName);
                string extension = Path.GetExtension(data.FileUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                data.msMusicUpload = "~/Music/" + fileName;
                data.FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Music/"), fileName));
            }
            try
            {
                db.Music.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {

            }
    
            return View();
        }

        // GET: Musics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }

            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName", music.msABID);
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName", music.msAuthorID);
            ViewBag.msBandID = new SelectList(db.Band, "bBandID", "bBandName", music.msBandID);
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName", music.msMelodyID);
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName", music.msMStyleID);
            return View(music);
        }

        // POST: Musics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Music data)
        {
            if (ModelState.IsValid)
            {
               
                if (data.FileUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(data.FileUpload.FileName);
                    string extension = Path.GetExtension(data.FileUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    data.msMusicUpload = "~/Music/" + fileName;
                    data.FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Music/"), fileName));
                }
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName", data.msABID);
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName", data.msAuthorID);
            ViewBag.msBandID = new SelectList(db.Band, "bBandID", "bBandName", data.msBandID);
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName", data.msMelodyID);
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName", data.msMStyleID);
            return View(data);
        }

        // GET: Musics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Music music = db.Music.Find(id);
            db.Music.Remove(music);
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
