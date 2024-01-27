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
                LineName = vehicle.Line.Name, 
                Latitude = vehicle.Position?.Latitude,
                Longitude = vehicle.Position?.Longitude,
            };
        }

        public static ICollection<VehicleResponseDTO> ToResponseDTO(this ICollection<Vehicle> vehicles)
        {
            var list = new List<VehicleResponseDTO>();

            foreach (var vehicle in vehicles)
                list.Add(vehicle.ToResponseDTO());

            return list;
        }
    }
}
