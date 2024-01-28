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
                    lines.Add(new LineResponseDTO
                    {
                        Id = lineStop.LineId,
                        Name = lineStop.Line.Name
                    });
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

        public static ICollection<StopResponseDTO> ToResponseDTO(this ICollection<Stop> stops)
        {
            var list = new List<StopResponseDTO>();

            foreach (var stop in stops)
                list.Add(stop.ToResponseDTO());

            return list;
        }
    }
}
