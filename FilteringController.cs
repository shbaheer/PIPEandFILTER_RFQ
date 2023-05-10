using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using Pipe_and_filte.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using System.Web.Configuration;

namespace Pipe_and_filte.Controllers
{
    public class FilteringController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();


        // GET: baidingCompanies
        public ActionResult StepOne(int id)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                
               
                string ss = "TRUNCATE TABLE stefOnes ";
                SqlCommand sq = new SqlCommand(ss,conn);
                conn.Open();
                sq.ExecuteNonQuery();
                conn.Close();
            }
            var baidingCompany = db.baidingCompany.Include(b => b.RFQ);
            ViewBag.RFQID = id;
            var da = (from b in db.baidingCompany
                      join r in db.RFQ on b.RFQID equals r.ID
                      select new
                      {
                          b.ID,
                          b.Nmae,
                          b.LicenseID,
                          b.Vilidation,
                          b.filed,
                          RFQ = r.Name,
                          b.diration,
                          b.cost,
                          b.RFQID
                      }
                    ).Where(x => x.RFQID == id).ToArray();
            
            
           

            stefOne sp = new stefOne();
            int i = da.Count();
            for (int f=0;f<i;f++)
                {
              
                sp.Name = da[f].Nmae;
                sp.LicenseID = da[f].LicenseID;
                sp.validation = da[f].Vilidation;
                sp.Filed = da[f].filed;
                sp.RFQ = da[f].RFQ;
                sp.Diration = da[f].diration;
                sp.Cost = da[f].cost;
                sp.RFQID = da[f].RFQID;
                db.stefOne.Add(sp);
                db.SaveChanges();
            }
            ViewBag.RFQID = da[0].RFQID;
            return  View(db.stefOne.ToList());

           
        }

        public ActionResult stepTwo(int RFQID)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {


                string ss = "TRUNCATE TABLE stepTwoes ";
                SqlCommand sq = new SqlCommand(ss, conn);
                conn.Open();
                sq.ExecuteNonQuery();
                conn.Close();
            }

            System.DateTime lastDay = new System.DateTime(2022,4, 30);

            var da = (from b in db.stefOne
                   
                      select new
                      {
                          b.ID,
                          b.Name,
                          b.LicenseID,
                          b.validation,
                          b.Filed,
                          RFQ = b.RFQ,
                          b.Diration,
                          b.Cost,
                          b.RFQID
                      }
                   ).Where(x => x.validation>lastDay).ToArray();
            stepTwo sp = new stepTwo();
            int i = da.Count();
            for (int f = 0; f < i; f++)
            {

                sp.Name = da[f].Name;
                sp.LicenseID = da[f].LicenseID;
                sp.validation = da[f].validation;
                sp.Filed = da[f].Filed;
                sp.RFQ = da[f].RFQ;
                sp.Diration = da[f].Diration;
                sp.Cost = da[f].Cost;
                sp.RFQID = da[f].RFQID;
                db.stepTwo.Add(sp);
                db.SaveChanges();
            }
            ViewBag.RFQID = RFQID;


            return View(db.stepTwo.ToList());
        }
        public ActionResult stepThree( int RFQID)
           
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {


                string ss = "TRUNCATE TABLE stepthrees ";
                SqlCommand sq = new SqlCommand(ss, conn);
                conn.Open();
                sq.ExecuteNonQuery();
                conn.Close();
            }
            var filed = (from r in db.RFQ join f in db.filed on r.filedID equals f.id
                         select new { f.filedName,r.ID }).Where(x=>x.ID==RFQID).ToList().FirstOrDefault();
            var da = (from b in db.stefOne

                      select new
                      {
                          b.ID,
                          b.Name,
                          b.LicenseID,
                          b.validation,
                          b.Filed,
                          RFQ = b.RFQ,
                          b.Diration,
                          b.Cost,
                          b.RFQID
                      }
               ).Where(x=>x.Filed==filed.filedName).ToArray();
            stepthree sp = new stepthree();
            int i = da.Count();
            for (int f = 0; f < i; f++)
            {

                sp.Name = da[f].Name;
                sp.LicenseID = da[f].LicenseID;
                sp.validation = da[f].validation;
                sp.Filed = da[f].Filed;
                sp.RFQ = da[f].RFQ;
                sp.Diration = da[f].Diration;
                sp.Cost = da[f].Cost;
                sp.RFQID = da[f].RFQID;
                db.stepthree.Add(sp);
                db.SaveChanges();
            }

            return View(db.stepthree.ToList());

        }
        public ActionResult stepFour()
        {


            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {


                string ss = "TRUNCATE TABLE stepfours ";
                SqlCommand sq = new SqlCommand(ss, conn);
                conn.Open();
                sq.ExecuteNonQuery();
                conn.Close();
            }

            var da = (from b in db.stepthree orderby b.Cost

                      select new
                      {
                          b.ID,
                          b.Name,
                          b.LicenseID,
                          b.validation,
                          b.Filed,
                          RFQ = b.RFQ,
                          b.Diration,
                          b.Cost,
                          b.RFQID
                      }
               ).FirstOrDefault();
            stepfour sp = new stepfour();
           
        

                sp.Name = da.Name;
                sp.LicenseID = da.LicenseID;
                sp.validation = da.validation;
                sp.Filed = da.Filed;
                sp.RFQ = da.RFQ;
                sp.Diration = da.Diration;
                sp.Cost = da.Cost;
                sp.RFQID = da.RFQID;
                db.stepfour.Add(sp);
                db.SaveChanges();
           
            ViewBag.Name = da.Name;
            ViewBag.LicensID =da.LicenseID;
            ViewBag.Diration =da.Diration;
            ViewBag.Cost =da.Cost;
            
            
            return View();

        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Filtering/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filtering/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filtering/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Filtering/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filtering/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Filtering/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
