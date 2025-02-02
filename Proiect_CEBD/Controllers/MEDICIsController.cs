using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Proiect_CEBD.Models;

namespace Proiect_CEBD.Controllers
{
    public class MEDICIsController : Controller
    {
        private Entities db = new Entities();

        // GET: MEDICIs
        public ActionResult Index()
        {
            var mEDICIs = db.MEDICIs.Include(m => m.SPECIALIZARI);
            return View(mEDICIs.ToList());
 
        }
        

        // GET: MEDICIs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICI mEDICI = db.MEDICIs.Find(id);
            if (mEDICI == null)
            {
                return HttpNotFound();
            }
            return View(mEDICI);
        }

        // GET: MEDICIs/Create
        public ActionResult Create()
        {
            ViewBag.SPECIALIZARI_ID = new SelectList(db.SPECIALIZARIs, "ID_SPECIALIZARE", "DENUMIRE");
            return View();
        }

        // POST: MEDICIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MEDIC,NUME,PRENUME,TELEFON,PARAFA_MEDIC,SPECIALIZARI_ID")] MEDICI mEDICI)
        {
            if (ModelState.IsValid)
            {
                db.MEDICIs.Add(mEDICI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SPECIALIZARI_ID = new SelectList(db.SPECIALIZARIs, "ID_SPECIALIZARE", "DENUMIRE", mEDICI.SPECIALIZARI_ID);
            return View(mEDICI);
        }

        // GET: MEDICIs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICI mEDICI = db.MEDICIs.Find(id);
            if (mEDICI == null)
            {
                return HttpNotFound();
            }
            ViewBag.SPECIALIZARI_ID = new SelectList(db.SPECIALIZARIs, "ID_SPECIALIZARE", "DENUMIRE", mEDICI.SPECIALIZARI_ID);
            return View(mEDICI);
        }

        // POST: MEDICIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MEDIC,NUME,PRENUME,TELEFON,PARAFA_MEDIC,SPECIALIZARI_ID")] MEDICI mEDICI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEDICI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SPECIALIZARI_ID = new SelectList(db.SPECIALIZARIs, "ID_SPECIALIZARE", "DENUMIRE", mEDICI.SPECIALIZARI_ID);
            return View(mEDICI);
        }

        // GET: MEDICIs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICI mEDICI = db.MEDICIs.Find(id);
            if (mEDICI == null)
            {
                return HttpNotFound();
            }
            return View(mEDICI);
        }

        // POST: MEDICIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MEDICI mEDICI = db.MEDICIs.Find(id);
            db.MEDICIs.Remove(mEDICI);
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
