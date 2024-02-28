using Domain.Entities;

namespace Application.Requests
{
    public class VehiclePositionRequest
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }

        public double Latitude { get; set; }
               
        public double Longitude { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
