﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace InfinityProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get;  set; }
        public string Surname { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaims(new List<Claim>()

            //    {
            //    new Claim("Name", Name),
            //    new Claim("Surname",Surname)
            //});
            userIdentity.AddClaim(new Claim("Name", Name));
            userIdentity.AddClaim(new Claim("Surname", Surname));
            return userIdentity;
        }
    }

    public class Booking
    {

        public Booking()
        {
            bookingID = Guid.NewGuid().ToString();
            ApplicationUser = new ApplicationUser();

        }
        public Booking(string jobcard) : this()
        {
            JobCard = jobcard;
        }
        [Key]
        public string bookingID { get; set; }
        public string JobCard { get; set; }
        public string CustomerNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string IDNumber { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public DateTime date { get; set; }
        public string device { get; set; }
        public string Model { get; set; }
        public string serialNo { get; set; }
        public string Signature { get; set; }

        [Display(Name = "User ID")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<InfinityProject.Models.BookingViewModels> BookingViewModels { get; set; }
    }
}