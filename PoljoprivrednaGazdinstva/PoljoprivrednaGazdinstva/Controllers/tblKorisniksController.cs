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
    public class tblKorisniksController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblKorisniks
        public ActionResult Index()
        {
            return View(db.tblKorisniks.ToList());
        }

        // GET: tblKorisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKorisnik tblKorisnik = db.tblKorisniks.Find(id);
            if (tblKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(tblKorisnik);
        }

        // GET: tblKorisniks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblKorisniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisnikID,KorisnickoIme,Lozinka")] tblKorisnik tblKorisnik)
        {
            if (ModelState.IsValid)
            {
                db.tblKorisniks.Add(tblKorisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblKorisnik);
        }

        // GET: tblKorisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKorisnik tblKorisnik = db.tblKorisniks.Find(id);
            if (tblKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(tblKorisnik);
        }

        // POST: tblKorisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisnikID,KorisnickoIme,Lozinka")] tblKorisnik tblKorisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKorisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblKorisnik);
        }

        // GET: tblKorisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKorisnik tblKorisnik = db.tblKorisniks.Find(id);
            if (tblKorisnik == null)
            {
                return HttpNotFound();
            }
            return View(tblKorisnik);
        }

        // POST: tblKorisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKorisnik tblKorisnik = db.tblKorisniks.Find(id);
            db.tblKorisniks.Remove(tblKorisnik);
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
