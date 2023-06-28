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
    public class tblPoljoprivrednoGazdinstvoesController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblPoljoprivrednoGazdinstvoes
        public ActionResult Index()
        {
            var tblPoljoprivrednoGazdinstvoes = db.tblPoljoprivrednoGazdinstvoes.Include(t => t.tblDokumetacija).Include(t => t.tblOsiguranje).Include(t => t.tblRegistracija).Include(t => t.tblVlasnik);
            return View(tblPoljoprivrednoGazdinstvoes.ToList());
        }

        // GET: tblPoljoprivrednoGazdinstvoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo = db.tblPoljoprivrednoGazdinstvoes.Find(id);
            if (tblPoljoprivrednoGazdinstvo == null)
            {
                return HttpNotFound();
            }
            return View(tblPoljoprivrednoGazdinstvo);
        }

        // GET: tblPoljoprivrednoGazdinstvoes/Create
        public ActionResult Create()
        {
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta");
            ViewBag.Osiguranje = new SelectList(db.tblOsiguranjes, "OsiguranjeID", "VrstaOsiguranja");
            ViewBag.Registracija = new SelectList(db.tblRegistracijas, "RegistracijaID", "Cena");
            ViewBag.Vlasnik = new SelectList(db.tblVlasniks, "VlasnikID", "Adresa");
            return View();
        }

        // POST: tblPoljoprivrednoGazdinstvoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoljoprivrednoGazdinstvoID,Vlasnik,Povrsina,Registracija,Osiguranje,Dokumentacija")] tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo)
        {
            if (ModelState.IsValid)
            {
                db.tblPoljoprivrednoGazdinstvoes.Add(tblPoljoprivrednoGazdinstvo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblPoljoprivrednoGazdinstvo.Dokumentacija);
            ViewBag.Osiguranje = new SelectList(db.tblOsiguranjes, "OsiguranjeID", "VrstaOsiguranja", tblPoljoprivrednoGazdinstvo.Osiguranje);
            ViewBag.Registracija = new SelectList(db.tblRegistracijas, "RegistracijaID", "Cena", tblPoljoprivrednoGazdinstvo.Registracija);
            ViewBag.Vlasnik = new SelectList(db.tblVlasniks, "VlasnikID", "Adresa", tblPoljoprivrednoGazdinstvo.Vlasnik);
            return View(tblPoljoprivrednoGazdinstvo);
        }

        // GET: tblPoljoprivrednoGazdinstvoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo = db.tblPoljoprivrednoGazdinstvoes.Find(id);
            if (tblPoljoprivrednoGazdinstvo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblPoljoprivrednoGazdinstvo.Dokumentacija);
            ViewBag.Osiguranje = new SelectList(db.tblOsiguranjes, "OsiguranjeID", "VrstaOsiguranja", tblPoljoprivrednoGazdinstvo.Osiguranje);
            ViewBag.Registracija = new SelectList(db.tblRegistracijas, "RegistracijaID", "Cena", tblPoljoprivrednoGazdinstvo.Registracija);
            ViewBag.Vlasnik = new SelectList(db.tblVlasniks, "VlasnikID", "Adresa", tblPoljoprivrednoGazdinstvo.Vlasnik);
            return View(tblPoljoprivrednoGazdinstvo);
        }

        // POST: tblPoljoprivrednoGazdinstvoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoljoprivrednoGazdinstvoID,Vlasnik,Povrsina,Registracija,Osiguranje,Dokumentacija")] tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPoljoprivrednoGazdinstvo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dokumentacija = new SelectList(db.tblDokumetacijas, "DokumetID", "Vrsta", tblPoljoprivrednoGazdinstvo.Dokumentacija);
            ViewBag.Osiguranje = new SelectList(db.tblOsiguranjes, "OsiguranjeID", "VrstaOsiguranja", tblPoljoprivrednoGazdinstvo.Osiguranje);
            ViewBag.Registracija = new SelectList(db.tblRegistracijas, "RegistracijaID", "Cena", tblPoljoprivrednoGazdinstvo.Registracija);
            ViewBag.Vlasnik = new SelectList(db.tblVlasniks, "VlasnikID", "Adresa", tblPoljoprivrednoGazdinstvo.Vlasnik);
            return View(tblPoljoprivrednoGazdinstvo);
        }

        // GET: tblPoljoprivrednoGazdinstvoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo = db.tblPoljoprivrednoGazdinstvoes.Find(id);
            if (tblPoljoprivrednoGazdinstvo == null)
            {
                return HttpNotFound();
            }
            return View(tblPoljoprivrednoGazdinstvo);
        }

        // POST: tblPoljoprivrednoGazdinstvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPoljoprivrednoGazdinstvo tblPoljoprivrednoGazdinstvo = db.tblPoljoprivrednoGazdinstvoes.Find(id);
            db.tblPoljoprivrednoGazdinstvoes.Remove(tblPoljoprivrednoGazdinstvo);
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
