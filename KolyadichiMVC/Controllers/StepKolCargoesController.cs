using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KolyadichiMVC.Models;
using PagedList;

namespace KolyadichiMVC.Controllers
{
    public class StepKolCargoesController : Controller
    {
        private KolyadichiXmlReaderEntities db = new KolyadichiXmlReaderEntities();

        public ActionResult Kolyadichi (string searchString, string currentFilter, int? page)
        {

            var StepKolCargoUnits = (from s in db.StepKolCargo select s).Where(a=>a.CargoStationId.Equals(1));

            #region search
            if (!String.IsNullOrEmpty(searchString))
            {
                StepKolCargoUnits = StepKolCargoUnits.Where(a => a.RegistrationNumber.Contains(searchString)
                                                              || a.SmgsNumber.Contains(searchString));
            }
            #endregion
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(StepKolCargoUnits.OrderBy(i => i.TransportNumber).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Stepyanka(string searchString, string currentFilter, int? page)
        {

            var StepKolCargoUnits = (from s in db.StepKolCargo select s).Where(a => a.CargoStationId.Equals(2));
            #region search
            if (!String.IsNullOrEmpty(searchString))
            {
                StepKolCargoUnits = StepKolCargoUnits.Where(a => a.RegistrationNumber.Contains(searchString)
                                                              || a.SmgsNumber.Contains(searchString));
            }
            #endregion
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(StepKolCargoUnits.OrderBy(i => i.TransportNumber).ToPagedList(pageNumber, pageSize));
        }
        // GET: StepKolCargoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepKolCargo stepKolCargo = db.StepKolCargo.Find(id);
            if (stepKolCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepKolCargo);
        }

        // GET: StepKolCargoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StepKolCargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate,CargoStationId")] StepKolCargo stepKolCargo)
        {
            if (ModelState.IsValid)
            {
                db.StepKolCargo.Add(stepKolCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stepKolCargo);
        }

        // GET: StepKolCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepKolCargo stepKolCargo = db.StepKolCargo.Find(id);
            if (stepKolCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepKolCargo);
        }

        // POST: StepKolCargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CargoUnitID,FileName,TransportNumber,SmgsNumber,SmgsDate,DeclarationNumber,DeclarationDate,AccountNumber,AccountDate,RegistrationNumber,RegistrationDate,TempDislocationNumber,TempDislocationDate,CargoStationId")] StepKolCargo stepKolCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stepKolCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stepKolCargo);
        }

        // GET: StepKolCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StepKolCargo stepKolCargo = db.StepKolCargo.Find(id);
            if (stepKolCargo == null)
            {
                return HttpNotFound();
            }
            return View(stepKolCargo);
        }

        // POST: StepKolCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StepKolCargo stepKolCargo = db.StepKolCargo.Find(id);
            db.StepKolCargo.Remove(stepKolCargo);
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
