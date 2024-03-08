namespace PublicTransport.API.Entities;

public class Line
{
    public long LineId { get; set; }

    public string Name { get; set; }

    public ICollection<LineStop> LineStops { get; set; }
}
