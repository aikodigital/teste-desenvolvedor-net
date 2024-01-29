using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.DTO.Response
{
    public class VehicleResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string LineName { get; set; }
        public long LineId { get; set; }

        public VehiclePositionResponseDTO Position { get; set; }
    }
}
