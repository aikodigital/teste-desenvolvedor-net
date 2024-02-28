using System.Collections.Generic;

namespace Application.Responses
{
    public class VehicleResponse
    {   
        public long Id { get; set; }
        public long LineId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public LineResponse Line { get; set; }

        public ICollection<VehiclePositionResponse> VehiclePosition { get; set; }
    }
}
