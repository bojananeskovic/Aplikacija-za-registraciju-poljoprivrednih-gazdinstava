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
    public class tblOsiguranjesController : Controller
    {
        private RegistracijaPoljoprivrednihGazdinstavaEntities db = new RegistracijaPoljoprivrednihGazdinstavaEntities();

        // GET: tblOsiguranjes
        public ActionResult Index()
        {
            return View(db.tblOsiguranjes.ToList());
        }

        // GET: tblOsiguranjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOsiguranje tblOsiguranje = db.tblOsiguranjes.Find(id);
            if (tblOsiguranje == null)
            {
                return HttpNotFound();
            }
            return View(tblOsiguranje);
        }

        // GET: tblOsiguranjes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblOsiguranjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OsiguranjeID,BrojPolise,VrstaOsiguranja")] tblOsiguranje tblOsiguranje)
        {
            if (ModelState.IsValid)
            {
                db.tblOsiguranjes.Add(tblOsiguranje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOsiguranje);
        }

        // GET: tblOsiguranjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOsiguranje tblOsiguranje = db.tblOsiguranjes.Find(id);
            if (tblOsiguranje == null)
            {
                return HttpNotFound();
            }
            return View(tblOsiguranje);
        }

        // POST: tblOsiguranjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OsiguranjeID,BrojPolise,VrstaOsiguranja")] tblOsiguranje tblOsiguranje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOsiguranje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOsiguranje);
        }

        // GET: tblOsiguranjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOsiguranje tblOsiguranje = db.tblOsiguranjes.Find(id);
            if (tblOsiguranje == null)
            {
                return HttpNotFound();
            }
            return View(tblOsiguranje);
        }

        // POST: tblOsiguranjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOsiguranje tblOsiguranje = db.tblOsiguranjes.Find(id);
            db.tblOsiguranjes.Remove(tblOsiguranje);
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
