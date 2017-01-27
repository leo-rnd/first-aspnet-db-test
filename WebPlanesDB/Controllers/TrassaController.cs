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

namespace WebPlanesDB.Controllers
{
    public class TrassaController : Controller
    {
        private PlaneContext db = new PlaneContext();

        // GET: /Trassa/
        public ActionResult Index()
        {
            return View(db.Trassas.ToList());
        }

        // GET: /Trassa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trassa trassa = db.Trassas.Find(id);
            if (trassa == null)
            {
                return HttpNotFound();
            }
            return View(trassa);
        }

        // GET: /Trassa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Trassa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TrassaID,x,y,h,V,time")] Trassa trassa)
        {
            if (ModelState.IsValid)
            {
                db.Trassas.Add(trassa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trassa);
        }

        // GET: /Trassa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trassa trassa = db.Trassas.Find(id);
            if (trassa == null)
            {
                return HttpNotFound();
            }
            return View(trassa);
        }

        // POST: /Trassa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TrassaID,x,y,h,V,time")] Trassa trassa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trassa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trassa);
        }

        // GET: /Trassa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trassa trassa = db.Trassas.Find(id);
            if (trassa == null)
            {
                return HttpNotFound();
            }
            return View(trassa);
        }

        // POST: /Trassa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trassa trassa = db.Trassas.Find(id);
            db.Trassas.Remove(trassa);
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
