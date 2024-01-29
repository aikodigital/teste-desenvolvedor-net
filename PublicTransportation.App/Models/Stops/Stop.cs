using PublicTransportation.App.Models.Lines;

namespace PublicTransportation.App.Models.Stops
{
    public class Stop
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Line> Lines { get; set; }
    }
}
