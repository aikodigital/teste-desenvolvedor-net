using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Application.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleResponseDTO ToResponseDTO(this Vehicle vehicle)
        {
            return new VehicleResponseDTO
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Model = vehicle.Model,
                Latitude = vehicle.Position.Latitude,
                Longitude = vehicle.Position.Longitude,
            };
        }
    }
}
