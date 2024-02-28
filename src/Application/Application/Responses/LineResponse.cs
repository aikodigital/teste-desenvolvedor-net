namespace Application.Responses
{
    public class LineResponse
    {
        public long Id { get; set; }
        public long StopId { get; set; }
        public string Name { get; set; }
        public StopResponse Stop { get; set; }
    }
}
