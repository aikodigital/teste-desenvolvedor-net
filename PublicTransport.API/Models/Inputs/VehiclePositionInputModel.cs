namespace PublicTransport.API.Models.Inputs;

public class VehiclePositionInputModel
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public long VehicleId { get; set; }
}
