using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfinityProject.Models;

namespace InfinityProject.Controllers
{
    public class ClerksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

    
        public ActionResult Index()
        {
            return View(db.clerk.ToList());
        }

        public ActionResult Bookings()
        {
            return View(db.BookingViewModels.ToList());
        }
        // GET: Clerks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.clerk.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // GET: Clerks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clerks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Gender,Date_OF_Bith,Address,Contact_nfo,email,User_Name")] Clerk clerk)
        {
            if (ModelState.IsValid)
            {
                db.clerk.Add(clerk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clerk);
        }

        // GET: Clerks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.clerk.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // POST: Clerks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Gender,Date_OF_Bith,Address,Contact_nfo,email,User_Name")] Clerk clerk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clerk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clerk);
        }

        // GET: Clerks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.clerk.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // POST: Clerks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clerk clerk = db.clerk.Find(id);
            db.clerk.Remove(clerk);
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
