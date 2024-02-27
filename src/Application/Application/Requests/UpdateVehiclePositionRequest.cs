namespace Application.Requests
{
    public class UpdateVehiclePositionRequest
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
