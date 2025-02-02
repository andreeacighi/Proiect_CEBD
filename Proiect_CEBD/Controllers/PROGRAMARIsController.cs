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
    public class PROGRAMARIsController : Controller
    {
        private Entities db = new Entities();

        // GET: PROGRAMARIs
        public ActionResult Index(string searchString)
        {
            var programari = from p in db.PROGRAMARIs
                             select p;

            // Filtrăm programările după numele medicului sau pacientului
            if (!String.IsNullOrEmpty(searchString))
            {
                programari = programari.Where(p => p.MEDICI.NUME.Contains(searchString)
                                                   || p.PACIENTI.NUME.Contains(searchString));
            }

            return View(programari.ToList());
        }

        // GET: PROGRAMARIs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMARI pROGRAMARI = db.PROGRAMARIs.Find(id);
            if (pROGRAMARI == null)
            {
                return HttpNotFound();
            }
            return View(pROGRAMARI);
        }

        

        // GET: PROGRAMARIs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MEDIC = new SelectList(db.MEDICIs, "ID_MEDIC", "NUME");
            ViewBag.ID_PACIENT = new SelectList(db.PACIENTIs, "ID_PACIENT", "NUME");
       
            return View();
        }

        // POST: PROGRAMARIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROGRAMARE,DATA,ORA,STATUS_PROGRAMARE,ID_MEDIC,ID_PACIENT")] PROGRAMARI pROGRAMARI)
        {
            if (ModelState.IsValid)
            {
                db.PROGRAMARIs.Add(pROGRAMARI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MEDIC = new SelectList(db.MEDICIs, "ID_MEDIC", "NUME", pROGRAMARI.ID_MEDIC);
            ViewBag.ID_PACIENT = new SelectList(db.PACIENTIs, "ID_PACIENT", "NUME", pROGRAMARI.ID_PACIENT);
            return View(pROGRAMARI);
        }

        // GET: PROGRAMARIs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMARI pROGRAMARI = db.PROGRAMARIs.Find(id);
            if (pROGRAMARI == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MEDIC = new SelectList(db.MEDICIs, "ID_MEDIC", "NUME", pROGRAMARI.ID_MEDIC);
            ViewBag.ID_PACIENT = new SelectList(db.PACIENTIs, "ID_PACIENT", "NUME", pROGRAMARI.ID_PACIENT);
            return View(pROGRAMARI);
        }

        // POST: PROGRAMARIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROGRAMARE,DATA,ORA,STATUS_PROGRAMARE,ID_MEDIC,ID_PACIENT")] PROGRAMARI pROGRAMARI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROGRAMARI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MEDIC = new SelectList(db.MEDICIs, "ID_MEDIC", "NUME", pROGRAMARI.ID_MEDIC);
            ViewBag.ID_PACIENT = new SelectList(db.PACIENTIs, "ID_PACIENT", "NUME", pROGRAMARI.ID_PACIENT);
            return View(pROGRAMARI);
        }

        // GET: PROGRAMARIs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRAMARI pROGRAMARI = db.PROGRAMARIs.Find(id);
            if (pROGRAMARI == null)
            {
                return HttpNotFound();
            }
            return View(pROGRAMARI);
        }

        // POST: PROGRAMARIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PROGRAMARI pROGRAMARI = db.PROGRAMARIs.Find(id);
            db.PROGRAMARIs.Remove(pROGRAMARI);
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
