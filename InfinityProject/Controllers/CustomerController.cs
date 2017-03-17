using InfinityProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Net;
using System.Web.Mvc;
namespace InfinityProject.Controllers
{

    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Customers()
        {// list all the customers using the system 

            //list of all customers
            return View();
        }

        // GET: Customer/Details/5
      
        public ActionResult Profile(string name, string surname, int? id)
        {
            if ( id== null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            try {
                BookingViewModels model = new BookingViewModels();
                Customer p = new Customer();
                p.Name = name;
                p.Surname = surname;
               
                p.Id = User.Identity.GetUserId();
                UserManager<ApplicationUser> UserManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                p.Id = UserManager.FindById(User.Identity.GetUserId()).ToString();
                id = Convert.ToInt16(p.Id);
                var booking = new BookingViewModels();
                booking.cName = model.cName;
                booking.cSurname = model.cSurname;
                booking.IDNumber = model.IDNumber;

                booking.TelNo = model.TelNo;
                booking.Address = model.Address;
                booking.Device = model.Device;


                
                return View(p);
            }
            catch
            {
                return ViewBag.Message();
            }
            
        
        }


        [HttpPost]
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult myBookings()
        {

            return View();
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult EditProfile(UserProfile model )
        {
            try
            {
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
     
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

   
        }
    }
