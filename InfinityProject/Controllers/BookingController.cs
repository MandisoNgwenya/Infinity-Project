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
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace InfinityProject.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booking
        public  ActionResult Index1()
        {
            string userID = User.Identity.GetUserId();
            return View(db.BookingViewModels.Where(x => x.Id == userID));
        }

        //// GET: Booking/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookingViewModels bookingViewModels = db.BookingViewModels.Find(id);
        //    if (bookingViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookingViewModels);
        //}

        // GET: Booking/Create
        public ActionResult Index(string name, string surname)
        {
            try {
                BookingViewModels b = new BookingViewModels();
                b.cName = name;
                b.cSurname = surname;

                b.Id = User.Identity.GetUserId();
                UserManager<ApplicationUser> UserManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                b.Id = UserManager.FindById(User.Identity.GetUserId()).ToString();
                return View(b);
            }
            catch
            {
                return ViewBag.Message();
            }
            
        
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "BookingID,cName,cSurname,IDNumber,Address,TelNo,Device,Id")] BookingViewModels model)
        {
            if (ModelState.IsValid)
            {
                var booking = new BookingViewModels();
                booking.cName = model.cName;
                booking.cSurname = model.cSurname;
                booking.IDNumber = model.IDNumber;
             
                booking.TelNo = model.TelNo;
                booking.Address = model.Address;
                booking.Device = model.Device;
                booking.Id = User.Identity.GetUserId();
                db.BookingViewModels.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index1");

            }

            return View(model);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookingViewModels = db.BookingViewModels.ToList().Find(x => x.BookingID == id);
            if (bookingViewModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingViewModels);
            
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BookingID,Name,Surname,IDNumber,Address,TelNo,Device")] BookingViewModels bookingViewModels)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(bookingViewModels).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(bookingViewModels);
        //}

        // GET: Booking/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BookingViewModels bookingViewModels = db.BookingViewModels.Find(id);
        //    if (bookingViewModels == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bookingViewModels);
        //}

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingViewModels bookingViewModels = db.BookingViewModels.Find(id);
            db.BookingViewModels.Remove(bookingViewModels);
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
