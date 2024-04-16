using Microsoft.AspNetCore.Mvc.Rendering;
using TripPortal.Models.Entities;

namespace TripPortal.Models.ViewModel
{
    public class AddReservationViewModel
    {
        public Guid TripID { get; set; }
        public Trip Trip { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Student> Students { get; set; }
        public Guid SelectedStudentID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PriceForAll { get; set; }

    }
}
