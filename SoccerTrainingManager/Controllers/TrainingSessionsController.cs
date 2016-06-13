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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.IO;

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

        public FileResult CreatePDF()
        {
            //get needed objects for IText
            //MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            string PdfFileName = ("TrainingTest" + ".pdf");
            //create document with some dimension
            Document document = new Document();
            document.SetMargins(72, 72, 72, 72);
            //create writer object, with specified output stream
            var output = new MemoryStream();

            var writer = PdfWriter.GetInstance(document, output);
            writer.CloseStream = false;

            document.Open();
            //declare text format for future use
            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            document.Add(new Paragraph("Training Session", titleFont));

            //declare format of table
            var bidInfoTable = new PdfPTable(2);
            bidInfoTable.HorizontalAlignment = 0;
            bidInfoTable.SpacingBefore = 10;
            bidInfoTable.SpacingAfter = 10;
            bidInfoTable.DefaultCell.Border = 0;
            bidInfoTable.SetWidths(new int[] { 1, 4 });

            //add information to cells in table (no border)
            //modify IronPDF for IText
            //alter format--center info, create spacing for client sig and date
            bidInfoTable.AddCell(new Phrase("Warm Up", boldTableFont));
            bidInfoTable.AddCell("Jog");
            bidInfoTable.AddCell(new Phrase("Technical Drill", boldTableFont));
            bidInfoTable.AddCell("Andy Lee Shalke Drill");
            bidInfoTable.AddCell(new Phrase("Possession Drill", boldTableFont));
            bidInfoTable.AddCell("BlackJack 21");
            bidInfoTable.AddCell(new Phrase("Shooting Drill", boldTableFont));
            bidInfoTable.AddCell("Caleb Porter Shooting");
            bidInfoTable.AddCell(new Phrase("Fitness", boldTableFont));
            bidInfoTable.AddCell("None");
            bidInfoTable.AddCell(new Phrase("Rating", boldTableFont));
            bidInfoTable.AddCell("5");
            

            //adds contents to pdf
            document.Add(bidInfoTable);

            //var logo = iTextSharp.text.Image.GetInstance(Server.MapPath(filePath))

            document.Close();

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content", PdfFileName);
            //Response.BinaryWrite(output.ToArray());

            byte[] byteInfo = output.ToArray();
            output.Write(byteInfo, 0, byteInfo.Length);
            output.Position = 0;

            return File(output, "application/pdf", PdfFileName);

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
