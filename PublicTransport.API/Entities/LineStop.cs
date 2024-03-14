namespace PublicTransport.API.Entities;

public class LineStop
{
    public long LineStopId { get; set; }

    public long LineId { get; set; }

    public long StopId { get; set; }

    public Line? Line { get; set; }

    public Stop? Stop { get; set; }
}