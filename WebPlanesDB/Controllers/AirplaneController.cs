using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPlanesDB.Models;
using WebPlanesDB.DAL;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace WebPlanesDB.Controllers
{
    public class AirplaneController : Controller
    {
        private PlaneContext db = new PlaneContext();
        // GET: Airplane
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var airplanes = from s in db.Airplanes
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                airplanes = airplanes.Where(s => s.Nbort.ToString().Contains(searchString)
                                      );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    airplanes = airplanes.OrderByDescending(s => s.Nbort);
                    break;
                default:  // Name ascending 
                    airplanes = airplanes.OrderBy(s => s.Nbort);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(airplanes.ToPagedList(pageNumber, pageSize));
        }

       

        // GET: /Airplane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // GET: /Airplane/Create
        public ActionResult Create()
        {
            ViewBag.FlightID = new SelectList(db.Flights, "FlightID", "FlightID");
            ViewBag.TrassaID = new SelectList(db.Trassas, "TrassaID", "TrassaID");
            return View();
        }

        // POST: /Airplane/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AirplaneID,Nbort,type,FlightID,dataInspection,places,TrassaID")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Airplanes.Add(airplane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightID = new SelectList(db.Flights, "FlightID", "FlightID", airplane.FlightID);
            ViewBag.TrassaID = new SelectList(db.Trassas, "TrassaID", "TrassaID", airplane.TrassaID);
            return View(airplane);
        }

        // GET: /Airplane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightID = new SelectList(db.Flights, "FlightID", "FlightID", airplane.FlightID);
            ViewBag.TrassaID = new SelectList(db.Trassas, "TrassaID", "TrassaID", airplane.TrassaID);
            return View(airplane);
        }

        // POST: /Airplane/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AirplaneID,Nbort,type,FlightID,dataInspection,places,TrassaID")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightID = new SelectList(db.Flights, "FlightID", "FlightID", airplane.FlightID);
            ViewBag.TrassaID = new SelectList(db.Trassas, "TrassaID", "TrassaID", airplane.TrassaID);
            return View(airplane);
        }

        // GET: /Airplane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // POST: /Airplane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            db.Airplanes.Remove(airplane);
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
