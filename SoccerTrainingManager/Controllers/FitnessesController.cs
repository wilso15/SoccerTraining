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
    public class FitnessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fitnesses
        public ActionResult Index()
        {
            return View(db.Fitnesses.ToList());
        }

        // GET: Fitnesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fitness fitness = db.Fitnesses.Find(id);
            if (fitness == null)
            {
                return HttpNotFound();
            }
            return View(fitness);
        }

        // GET: Fitnesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fitnesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Fitness fitness)
        {
            if (ModelState.IsValid)
            {
                db.Fitnesses.Add(fitness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fitness);
        }

        // GET: Fitnesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fitness fitness = db.Fitnesses.Find(id);
            if (fitness == null)
            {
                return HttpNotFound();
            }
            return View(fitness);
        }

        // POST: Fitnesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Fitness fitness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fitness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fitness);
        }

        // GET: Fitnesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fitness fitness = db.Fitnesses.Find(id);
            if (fitness == null)
            {
                return HttpNotFound();
            }
            return View(fitness);
        }

        // POST: Fitnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fitness fitness = db.Fitnesses.Find(id);
            db.Fitnesses.Remove(fitness);
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
