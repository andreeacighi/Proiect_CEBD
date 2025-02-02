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
    public class PACIENTIsController : Controller
    {
        private Entities db = new Entities();

        // GET: PACIENTIs
        public ActionResult Index(string sortBy = "ID_PACIENT", string sortOrder = "asc")
        {
            // Setăm lista de criterii pentru sortare
            ViewBag.SortByList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Nume", Value = "NUME" },
        new SelectListItem { Text = "Adresă", Value = "ADRESA" }
    };

            // Setăm lista pentru ordinele de sortare
            ViewBag.SortOrderList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Crescător", Value = "asc" },
        new SelectListItem { Text = "Descrescător", Value = "desc" }
    };

            var pacienti = from p in db.PACIENTIs
                           select p;

            // Aplicăm sortarea după selecțiile utilizatorului
            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "NUME":
                        pacienti = sortOrder == "desc" ? pacienti.OrderByDescending(p => p.NUME) : pacienti.OrderBy(p => p.NUME);
                        break;
                    case "ADRESA":
                        pacienti = sortOrder == "desc" ? pacienti.OrderByDescending(p => p.ADRESA) : pacienti.OrderBy(p => p.ADRESA);
                        break;
                    default:
                        pacienti = pacienti.OrderBy(p => p.ID_PACIENT); // Sortare implicită
                        break;
                }
            }

            return View(pacienti.ToList());
        }

        // GET: PACIENTIs/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTI pACIENTI = db.PACIENTIs.Find(id);
            if (pACIENTI == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTI);
        }

        // GET: PACIENTIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PACIENTIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PACIENT,NUME,PRENUME,CNP,ASIGURARE,CARD_SANATATE,ADRESA,TELEFON")] PACIENTI pACIENTI)
        {
            if (ModelState.IsValid)
            {
                db.PACIENTIs.Add(pACIENTI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pACIENTI);
        }

        // GET: PACIENTIs/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTI pACIENTI = db.PACIENTIs.Find(id);
            if (pACIENTI == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTI);
        }

        // POST: PACIENTIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PACIENT,NUME,PRENUME,CNP,ASIGURARE,CARD_SANATATE,ADRESA,TELEFON")] PACIENTI pACIENTI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACIENTI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pACIENTI);
        }

        // GET: PACIENTIs/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTI pACIENTI = db.PACIENTIs.Find(id);
            if (pACIENTI == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTI);
        }

        // POST: PACIENTIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PACIENTI pACIENTI = db.PACIENTIs.Find(id);
            db.PACIENTIs.Remove(pACIENTI);
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
