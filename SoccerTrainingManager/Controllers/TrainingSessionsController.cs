using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoccerTrainingManager.Models;
using System.Collections;

namespace SoccerTrainingManager.Controllers
{
    public class TrainingSessionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrainingSessions
        public ActionResult Index()
        {
            return View(db.TrainingSessions.ToList());
        }

        // GET: TrainingSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            return View(trainingSession);
        }

        // GET: TrainingSessions/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> WarmUpItems = db.WarmUps.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.WarmUps = WarmUpItems;
            IEnumerable<SelectListItem> TechnicalDrillItems = db.TechnicalDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.TechnicalDrills = TechnicalDrillItems;
            IEnumerable<SelectListItem> PossessionDrillItems = db.PossessionDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.PossessionDrills = PossessionDrillItems;
            IEnumerable<SelectListItem> ShootingDrillItems = db.ShootingDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.ShootingDrills = ShootingDrillItems;
            IEnumerable<SelectListItem> FitnessItems = db.Fitnesses.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.Fitnesses = FitnessItems;
            IEnumerable<SelectListItem> RatingItems = db.Ratings.Select(s => new SelectListItem { Value = s.StarRating.ToString(), Text = s.StarRating });
            ViewBag.Ratings = RatingItems;
            return View();
        }

        public ActionResult GeneratePDF()
        {

            return View();
        }


        // POST: TrainingSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WarmUp,TechnicalDrill,PossessionDrill,ShootingDrill,Fitness,Rating")] TrainingSession trainingSession)
        {
            if (ModelState.IsValid)
            {
                db.TrainingSessions.Add(trainingSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingSession);
        }

        // GET: TrainingSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> WarmUpItems = db.WarmUps.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.WarmUps = WarmUpItems;
            IEnumerable<SelectListItem> TechnicalDrillItems = db.TechnicalDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.TechnicalDrills = TechnicalDrillItems;
            IEnumerable<SelectListItem> PossessionDrillItems = db.PossessionDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.PossessionDrills = PossessionDrillItems;
            IEnumerable<SelectListItem> ShootingDrillItems = db.ShootingDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.ShootingDrills = ShootingDrillItems;
            IEnumerable<SelectListItem> FitnessItems = db.Fitnesses.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.Fitnesses = FitnessItems;
            IEnumerable<SelectListItem> RatingItems = db.Ratings.Select(s => new SelectListItem { Value = s.StarRating.ToString(), Text = s.StarRating });
            ViewBag.Ratings = RatingItems;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            return View(trainingSession);
        }

        // POST: TrainingSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WarmUp,TechnicalDrill,PossessionDrill,ShootingDrill,Fitness,Rating")] TrainingSession trainingSession)
        {
            IEnumerable<SelectListItem> WarmUpItems = db.WarmUps.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.WarmUps = WarmUpItems;
            IEnumerable<SelectListItem> TechnicalDrillItems = db.TechnicalDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.TechnicalDrills = TechnicalDrillItems;
            IEnumerable<SelectListItem> PossessionDrillItems = db.PossessionDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.PossessionDrills = PossessionDrillItems;
            IEnumerable<SelectListItem> ShootingDrillItems = db.ShootingDrills.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.ShootingDrills = ShootingDrillItems;
            IEnumerable<SelectListItem> FitnessItems = db.Fitnesses.Select(s => new SelectListItem { Value = s.Name.ToString(), Text = s.Name });
            ViewBag.Fitnesses = FitnessItems;
            IEnumerable<SelectListItem> RatingItems = db.Ratings.Select(s => new SelectListItem { Value = s.StarRating.ToString(), Text = s.StarRating });
            ViewBag.Ratings = RatingItems;
            if (ModelState.IsValid)
            {
                db.Entry(trainingSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingSession);
        }

        // GET: TrainingSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            if (trainingSession == null)
            {
                return HttpNotFound();
            }
            return View(trainingSession);
        }

        // POST: TrainingSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingSession trainingSession = db.TrainingSessions.Find(id);
            db.TrainingSessions.Remove(trainingSession);
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
