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
    public class StepCargoesController : Controller
    {
        private xmlVagonsEntities db = new xmlVagonsEntities();

        // GET: StepCargoes
        public ActionResult Index()
        {
            return View(db.StepCargoes.ToList());
        }

        // GET: StepCargoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepCargo stepCargo = db.StepCargoes.Find(id);
            if (stepCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepCargo);
        }

        // GET: StepCargoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StepCargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate")] StepCargo stepCargo)
        {
            if (ModelState.IsValid)
            {
                db.StepCargoes.Add(stepCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stepCargo);
        }

        // GET: StepCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepCargo stepCargo = db.StepCargoes.Find(id);
            if (stepCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepCargo);
        }

        // POST: StepCargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate")] StepCargo stepCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stepCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stepCargo);
        }

        // GET: StepCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepCargo stepCargo = db.StepCargoes.Find(id);
            if (stepCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepCargo);
        }

        // POST: StepCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StepCargo stepCargo = db.StepCargoes.Find(id);
            db.StepCargoes.Remove(stepCargo);
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
