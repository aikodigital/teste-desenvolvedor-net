namespace Application.Requests
{
    public class UpdateLineRequest
    {
        public long Id { get; set; }
        public long StopId { get; set; }
        public string Name { get; set; }
    }
}
