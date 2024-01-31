using System.Collections;
using System.Collections.Generic;

namespace PublicTransportation.Domain.Entities
{
    public class Line : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<LineStop> LinesStops { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
