using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Domain.DTO.Response
{
    public class LineResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<StopResponseDTO> Stops { get; set; }
        public ICollection<VehicleResponseDTO> Vehicles { get; set; }

    }
}
