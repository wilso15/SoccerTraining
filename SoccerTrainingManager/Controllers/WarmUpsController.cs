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
    public class WarmUpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WarmUps
        public ActionResult Index()
        {
            return View(db.WarmUps.ToList());
        }

        // GET: WarmUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmUp warmUp = db.WarmUps.Find(id);
            if (warmUp == null)
            {
                return HttpNotFound();
            }
            return View(warmUp);
        }

        // GET: WarmUps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WarmUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] WarmUp warmUp)
        {
            if (ModelState.IsValid)
            {
                db.WarmUps.Add(warmUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warmUp);
        }

        // GET: WarmUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmUp warmUp = db.WarmUps.Find(id);
            if (warmUp == null)
            {
                return HttpNotFound();
            }
            return View(warmUp);
        }

        // POST: WarmUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] WarmUp warmUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warmUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warmUp);
        }

        // GET: WarmUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarmUp warmUp = db.WarmUps.Find(id);
            if (warmUp == null)
            {
                return HttpNotFound();
            }
            return View(warmUp);
        }

        // POST: WarmUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarmUp warmUp = db.WarmUps.Find(id);
            db.WarmUps.Remove(warmUp);
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
