namespace DriversLog.Trip.Contract.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}