namespace TripPortal.Models.Entities
{
    public class Reservation
    {
        public Guid ReservationID { get; set; }
        public Guid TripID { get; set; }
        public Guid StudentID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PriceForAll { get; set; }
    }
}
