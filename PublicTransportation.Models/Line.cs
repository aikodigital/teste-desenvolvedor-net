using System.Collections;
using System.Collections.Generic;

namespace PublicTransportation.Models
{
    public class Line : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<LineStop> LinesStops { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
