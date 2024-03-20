namespace TripPortal.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationID { get; set; }
        public Guid TripID { get; set; }
        public string PaymentStatus { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
