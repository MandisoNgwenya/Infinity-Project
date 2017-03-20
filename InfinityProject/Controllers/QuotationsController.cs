using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfinityProject.Models;
using Microsoft.AspNet.Identity;

namespace InfinityProject.Controllers
{
    public class QuotationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotations

        public ActionResult Index1( string searchString,string IDNumber)
        {
            Quotation b = new Quotation();
            //BookingViewModels b = new BookingViewModels();

            b.IDNumber = IDNumber;
       
            return View(b);
        }

        [HttpPost]
        public ActionResult Index1(string searchString)
        {
            try
            {
                Quotation q = new Quotation();
                BookingViewModels bID = new BookingViewModels();
                q.Id = Convert.ToInt32(User.Identity.GetUserId());
                q.IDNumber = bID.IDNumber;

                var booking = from b in db.BookingViewModels
                              select b;

                if (!String.IsNullOrEmpty(searchString))
                {
                    booking = booking.Where(x => x.Id.Contains(searchString));
                }
                q.IDNumber = User.Identity.GetUserId();
                return View(db.quotation.Where(x => x.IDNumber== q.IDNumber));
            }
            catch
            {
                return RedirectToAction("Register", "Account");
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.quotation.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // GET: Quotations/Create
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job_Card,Name,Description,Deposit,Total")] Quotation model)
        {
            if (ModelState.IsValid)
            {
                var quote = new Quotation();
                quote.Job_Card = model.Job_Card;
                quote.technician = model.technician;
                quote.Total = model.Total;
                quote.Deposit = quote.Deposit;
                quote.Description = model.Description;
                quote.Name = model.Name;
                quote.IDNumber = model.IDNumber;
                quote.Id = Convert.ToInt32(User.Identity.GetUserId());
         
                db.SaveChanges();
                return RedirectToAction("Index1");

            }

            return View(model);
        }

        // GET: Quotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.quotation.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: Quotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job_Card,Name,Description,Deposit,Total")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotation);
        }

        // GET: Quotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = db.quotation.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quotation quotation = db.quotation.Find(id);
            db.quotation.Remove(quotation);
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
