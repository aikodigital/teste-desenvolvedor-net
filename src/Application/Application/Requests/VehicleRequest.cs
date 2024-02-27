using Domain.Entities;

namespace Application.Requests
{
    public class VehicleRequest
    {
        public long Id { get; set; }

        public long LineId { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public Line Line { get; set; }
    }
}
