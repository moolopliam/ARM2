using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMusic.Models;

namespace TheMusic.Controllers
{
    public class MusicsController : Controller
    {
        // GET: Music
        private readonly MusicStory5903Entities db = new MusicStory5903Entities();
        public ActionResult Index(int i = 0)
        {
            var data = db.Music.ToList();
            TempData["error11"] = null;
            if (i != 0)
            {
                TempData["error11"] = i;
            }
            return View(data);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            var data = db.Music.Where(a => a.msMusicID == id).FirstOrDefault();
            return View(data);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName");
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName");
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName");
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName");
            ViewBag.msBandID = new SelectList(db.Band, "bBandID", "bBandName");



            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(Music data)
        {
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName");
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName");
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName");
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName");
            try
            {
                if (data.UpLoadMP != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(data.UpLoadMP.FileName);
                    string extension = Path.GetExtension(data.UpLoadMP.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    data.msMusicUpload = "~/Music/" + fileName;
                    data.UpLoadMP.SaveAs(Path.Combine(Server.MapPath("~/Music/"), fileName));
                }
                if (ModelState.IsValid)
                {

                    db.Music.Add(data);
                    db.SaveChanges();

                }

                return RedirectToAction("Index", new { i = 1 });
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName");
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName");
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName");
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName");
            var data = db.Music.FirstOrDefault(a => a.msMusicID == id);
            return View(data);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(Music data)
        {
            ViewBag.msABID = new SelectList(db.Albums, "alABID", "alAlbumsName");
            ViewBag.msAuthorID = new SelectList(db.Author, "atAuthorID", "atAuthorName");
            ViewBag.msMelodyID = new SelectList(db.Melody, "mlMelodyID", "mlMelodyName");
            ViewBag.msMStyleID = new SelectList(db.MusicStyle, "mstMusicStyleID", "mstStyleName");
            try
            {
                if (data.UpLoadMP != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(data.UpLoadMP.FileName);
                    string extension = Path.GetExtension(data.UpLoadMP.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    data.msMusicUpload = "~/Music/" + fileName;
                    data.UpLoadMP.SaveAs(Path.Combine(Server.MapPath("~/Music/"), fileName));
                }
                else
                {
                    data.msMusicUpload = data.msMusicUpload;
                }
                if (ModelState.IsValid)
                {
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", new { i = 2 });
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = db.Music.FirstOrDefault(s => s.msMusicID == id);
            return View(data);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = db.Music.FirstOrDefault(a => a.msMusicID == id);
                    db.Music.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { i = 5 });
                }

            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}