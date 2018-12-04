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
