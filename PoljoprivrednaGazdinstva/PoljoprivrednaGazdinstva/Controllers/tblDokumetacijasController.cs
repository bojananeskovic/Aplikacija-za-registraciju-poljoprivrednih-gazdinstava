using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoljoprivrednaGazdinstva.Models;

namespace PoljoprivrednaGazdinstva.Controllers
{
    public class tblDokumetacijasController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblDokumetacijas
        public ActionResult Index()
        {
            var tblDokumetacijas = db.tblDokumetacijas.Include(t => t.tblEkspozitura);
            return View(tblDokumetacijas.ToList());
        }

        // GET: tblDokumetacijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDokumetacija tblDokumetacija = db.tblDokumetacijas.Find(id);
            if (tblDokumetacija == null)
            {
                return HttpNotFound();
            }
            return View(tblDokumetacija);
        }

        // GET: tblDokumetacijas/Create
        public ActionResult Create()
        {
            ViewBag.Ekspozitura = new SelectList(db.tblEkspozituras, "EkspozituraID", "Adresa");
            return View();
        }

        // POST: tblDokumetacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DokumetID,Vrsta,DatumIzdavanja,DatumIsteka,Mesto,Ekspozitura")] tblDokumetacija tblDokumetacija)
        {
            if (ModelState.IsValid)
            {
                db.tblDokumetacijas.Add(tblDokumetacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ekspozitura = new SelectList(db.tblEkspozituras, "EkspozituraID", "Adresa", tblDokumetacija.Ekspozitura);
            return View(tblDokumetacija);
        }

        // GET: tblDokumetacijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDokumetacija tblDokumetacija = db.tblDokumetacijas.Find(id);
            if (tblDokumetacija == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ekspozitura = new SelectList(db.tblEkspozituras, "EkspozituraID", "Adresa", tblDokumetacija.Ekspozitura);
            return View(tblDokumetacija);
        }

        // POST: tblDokumetacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DokumetID,Vrsta,DatumIzdavanja,DatumIsteka,Mesto,Ekspozitura")] tblDokumetacija tblDokumetacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDokumetacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ekspozitura = new SelectList(db.tblEkspozituras, "EkspozituraID", "Adresa", tblDokumetacija.Ekspozitura);
            return View(tblDokumetacija);
        }

        // GET: tblDokumetacijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDokumetacija tblDokumetacija = db.tblDokumetacijas.Find(id);
            if (tblDokumetacija == null)
            {
                return HttpNotFound();
            }
            return View(tblDokumetacija);
        }

        // POST: tblDokumetacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDokumetacija tblDokumetacija = db.tblDokumetacijas.Find(id);
            db.tblDokumetacijas.Remove(tblDokumetacija);
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
