using System.Collections.Generic;

namespace PublicTransportation.Domain.Entities
{
    public class Stop : BaseEntity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<LineStop> LinesStops { get; set; }
    }
}
