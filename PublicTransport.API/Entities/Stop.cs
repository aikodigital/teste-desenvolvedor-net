namespace PublicTransport.API.Entities;

public class Stop
{
    public long StopId { get; set; }

    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public ICollection<LineStop> LineStops { get; set; }
}
