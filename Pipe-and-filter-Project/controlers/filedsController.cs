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
    public class filedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: fileds
        public ActionResult Index()
        {
            return View(db.filed.ToList());
        }

        // GET: fileds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filed filed = db.filed.Find(id);
            if (filed == null)
            {
                return HttpNotFound();
            }
            return View(filed);
        }

        // GET: fileds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fileds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,filedName")] filed filed)
        {
            if (ModelState.IsValid)
            {
                db.filed.Add(filed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filed);
        }

        // GET: fileds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filed filed = db.filed.Find(id);
            if (filed == null)
            {
                return HttpNotFound();
            }
            return View(filed);
        }

        // POST: fileds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,filedName")] filed filed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filed);
        }

        // GET: fileds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filed filed = db.filed.Find(id);
            if (filed == null)
            {
                return HttpNotFound();
            }
            return View(filed);
        }

        // POST: fileds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            filed filed = db.filed.Find(id);
            db.filed.Remove(filed);
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
