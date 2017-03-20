using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InfinityProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace InfinityProject.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Booking
        public ActionResult Index1()
        {

            string userID = User.Identity.GetUserId();
            return View(db.BookingViewModels.Where(x => x.Id == userID));
        }

        //public ActionResult Index1(int?id)
        //{
        //    var bookings = new BookingViewModels();
        //    bookings.JobCard = db.BookingViewModels
        //        .Include(i => i.cName)
        //        .Include(i => i.JobCard).Include(i => i.Device)
        //        .Include(i => i.Date).Include(i => i.Clerk).Include(i => i.Technician).OrderBy(i => i.Date).ToString();
        //    string userID = User.Identity.GetUserId();
        //       return View(bookings);
        //}
        //// GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingViewModels bookingViewModels = db.BookingViewModels.ToList().Find(x => x.BookingID == id);
            if (bookingViewModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingViewModels);
        }

      
    
        // GET: Booking/Create
        public ActionResult Index(string name, string surname,string n)
        {
            try {

                Random gen = new Random();
              
                int size = 10;
                string input = "abcdefghijklmnopqrstuvwxyz0123456789";
                char[] chars = new char[size];
                for (int i = 0; i < size; i++)
                {
                    chars[i] = input[gen.Next(input.Length)];
                }
              
                BookingViewModels b = new BookingViewModels();
                b.cName = name;
                b.cSurname = surname;
                b.JobCard = chars.ToString();
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
                booking.JobCard = model.JobCard;
                booking.cName = model.cName;
                booking.cSurname = model.cSurname;
                booking.IDNumber = model.IDNumber;
             booking.JobCard=model.JobCard;
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
        public ActionResult Edit(int? id)
        {
            BookingViewModels b = new BookingViewModels();
        
           
            b.Id = User.Identity.GetUserId();
            if (id == null)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,cName,cSurname,IDNumber,Address,TelNo,Device")] BookingViewModels model)
        {//The script is updating but removing the Id field, tried adding Id on the include but got an error
            if (ModelState.IsValid)
            {
                var booking = new BookingViewModels();
                booking.cName = model.cName;
                booking.cSurname = model.cSurname;
                booking.IDNumber = model.IDNumber;
                booking.JobCard = model.JobCard;
                booking.TelNo = model.TelNo;
                booking.Address = model.Address;
                booking.Device = model.Device;
                booking.Id = User.Identity.GetUserId();
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index1");

            }
            return View(model);
        }

        //GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingViewModels bookingViewModels = db.BookingViewModels.Find(id);
            if (bookingViewModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingViewModels);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingViewModels bookingViewModels = db.BookingViewModels.Find(id);
            db.BookingViewModels.Remove(bookingViewModels);
            db.SaveChanges();
            return RedirectToAction("Index1");
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
