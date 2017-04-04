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
    public class ValuesisController : Controller
    {
        private efcv2DBEntities db = new efcv2DBEntities();

        // GET: Valuesis
        public ActionResult Index()
        {
            var valuesis = db.Valuesis.Include(v => v.Sensori);
            return View(valuesis.ToList());
        }

        // GET: Valuesis/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valuesi valuesi = db.Valuesis.Find(id);
            if (valuesi == null)
            {
                return HttpNotFound();
            }
            return View(valuesi);
        }

        // GET: Valuesis/Create
        public ActionResult Create()
        {
            ViewBag.SensoriID = new SelectList(db.Sensoris, "SensoriID", "SensorDescr");
            return View();
        }

        // POST: Valuesis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValueiID,SensoriID,Value,TimeStamp")] Valuesi valuesi)
        {
            if (ModelState.IsValid)
            {
                db.Valuesis.Add(valuesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SensoriID = new SelectList(db.Sensoris, "SensoriID", "SensorDescr", valuesi.SensoriID);
            return View(valuesi);
        }

        // GET: Valuesis/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valuesi valuesi = db.Valuesis.Find(id);
            if (valuesi == null)
            {
                return HttpNotFound();
            }
            ViewBag.SensoriID = new SelectList(db.Sensoris, "SensoriID", "SensorDescr", valuesi.SensoriID);
            return View(valuesi);
        }

        // POST: Valuesis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValueiID,SensoriID,Value,TimeStamp")] Valuesi valuesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valuesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SensoriID = new SelectList(db.Sensoris, "SensoriID", "SensorDescr", valuesi.SensoriID);
            return View(valuesi);
        }

        // GET: Valuesis/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valuesi valuesi = db.Valuesis.Find(id);
            if (valuesi == null)
            {
                return HttpNotFound();
            }
            return View(valuesi);
        }

        // POST: Valuesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Valuesi valuesi = db.Valuesis.Find(id);
            db.Valuesis.Remove(valuesi);
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
