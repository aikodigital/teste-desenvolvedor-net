using PublicTransportation.Domain.Entities;

namespace PublicTransportation.Infra.Seed
{
    public class LineStopSeed
    {
        public LineStop[] Seeds = new LineStop[]
        {
            new LineStop { Id = 1, LineId = 1, StopId = 1},
            new LineStop { Id = 2, LineId = 1, StopId = 2},
            new LineStop { Id = 3, LineId = 1, StopId = 3}
        };
    }
}
