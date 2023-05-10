using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pipe_and_filte.Models;

namespace Pipe_and_filte.Controllers
{
    public class RFQsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RFQs
        public ActionResult Index()
        {
            var rFQ = db.RFQ.Include(r => r.filed);
            return View(rFQ.ToList());
        }

        // GET: RFQs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.RFQ.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            return View(rFQ);
        }

        // GET: RFQs/Create
        public ActionResult Create()
        {
            ViewBag.filedID = new SelectList(db.filed, "id", "filedName");
            return View();
        }

        // POST: RFQs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,description,filedID,dirationdays")] RFQ rFQ)
        {
            if (ModelState.IsValid)
            {
                db.RFQ.Add(rFQ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.filedID = new SelectList(db.filed, "id", "filedName", rFQ.filedID);
            return View(rFQ);
        }

        // GET: RFQs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.RFQ.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            ViewBag.filedID = new SelectList(db.filed, "id", "filedName", rFQ.filedID);
            return View(rFQ);
        }

        // POST: RFQs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,description,filedID,dirationdays")] RFQ rFQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rFQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.filedID = new SelectList(db.filed, "id", "filedName", rFQ.filedID);
            return View(rFQ);
        }

        // GET: RFQs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.RFQ.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            return View(rFQ);
        }

        // POST: RFQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RFQ rFQ = db.RFQ.Find(id);
            db.RFQ.Remove(rFQ);
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
