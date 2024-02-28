namespace Application.Requests
{
    public class CreateVehiclePositionRequest
    {
        public long VehicleId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
