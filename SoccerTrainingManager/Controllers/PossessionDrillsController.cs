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
    public class PossessionDrillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PossessionDrills
        public ActionResult Index()
        {
            return View(db.PossessionDrills.ToList());
        }

        // GET: PossessionDrills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossessionDrill possessionDrill = db.PossessionDrills.Find(id);
            if (possessionDrill == null)
            {
                return HttpNotFound();
            }
            return View(possessionDrill);
        }

        // GET: PossessionDrills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PossessionDrills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] PossessionDrill possessionDrill)
        {
            if (ModelState.IsValid)
            {
                db.PossessionDrills.Add(possessionDrill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(possessionDrill);
        }

        // GET: PossessionDrills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossessionDrill possessionDrill = db.PossessionDrills.Find(id);
            if (possessionDrill == null)
            {
                return HttpNotFound();
            }
            return View(possessionDrill);
        }

        // POST: PossessionDrills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] PossessionDrill possessionDrill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(possessionDrill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(possessionDrill);
        }

        // GET: PossessionDrills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PossessionDrill possessionDrill = db.PossessionDrills.Find(id);
            if (possessionDrill == null)
            {
                return HttpNotFound();
            }
            return View(possessionDrill);
        }

        // POST: PossessionDrills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PossessionDrill possessionDrill = db.PossessionDrills.Find(id);
            db.PossessionDrills.Remove(possessionDrill);
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
