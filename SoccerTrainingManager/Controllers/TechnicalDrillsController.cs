using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoccerTrainingManager.Models;

namespace SoccerTrainingManager.Controllers
{
    public class TechnicalDrillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TechnicalDrills
        public ActionResult Index()
        {
            return View(db.TechnicalDrills.ToList());
        }

        // GET: TechnicalDrills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalDrill technicalDrill = db.TechnicalDrills.Find(id);
            if (technicalDrill == null)
            {
                return HttpNotFound();
            }
            return View(technicalDrill);
        }

        // GET: TechnicalDrills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalDrills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TechnicalDrill technicalDrill)
        {
            if (ModelState.IsValid)
            {
                db.TechnicalDrills.Add(technicalDrill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicalDrill);
        }

        // GET: TechnicalDrills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalDrill technicalDrill = db.TechnicalDrills.Find(id);
            if (technicalDrill == null)
            {
                return HttpNotFound();
            }
            return View(technicalDrill);
        }

        // POST: TechnicalDrills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TechnicalDrill technicalDrill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicalDrill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technicalDrill);
        }

        // GET: TechnicalDrills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalDrill technicalDrill = db.TechnicalDrills.Find(id);
            if (technicalDrill == null)
            {
                return HttpNotFound();
            }
            return View(technicalDrill);
        }

        // POST: TechnicalDrills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicalDrill technicalDrill = db.TechnicalDrills.Find(id);
            db.TechnicalDrills.Remove(technicalDrill);
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
