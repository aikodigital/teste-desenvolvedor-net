namespace PublicTransportation.App.Models.Vehicles
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public VehiclePosition Position { get; set; }
        public long LineId {  get; set; }
        public string LineName { get; set; }
    }
}
