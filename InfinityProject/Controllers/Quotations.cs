using InfinityProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityProject.Controllers
{
    public class Quotations : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Quotation
        public ActionResult Index(string JobCard)
        {
            // when  the clerk views this page it returns nothing  
            // there is a textbox and a search  button where a clerk inserts ID number
           var  qoute = db.quotation.Single(x => x.Job_Card == JobCard);


            var booking = db.BookingViewModels.Single(x => x.BookingID == qoute.IdQ);
            //ID number searches and returns customer booking linked to that number '
            //click on create quote 
            //retirect to create quote
            //filter beweetn finished pending and finished
            return View(booking);
            

        }


        public ActionResult NewQuote()
        {
           
            //Take the details for all user booking then assin them to textboxt
            //BookingsModel (table) Quotation (table) //customer(table) Technians
            //allocate technician 
            //add device accessories
            //



            return View();
        }

        public ActionResult FinishQuote(string card,Quotation model)
        {
            //search job
            var quot = db.quotation.Single(x => x.Job_Card==card);
            //technician enters fault disc
            //enters total
            
            Quotation m = new Quotation();

            double balance = 0.0, total = 0.0, deposite = 0.0;

            balance = m.Total - m.Deposit;

            balance = total - deposite;
            //enter depoit amount
            //calculate balance
            //send confirmation email &sms
            //update status
           
            return View();
        }

        //public ActionResult CloseJob()
        //{

        //    //close job 
        //}
        //technician

    }
}
