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
    public class tblRegistracijasController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblRegistracijas
        public ActionResult Index()
        {
            return View(db.tblRegistracijas.ToList());
        }

        // GET: tblRegistracijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistracija tblRegistracija = db.tblRegistracijas.Find(id);
            if (tblRegistracija == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistracija);
        }

        // GET: tblRegistracijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblRegistracijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistracijaID,DatumRegistracije,DatumIsteka,Cena,RegistarskiBroj")] tblRegistracija tblRegistracija)
        {
            if (ModelState.IsValid)
            {
                db.tblRegistracijas.Add(tblRegistracija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRegistracija);
        }

        // GET: tblRegistracijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistracija tblRegistracija = db.tblRegistracijas.Find(id);
            if (tblRegistracija == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistracija);
        }

        // POST: tblRegistracijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistracijaID,DatumRegistracije,DatumIsteka,Cena,RegistarskiBroj")] tblRegistracija tblRegistracija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRegistracija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRegistracija);
        }

        // GET: tblRegistracijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRegistracija tblRegistracija = db.tblRegistracijas.Find(id);
            if (tblRegistracija == null)
            {
                return HttpNotFound();
            }
            return View(tblRegistracija);
        }

        // POST: tblRegistracijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRegistracija tblRegistracija = db.tblRegistracijas.Find(id);
            db.tblRegistracijas.Remove(tblRegistracija);
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
