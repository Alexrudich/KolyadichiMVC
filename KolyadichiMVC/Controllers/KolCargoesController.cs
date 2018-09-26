using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KolyadichiMVC.Models;

namespace KolyadichiMVC.Controllers
{
    public class KolCargoesController : Controller
    {
        private xmlVagonsEntities db = new xmlVagonsEntities();

        // GET: KolCargoes
        public ActionResult Index()
        {
            return View(db.KolCargoes.ToList());
        }

        // GET: KolCargoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KolCargo kolCargo = db.KolCargoes.Find(id);
            if (kolCargo == null)
            {
                return HttpNotFound();
            }
            return View(kolCargo);
        }

        // GET: KolCargoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KolCargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate")] KolCargo kolCargo)
        {
            if (ModelState.IsValid)
            {
                db.KolCargoes.Add(kolCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kolCargo);
        }

        // GET: KolCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KolCargo kolCargo = db.KolCargoes.Find(id);
            if (kolCargo == null)
            {
                return HttpNotFound();
            }
            return View(kolCargo);
        }

        // POST: KolCargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate")] KolCargo kolCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolCargo);
        }

        // GET: KolCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KolCargo kolCargo = db.KolCargoes.Find(id);
            if (kolCargo == null)
            {
                return HttpNotFound();
            }
            return View(kolCargo);
        }

        // POST: KolCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KolCargo kolCargo = db.KolCargoes.Find(id);
            db.KolCargoes.Remove(kolCargo);
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
