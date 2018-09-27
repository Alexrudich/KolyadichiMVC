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
    public class StepCargoesController : Controller
    {
        private xmlVagonsEntities db = new xmlVagonsEntities();

        // GET: StepCargoes
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            var stepCargoUnits = from s in db.StepCargoes select s;
            #region search
            if (!String.IsNullOrEmpty(searchString))
            {
                stepCargoUnits = stepCargoUnits.Where(a => a.RegistrationNumber.Contains(searchString)
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
            //return View(db.PurchaseOrders.OrderBy(i => i.SomeProperty).ToPagedList(page ?? 1, 3));
            return View(stepCargoUnits.OrderBy(i=>i.TransportNumber).ToPagedList(pageNumber, pageSize));
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
