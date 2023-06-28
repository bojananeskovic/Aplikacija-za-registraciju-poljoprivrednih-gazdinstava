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
    public class tblInstitucijasController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblInstitucijas
        public ActionResult Index()
        {
            return View(db.tblInstitucijas.ToList());
        }

        // GET: tblInstitucijas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstitucija tblInstitucija = db.tblInstitucijas.Find(id);
            if (tblInstitucija == null)
            {
                return HttpNotFound();
            }
            return View(tblInstitucija);
        }

        // GET: tblInstitucijas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblInstitucijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstitucijaID,Naziv,Sediste")] tblInstitucija tblInstitucija)
        {
            if (ModelState.IsValid)
            {
                db.tblInstitucijas.Add(tblInstitucija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblInstitucija);
        }

        // GET: tblInstitucijas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstitucija tblInstitucija = db.tblInstitucijas.Find(id);
            if (tblInstitucija == null)
            {
                return HttpNotFound();
            }
            return View(tblInstitucija);
        }

        // POST: tblInstitucijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstitucijaID,Naziv,Sediste")] tblInstitucija tblInstitucija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInstitucija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblInstitucija);
        }

        // GET: tblInstitucijas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstitucija tblInstitucija = db.tblInstitucijas.Find(id);
            if (tblInstitucija == null)
            {
                return HttpNotFound();
            }
            return View(tblInstitucija);
        }

        // POST: tblInstitucijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInstitucija tblInstitucija = db.tblInstitucijas.Find(id);
            db.tblInstitucijas.Remove(tblInstitucija);
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
