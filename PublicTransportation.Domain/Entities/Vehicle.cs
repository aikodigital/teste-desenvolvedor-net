namespace PublicTransportation.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public long LineId { get; set; }
        public Line Line { get; set; }
        public VehiclePosition Position { get; set; }
    }
}
