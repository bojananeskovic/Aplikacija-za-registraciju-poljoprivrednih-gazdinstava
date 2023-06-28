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
    public class tblEkspoziturasController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblEkspozituras
        public ActionResult Index()
        {
            var tblEkspozituras = db.tblEkspozituras.Include(t => t.tblInstitucija);
            return View(tblEkspozituras.ToList());
        }

        // GET: tblEkspozituras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEkspozitura tblEkspozitura = db.tblEkspozituras.Find(id);
            if (tblEkspozitura == null)
            {
                return HttpNotFound();
            }
            return View(tblEkspozitura);
        }

        // GET: tblEkspozituras/Create
        public ActionResult Create()
        {
            ViewBag.Institucija = new SelectList(db.tblInstitucijas, "InstitucijaID", "Naziv");
            return View();
        }

        // POST: tblEkspozituras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EkspozituraID,Institucija,Adresa,Telefon,Grad")] tblEkspozitura tblEkspozitura)
        {
            if (ModelState.IsValid)
            {
                db.tblEkspozituras.Add(tblEkspozitura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Institucija = new SelectList(db.tblInstitucijas, "InstitucijaID", "Naziv", tblEkspozitura.Institucija);
            return View(tblEkspozitura);
        }

        // GET: tblEkspozituras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEkspozitura tblEkspozitura = db.tblEkspozituras.Find(id);
            if (tblEkspozitura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Institucija = new SelectList(db.tblInstitucijas, "InstitucijaID", "Naziv", tblEkspozitura.Institucija);
            return View(tblEkspozitura);
        }

        // POST: tblEkspozituras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EkspozituraID,Institucija,Adresa,Telefon,Grad")] tblEkspozitura tblEkspozitura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEkspozitura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Institucija = new SelectList(db.tblInstitucijas, "InstitucijaID", "Naziv", tblEkspozitura.Institucija);
            return View(tblEkspozitura);
        }

        // GET: tblEkspozituras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEkspozitura tblEkspozitura = db.tblEkspozituras.Find(id);
            if (tblEkspozitura == null)
            {
                return HttpNotFound();
            }
            return View(tblEkspozitura);
        }

        // POST: tblEkspozituras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEkspozitura tblEkspozitura = db.tblEkspozituras.Find(id);
            db.tblEkspozituras.Remove(tblEkspozitura);
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
