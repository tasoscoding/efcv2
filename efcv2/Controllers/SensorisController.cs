using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using efcv2.Models;

namespace efcv2.Controllers
{
    public class SensorisController : Controller
    {
        private efcv2DBEntities db = new efcv2DBEntities();

        // GET: Sensoris
        public ActionResult Index()
        {
            return View(db.Sensoris.ToList());
        }

        // GET: Sensoris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensori sensori = db.Sensoris.Find(id);
            if (sensori == null)
            {
                return HttpNotFound();
            }
            return View(sensori);
        }

        // GET: Sensoris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sensoris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SensoriID,SensorDescr")] Sensori sensori)
        {
            if (ModelState.IsValid)
            {
                db.Sensoris.Add(sensori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sensori);
        }

        // GET: Sensoris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensori sensori = db.Sensoris.Find(id);
            if (sensori == null)
            {
                return HttpNotFound();
            }
            return View(sensori);
        }

        // POST: Sensoris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SensoriID,SensorDescr")] Sensori sensori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sensori);
        }

        // GET: Sensoris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensori sensori = db.Sensoris.Find(id);
            if (sensori == null)
            {
                return HttpNotFound();
            }
            return View(sensori);
        }

        // POST: Sensoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sensori sensori = db.Sensoris.Find(id);
            db.Sensoris.Remove(sensori);
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
