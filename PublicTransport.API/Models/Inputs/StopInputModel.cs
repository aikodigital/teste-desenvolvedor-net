namespace PublicTransport.API.Models.Inputs;

public class StopInputModel
{
    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public long? LineId { get; set; }
}
