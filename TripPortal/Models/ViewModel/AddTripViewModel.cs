namespace TripPortal.Models
{
    public class AddTripViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
