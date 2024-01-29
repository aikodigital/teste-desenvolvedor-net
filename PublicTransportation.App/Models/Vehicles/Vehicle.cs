namespace PublicTransportation.App.Models.Vehicles
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string LineName { get; set; }
    }
}
