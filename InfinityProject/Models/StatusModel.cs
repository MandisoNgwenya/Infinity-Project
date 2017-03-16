using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfinityProject.Models
{
    public class StatusModel
    {
        [Key]
        public int status { get; set; }
        public string statusName { get; set; }
    }
}