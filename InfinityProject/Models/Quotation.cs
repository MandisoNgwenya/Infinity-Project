using System.ComponentModel.DataAnnotations;

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

        //public Technician technician { get; set; }
        ////public Clerk clerk { get; set; }
        //public BookingViewModels Booking { get; set; }

    }
}