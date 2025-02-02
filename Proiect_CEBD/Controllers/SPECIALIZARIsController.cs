using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proiect_CEBD.Models;

namespace Proiect_CEBD.Controllers
{
    public class SPECIALIZARIsController : Controller
    {
        private Entities db = new Entities();

        // GET: SPECIALIZARIs
        public ActionResult Index()
        {
            return View(db.SPECIALIZARIs.ToList());
        }

        // GET: SPECIALIZARIs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIALIZARI sPECIALIZARI = db.SPECIALIZARIs.Find(id);
            if (sPECIALIZARI == null)
            {
                return HttpNotFound();
            }
            return View(sPECIALIZARI);
        }

        // GET: SPECIALIZARIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SPECIALIZARIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPECIALIZARE,DENUMIRE")] SPECIALIZARI sPECIALIZARI)
        {
            if (ModelState.IsValid)
            {
                db.SPECIALIZARIs.Add(sPECIALIZARI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPECIALIZARI);
        }

        // GET: SPECIALIZARIs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIALIZARI sPECIALIZARI = db.SPECIALIZARIs.Find(id);
            if (sPECIALIZARI == null)
            {
                return HttpNotFound();
            }
            return View(sPECIALIZARI);
        }

        // POST: SPECIALIZARIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPECIALIZARE,DENUMIRE")] SPECIALIZARI sPECIALIZARI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPECIALIZARI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPECIALIZARI);
        }

        // GET: SPECIALIZARIs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIALIZARI sPECIALIZARI = db.SPECIALIZARIs.Find(id);
            if (sPECIALIZARI == null)
            {
                return HttpNotFound();
            }
            return View(sPECIALIZARI);
        }

        // POST: SPECIALIZARIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            SPECIALIZARI sPECIALIZARI = db.SPECIALIZARIs.Find(id);
            db.SPECIALIZARIs.Remove(sPECIALIZARI);
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
