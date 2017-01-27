using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPlanesDB.Models;
//using WebPlanesDB.ViewModels;
using WebPlanesDB.DAL;
using System.Data.Entity.Infrastructure;
using System.Collections;
//using System.Collections.Generic.IEnumerable[WebPlanesDB.Models.Flight];
namespace WebPlanesDB.Controllers
{
  
    public class FlightController : Controller
    {
        private PlaneContext db = new PlaneContext();

        // GET: /Flight/
        public ActionResult Index(int? id)
        {
            return View(db.Flights.ToList());
        }

     //   [HttpPost]
        public ActionResult NumbersPlanes()
        {
            var allAirplanes = db.Airplanes;
         //   var allFlights = db.Flights;
            IEnumerable<int> sh = new List<int>();//[2];
            IEnumerable<int> masID = new List<int>();
            int num = 0, id_ = 0;
            
            var air1Ar = new List<int>();
            var airAr = new List<int>();
            var flightAr = new List<int>();
            //var i = 0;
            foreach (Airplane airplane in allAirplanes) {
                air1Ar.Add(airplane.AirplaneID);
                airAr.Add(airplane.AirplaneID);
                flightAr.Add(airplane.FlightID);
            }
            for (var k = 0; k < air1Ar.Count; k++) {
                id_ = flightAr[k]; num = 1;
                for (var l = 0; l < airAr.Count; l++) {
                    if (airAr[k] != airAr[l]) {
                        if (flightAr[l] == flightAr[k])
                        {
                            num++;
                        }
                    }
                }
                ((List<int>)(sh)).Add(num); ((List<int>)(masID)).Add(id_);
            }
            var allFlights = db.Flights; IEnumerator<int> j;
            foreach (Flight fl in allFlights) {
                int k = 0;
                foreach (int mas in masID) {
                    if (mas == fl.FlightID) {
                       // j = masID.GetEnumerator();
                        fl.Numbers = sh.ElementAt(k);//.Current);
                       // k++;
                    }//viewModel.Numbers=short[];
                    k++;
                }
            }
            return View(db.Flights.ToList()); //
       /*      foreach (Flight fl in allFlights){         
                 ///string query = "INSERT Flight (Numbers) SELECT * FROM Airplane, COUNT(*) WHERE Airplane.FlightID = Flight.flightID";
                 ///string query = "SELECT * FROM Airplane, COUNT(*) AS fl.Numbers"
                 ///      + "WHERE Airplane.FlightID = fl.FlightID";
                 string query = "SELECT COUNT(*) As fl.Numbers  FROM Airplane"
                       + "WHERE Airplane.FlightID = fl.FlightID";
                 // string query = "SELECT * FROM Airplane WHERE Airplane.FLIGHTID = fl.FLIGHTID";
                 IEnumerable<Airplane> data = db.Database.SqlQuery<Airplane>(query);
                //   int Numbers= db.Database.SqlQuery<Airplane>(query);
                // DataReader.Close();
                 fl.Numbers =  data.Count();
                }
                 */              
        }  

 
        // GET: /Flight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: /Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Flight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="FlightID,NFlight,Nroute,timeOut,timeIn")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // GET: /Flight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: /Flight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="FlightID,NFlight,Nroute,timeOut,timeIn")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: /Flight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: /Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
