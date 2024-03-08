namespace PublicTransport.API.Entities;

public class Vehicle
{
    public long VehicleId { get; set; }

    public string Name { get; set; }

    public string Model { get; set; }

    public long LineId { get; set; }

    public Line Line { get; set; }
}
