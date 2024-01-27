using PublicTransportation.Application.Extensions;
using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Application.Mappers
{
    public static class StopMapper
    {
        public static StopResponseDTO ToResponseDTO(this Stop stop)
        {
            var lines = new List<LineResponseDTO>();

            if (!stop.LinesStops.IsNullOrEmpty())
            {
                foreach (var lineStop in stop.LinesStops)
                {
                    lines.Add(lineStop.Line.ToResponseDTO());
                }
            }

            return new StopResponseDTO
            {
                Id = stop.Id,
                Name = stop.Name,
                Latitude = stop.Latitude,
                Longitude = stop.Longitude,
                Lines = lines
            };
        }
    }
}
