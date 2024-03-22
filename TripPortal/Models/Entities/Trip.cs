namespace TripPortal.Models.Entities
{
    public class Trip
    {
        public Guid TripID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
