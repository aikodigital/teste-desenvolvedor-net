namespace PublicTransportation.Domain.Entities
{
    public class VehiclePosition : BaseEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
