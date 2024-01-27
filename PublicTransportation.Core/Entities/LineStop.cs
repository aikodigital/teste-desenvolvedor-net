namespace PublicTransportation.Models
{
    public class LineStop : BaseEntity
    {
        public long LineId { get; set; }
        public Line Line { get; set; }

        public long StopId { get; set; }
        public Stop Stop { get; set; }
    }
}
