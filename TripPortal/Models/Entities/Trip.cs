namespace TripPortal.Models.Entities
{
    public class Trip
    {
        public Guid TripID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
    }
}
