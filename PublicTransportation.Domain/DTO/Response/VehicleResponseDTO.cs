using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.DTO.Response
{
    public class VehicleResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string LineName { get; set; }
    }
}
