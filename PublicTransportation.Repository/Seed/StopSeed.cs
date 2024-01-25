using PublicTransportation.Models;

namespace PublicTransportation.Infra.Seed
{
    public class StopSeed
    {
        public Stop[] Seeds = new Stop[]
        {
            new Stop { Id = 1, Name = "AV. CARLOS OBERHUBER", Latitude = -23.7427607, Longitude = -46.7110703 },
            new Stop { Id = 2, Name = "PÇA. JOSÉ BOEMER ROSCHEL", Latitude = -23.7435223, Longitude = -46.7058728 },
            new Stop { Id = 3, Name = "R. RUBEM SOUTO DE ARAÚJO", Latitude = -23.7376596, Longitude = -46.7048558 }
        };
    }
}
