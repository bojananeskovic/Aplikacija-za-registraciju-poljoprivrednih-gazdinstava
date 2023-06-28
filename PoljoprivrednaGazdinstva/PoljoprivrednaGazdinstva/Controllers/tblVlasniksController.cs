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
    public class tblVlasniksController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblVlasniks
        public ActionResult Index()
        {
            var tblVlasniks = db.tblVlasniks.Include(t => t.tblDokumetacija);
            return View(tblVlasniks.ToList());
        }

        // GET: tblVlasniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVlasnik tblVlasnik = db.tblVlasniks.Find(id);
            if (tblVlasnik == null)
            {
                return HttpNotFound();
            }
            return View(tblVlasnik);
        }

        // GET: tblVlasniks/Create
        public ActionResult Create()
        {
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta");
            return View();
        }

        // POST: tblVlasniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VlasnikID,Adresa,Grad,Email,Telefon,Dokumentacija,Ime,Prezime")] tblVlasnik tblVlasnik)
        {
            if (ModelState.IsValid)
            {
                db.tblVlasniks.Add(tblVlasnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblVlasnik.Dokumentacija);
            return View(tblVlasnik);
        }

        // GET: tblVlasniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVlasnik tblVlasnik = db.tblVlasniks.Find(id);
            if (tblVlasnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblVlasnik.Dokumentacija);
            return View(tblVlasnik);
        }

        // POST: tblVlasniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VlasnikID,Adresa,Grad,Email,Telefon,Dokumentacija,Ime,Prezime")] tblVlasnik tblVlasnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVlasnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblVlasnik.Dokumentacija);
            return View(tblVlasnik);
        }

        // GET: tblVlasniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVlasnik tblVlasnik = db.tblVlasniks.Find(id);
            if (tblVlasnik == null)
            {
                return HttpNotFound();
            }
            return View(tblVlasnik);
        }

        // POST: tblVlasniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVlasnik tblVlasnik = db.tblVlasniks.Find(id);
            db.tblVlasniks.Remove(tblVlasnik);
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
