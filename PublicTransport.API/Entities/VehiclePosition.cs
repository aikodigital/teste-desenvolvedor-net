namespace PublicTransport.API.Entities;

public class VehiclePosition
{
    public long VehiclePositionId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public long VehicleId { get; set; }

    public Vehicle Vehicle { get; set; }
}
