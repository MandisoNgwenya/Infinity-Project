﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityProject.Models
{
    public class Technician
    {
        [Key]
        public int Id { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_OF_Bith { get; set; }
        public string Job_Card { get; set; }
        public string Description { get; set; }


    }
}