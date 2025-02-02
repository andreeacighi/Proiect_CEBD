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
    public class CONSULTATIIsController : Controller
    {
        private Entities db = new Entities();

        // GET: CONSULTATIIs
        public ActionResult Index(string searchString)
        {
            var cONSULTATIIs = from c in db.CONSULTATIIs.Include(c => c.PROGRAMARI)
                               select c;
            // filtrare dupa spitalizare
            if (!String.IsNullOrEmpty(searchString))
            {
                cONSULTATIIs = cONSULTATIIs.Where(c => c.SPITALIZARE.Contains(searchString));
            }

            return View(cONSULTATIIs.ToList());
        }

        // GET: CONSULTATIIs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSULTATII cONSULTATII = db.CONSULTATIIs.Find(id);
            if (cONSULTATII == null)
            {
                return HttpNotFound();
            }
            return View(cONSULTATII);
        }

        // GET: CONSULTATIIs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROGRAMARE = new SelectList(db.PROGRAMARIs, "ID_PROGRAMARE", "ORA");
            return View();
        }

        // POST: CONSULTATIIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CONSULTATIE,DIAGNOSTIC,SPITALIZARE,RETETA,ID_PROGRAMARE")] CONSULTATII cONSULTATII)
        {
            if (ModelState.IsValid)
            {
                db.CONSULTATIIs.Add(cONSULTATII);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROGRAMARE = new SelectList(db.PROGRAMARIs, "ID_PROGRAMARE", "ORA", cONSULTATII.ID_PROGRAMARE);
            return View(cONSULTATII);
        }

        // GET: CONSULTATIIs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSULTATII cONSULTATII = db.CONSULTATIIs.Find(id);
            if (cONSULTATII == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROGRAMARE = new SelectList(db.PROGRAMARIs, "ID_PROGRAMARE", "ORA", cONSULTATII.ID_PROGRAMARE);
            return View(cONSULTATII);
        }

        // POST: CONSULTATIIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CONSULTATIE,DIAGNOSTIC,SPITALIZARE,RETETA,ID_PROGRAMARE")] CONSULTATII cONSULTATII)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONSULTATII).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROGRAMARE = new SelectList(db.PROGRAMARIs, "ID_PROGRAMARE", "ORA", cONSULTATII.ID_PROGRAMARE);
            return View(cONSULTATII);
        }

        // GET: CONSULTATIIs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONSULTATII cONSULTATII = db.CONSULTATIIs.Find(id);
            if (cONSULTATII == null)
            {
                return HttpNotFound();
            }
            return View(cONSULTATII);
        }

        // POST: CONSULTATIIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            CONSULTATII cONSULTATII = db.CONSULTATIIs.Find(id);
            db.CONSULTATIIs.Remove(cONSULTATII);
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
