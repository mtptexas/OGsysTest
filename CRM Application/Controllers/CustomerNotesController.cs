using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRM_Application.Models;
using Microsoft.AspNet.Identity;

namespace CRM_Application.Controllers
{
    [Authorize]
    public class CustomerNotesController : Controller
    {
        private  CustomerNoteEntities db = new CustomerNoteEntities();
        private CustomerEntities dbCust = new CustomerEntities();

        // GET: CustomerNotes
        public ActionResult Index(int customerID)
        {
            ViewBag.CustomerID = customerID;
            var custData = dbCust.Customers.Where(c => c.CustomerID == customerID).ToList();
            ViewBag.CompanyName = custData[0].CompanyName;
            ViewBag.CustomerName = custData[0].FirstName + " " + custData[0].LastName;
            ViewBag.Address = custData[0].Address;

            return View(db.CustomerNotes.ToList().Where(c=>c.CustomerID==customerID));
        }

        // GET: CustomerNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerNote customerNote = db.CustomerNotes.Find(id);
            if (customerNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = customerNote.CustomerID;
            var custData = dbCust.Customers.Where(c => c.CustomerID == customerNote.CustomerID).ToList();
            ViewBag.CompanyName = custData[0].CompanyName;
            ViewBag.CustomerName = custData[0].FirstName + " " + custData[0].LastName;
            ViewBag.Address = custData[0].Address;
            return View(customerNote);
        }

        // GET: CustomerNotes/Create
        public ActionResult Create(int customerID)
        {
            ViewBag.CustomerID = customerID;
            var custData = dbCust.Customers.Where(c => c.CustomerID == customerID).ToList();
            ViewBag.CompanyName = custData[0].CompanyName;
            ViewBag.CustomerName = custData[0].FirstName + " " + custData[0].LastName;
            ViewBag.Address = custData[0].Address;
            return View();
        }

        // POST: CustomerNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerNoteID,CustomerID,Body,DateAdded,CreatedByUser")] CustomerNote customerNote)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var userID = User.Identity.GetUserId();
                customerNote.CreatedByUser = userName;
                customerNote.DateAdded = DateTime.Now;
                db.CustomerNotes.Add(customerNote);
                db.SaveChanges();
                customerNote.CreatedByUser = "ff";
                return RedirectToAction("Index", new { customerID = customerNote.CustomerID});
            }

            return View(customerNote);
        }

        // GET: CustomerNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerNote customerNote = db.CustomerNotes.Find(id);
            if (customerNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = customerNote.CustomerID;
            var custData = dbCust.Customers.Where(c => c.CustomerID == customerNote.CustomerID).ToList();
            ViewBag.CompanyName = custData[0].CompanyName;
            ViewBag.CustomerName = custData[0].FirstName + " " + custData[0].LastName;
            ViewBag.Address = custData[0].Address;
            return View(customerNote);
        }

        // POST: CustomerNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerNoteID,CustomerID,Body,DateAdded,CreatedByUser")] CustomerNote customerNote)
        {
            if (ModelState.IsValid)
            {
                customerNote.DateAdded = DateTime.Now;
                db.Entry(customerNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { customerID = customerNote.CustomerID });
            }
            return View(customerNote);
        }

        // GET: CustomerNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerNote customerNote = db.CustomerNotes.Find(id);
            if (customerNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = customerNote.CustomerID;
            var custData = dbCust.Customers.Where(c => c.CustomerID == customerNote.CustomerID).ToList();
            ViewBag.CompanyName = custData[0].CompanyName;
            ViewBag.CustomerName = custData[0].FirstName + " " + custData[0].LastName;
            ViewBag.Address = custData[0].Address;
            return View(customerNote);
        }

        // POST: CustomerNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerNote customerNote = db.CustomerNotes.Find(id);
            db.CustomerNotes.Remove(customerNote);
            db.SaveChanges();
            return RedirectToAction("Index", new { customerID = customerNote.CustomerID });
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
