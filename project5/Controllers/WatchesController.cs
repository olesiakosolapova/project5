using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using project5.Models;

namespace project5.Controllers
{
    public class WatchesController : Controller
    {
        private BBBContext db = new BBBContext();

        // GET: Watches
        public ActionResult Index()
        {
            var watches = db.Watches.Include(w => w.Brands).Include(w => w.Variations);
            return View(watches.ToList());
        }

        // GET: Watches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watche watche = db.Watches.Find(id);
            if (watche == null)
            {
                return HttpNotFound();
            }
            return View(watche);
        }

        // GET: Watches/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name");
            ViewBag.VariationId = new SelectList(db.Variations, "VariationId", "Name");
            return View();
        }

        // POST: Watches/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VariationId,BrandId,Title,Year,Price,WatchesBrandUrl")] Watche watche)
        {
            if (ModelState.IsValid)
            {
                db.Watches.Add(watche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", watche.BrandId);
            ViewBag.VariationId = new SelectList(db.Variations, "VariationId", "Name", watche.VariationId);
            return View(watche);
        }

        // GET: Watches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watche watche = db.Watches.Find(id);
            if (watche == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", watche.BrandId);
            ViewBag.VariationId = new SelectList(db.Variations, "VariationId", "Name", watche.VariationId);
            return View(watche);
        }

        // POST: Watches/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VariationId,BrandId,Title,Year,Price,WatchesBrandUrl")] Watche watche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", watche.BrandId);
            ViewBag.VariationId = new SelectList(db.Variations, "VariationId", "Name", watche.VariationId);
            return View(watche);
        }

        // GET: Watches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Watche watche = db.Watches.Find(id);
            if (watche == null)
            {
                return HttpNotFound();
            }
            return View(watche);
        }

        // POST: Watches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Watche watche = db.Watches.Find(id);
            db.Watches.Remove(watche);
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
