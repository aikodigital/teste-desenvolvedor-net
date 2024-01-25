using PublicTransportation.Models;

namespace PublicTransportation.Infra.Seed
{
    public class VehicleSeed
    {
        public Vehicle[] Seeds = new Vehicle[]
        {
            new Vehicle { Id = 1, Name = "Marcopolo Torino", Model = "Torino", LineId = 1 }
        };
    }
}
