using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheMusic.Models;
using System.Web.Mvc;

namespace TheMusic.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Albums
       private readonly  MusicStory5903Entities db = new MusicStory5903Entities();
        public ActionResult Index(int i=0)
        {
            var data = db.Albums.ToList();
            TempData["error"] = null;
            if (i != 0)
            {
                TempData["error"] = i;
            }
            return View(data);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Music.Where(a=>a.msABID == id).ToList();
            return View(data);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName");
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(Albums data)
        {
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName");
            try
            {
                if (data.UpLoad != null)
                {
                    byte[] Temp = new byte[data.UpLoad.ContentLength];
                    data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                    data.alPictureAlbums = Temp;
                }
                if (ModelState.IsValid)
                {
                  
                    db.Albums.Add(data);
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
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName");
            var data = db.Albums.FirstOrDefault(a => a.alABID == id);
            return View(data);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(Albums data)
        {
            ViewBag.alBandID = new SelectList(db.Band, "bBandID", "bBandName");
            try
            {
                if (data.UpLoad != null)
                {
                    byte[] Temp = new byte[data.UpLoad.ContentLength];
                    data.UpLoad.InputStream.Read(Temp, 0, data.UpLoad.ContentLength);
                    data.alPictureAlbums = Temp;
                }
                else
                {
                    data.alPictureAlbums = data.alPictureAlbums;
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
            var data = db.Albums.FirstOrDefault(s => s.alABID == id);
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
                    var chk = db.Music.Where(a => a.msABID == id).ToList();
                    if (chk.Count == 0)
                    {
                        var data = db.Albums.FirstOrDefault(a => a.alABID == id);
                        db.Albums.Remove(data);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", new { i = 5 });
                    }                                       
                
                }
                
            }
            catch
            {
            }
                return RedirectToAction("Index", new { i = 5 });
        }
    }
}
