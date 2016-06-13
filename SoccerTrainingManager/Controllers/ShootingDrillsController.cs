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
    public class ShootingDrillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShootingDrills
        public ActionResult Index()
        {
            return View(db.ShootingDrills.ToList());
        }

        // GET: ShootingDrills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShootingDrill shootingDrill = db.ShootingDrills.Find(id);
            if (shootingDrill == null)
            {
                return HttpNotFound();
            }
            return View(shootingDrill);
        }

        // GET: ShootingDrills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShootingDrills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] ShootingDrill shootingDrill)
        {
            if (ModelState.IsValid)
            {
                db.ShootingDrills.Add(shootingDrill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shootingDrill);
        }

        // GET: ShootingDrills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShootingDrill shootingDrill = db.ShootingDrills.Find(id);
            if (shootingDrill == null)
            {
                return HttpNotFound();
            }
            return View(shootingDrill);
        }

        // POST: ShootingDrills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] ShootingDrill shootingDrill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shootingDrill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shootingDrill);
        }

        // GET: ShootingDrills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShootingDrill shootingDrill = db.ShootingDrills.Find(id);
            if (shootingDrill == null)
            {
                return HttpNotFound();
            }
            return View(shootingDrill);
        }

        // POST: ShootingDrills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShootingDrill shootingDrill = db.ShootingDrills.Find(id);
            db.ShootingDrills.Remove(shootingDrill);
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
