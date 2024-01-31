using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Infra.Seed
{
    public class VehiclePositionSeed
    {
        public VehiclePosition[] Seeds = new VehiclePosition[]
        {
            new VehiclePosition { Id = 1, VehicleId = 1, Latitude = -23.7427607, Longitude = -46.7110703 }
        };
    }
}
