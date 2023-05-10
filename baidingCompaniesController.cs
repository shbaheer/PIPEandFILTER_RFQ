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
    public class baidingCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: baidingCompanies
        public ActionResult Index()
        {
            var baidingCompany = db.baidingCompany.Include(b => b.RFQ);
            return View(baidingCompany.ToList());
        }

        // GET: baidingCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baidingCompany baidingCompany = db.baidingCompany.Find(id);
            if (baidingCompany == null)
            {
                return HttpNotFound();
            }
            return View(baidingCompany);
        }

        // GET: baidingCompanies/Create
        public ActionResult Create()
        {
            ViewBag.RFQID = new SelectList(db.RFQ, "ID", "Name");
            return View();
        }

        // POST: baidingCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nmae,LicenseID,Vilidation,filed,RFQID,diration,cost")] baidingCompany baidingCompany)
        {
            if (ModelState.IsValid)
            {
                db.baidingCompany.Add(baidingCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RFQID = new SelectList(db.RFQ, "ID", "Name", baidingCompany.RFQID);
            return View(baidingCompany);
        }

        // GET: baidingCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baidingCompany baidingCompany = db.baidingCompany.Find(id);
            if (baidingCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.RFQID = new SelectList(db.RFQ, "ID", "Name", baidingCompany.RFQID);
            return View(baidingCompany);
        }

        // POST: baidingCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nmae,LicenseID,Vilidation,filed,RFQID,diration,cost")] baidingCompany baidingCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baidingCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RFQID = new SelectList(db.RFQ, "ID", "Name", baidingCompany.RFQID);
            return View(baidingCompany);
        }

        // GET: baidingCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            baidingCompany baidingCompany = db.baidingCompany.Find(id);
            if (baidingCompany == null)
            {
                return HttpNotFound();
            }
            return View(baidingCompany);
        }

        // POST: baidingCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            baidingCompany baidingCompany = db.baidingCompany.Find(id);
            db.baidingCompany.Remove(baidingCompany);
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
