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
        public ActionResult Index(string searchString, int? page)
        {
            var stepCargoUnits = from s in db.StepCargoes select s;
            //var stepCargoUnits = db.KolCargoes;
            #region search
            if (!String.IsNullOrEmpty(searchString))
            {
                stepCargoUnits = stepCargoUnits.Where(a => a.RegistrationNumber.Contains(searchString)
                                                          || a.SmgsNumber.Contains(searchString));
            }
            #endregion
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);

            //return View(stepCargoUnits.ToPagedList(pageNumber, pageSize));
            return View(stepCargoUnits.ToList());
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
