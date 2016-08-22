using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ActivityDependenceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivityDependence
        public ActionResult Index()
        {
            var activityDependences = db.ActivityDependences.Include(a => a.BackwardActivity).Include(a => a.ForwardActivity);
            return View(activityDependences.ToList());
        }

        // GET: ActivityDependence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityDependence activityDependence = db.ActivityDependences.Find(id);
            if (activityDependence == null)
            {
                return HttpNotFound();
            }
            return View(activityDependence);
        }

        // GET: ActivityDependence/Create
        public ActionResult Create()
        {
            ViewBag.ForwardActivityId = new SelectList(db.Activities, "Id", "Name");
            ViewBag.BackwardActivityId = new SelectList(db.Activities, "Id", "Name");
            return View();
        }

        // POST: ActivityDependence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ForwardActivityId,BackwardActivityId,DependenceType")] ActivityDependence activityDependence)
        {
            if (ModelState.IsValid)
            {
                db.ActivityDependences.Add(activityDependence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ForwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.ForwardActivityId);
            ViewBag.BackwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.BackwardActivityId);
            return View(activityDependence);
        }

        // GET: ActivityDependence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityDependence activityDependence = db.ActivityDependences.Find(id);
            if (activityDependence == null)
            {
                return HttpNotFound();
            }
            ViewBag.ForwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.ForwardActivityId);
            ViewBag.BackwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.BackwardActivityId);
            return View(activityDependence);
        }

        // POST: ActivityDependence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ForwardActivityId,BackwardActivityId,DependenceType")] ActivityDependence activityDependence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityDependence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ForwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.ForwardActivityId);
            ViewBag.BackwardActivityId = new SelectList(db.Activities, "Id", "Name", activityDependence.BackwardActivityId);
            return View(activityDependence);
        }

        // GET: ActivityDependence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityDependence activityDependence = db.ActivityDependences.Find(id);
            if (activityDependence == null)
            {
                return HttpNotFound();
            }
            return View(activityDependence);
        }

        // POST: ActivityDependence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityDependence activityDependence = db.ActivityDependences.Find(id);
            db.ActivityDependences.Remove(activityDependence);
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
