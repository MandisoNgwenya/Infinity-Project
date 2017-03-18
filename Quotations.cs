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
            //ID number searches and returns customer booking linked to that number 

            if (ModelState.IsValid)
            {
                Quotation qoute = db.quotation.Single(x => x.Job_Card == JobCard);
                var booking = db.BookingViewModels.Single(x => x.BookingID == qoute.IdQ);

                return View(booking);
            }
            
            //click on create quote 
            //retirect to create quote
            //filter beweetn finished pending and finished
            return View();
            

        }


        public ActionResult NewQuote()
        {

            //Take the details for all user booking then assin them to textboxt
            Quotation quote = new Quotation();

            var quotee = db.quotation.Single(q => q.IdQ == quote.IdQ);// first search whether the person exist 
            quotee.Description = quote.Description;
            quotee.Deposit = quote.Deposit;
            quotee.Total = quote.Total;
            ///----how to take an value from the database then put it on the texbox
  

            //---BookingsModel (table) Quotation (table) //customer(table) Technians
          
            //allocate technician 
            //add device accessories
            //
            return View();
       }

        public ActionResult FinishQuote(Quotation model)
        {
            //search job
            if (ModelState.IsValid)
            {
                Quotation quot = db.quotation.Single(x => x.Job_Card == model.Job_Card);

                //total = 0.0, deposite = 0.0;
                //balance = total - deposite;

                double balance = 0.0;       
                balance = quot.Total - quot.Deposit;
               
                quot.Description = model.Description;//-- writes the discription,balance and desciption

               // ---return View(Technician); this should direct or go to view of technicions
            }

            //technician enters fault disc
            //enters total
            //enter deposit amount
            //calculate balance

            //*****send confirmation email &sms
            //*****update status
           
            return View();
        }

        //public ActionResult CloseJob()
        //{

        //    //close job 
        //}
        //technician

    }
}
