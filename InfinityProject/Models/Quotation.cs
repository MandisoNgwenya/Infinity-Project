﻿using System.ComponentModel.DataAnnotations;

namespace InfinityProject.Models
{
    public class Quotation
    {
        [Key]
        public int Id { get; set; }
        public string Job_Card { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Deposit { get; set; }
        public double Total { get; set; }
        public double Balance { get; set; }
        public string IDNumber { get; set; }
        public string technician { get; set; }
        public string Accessories { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        //public Clerk clerk { get; set; }
        //public BookingViewModels Booking { get; set; }

    }
}