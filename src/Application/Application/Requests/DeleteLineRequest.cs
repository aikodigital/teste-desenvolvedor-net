namespace Application.Requests
{
    public class DeleteLineRequest
    {
        public long Id { get; set; }
        public long StopId { get; set; }
        public string Name { get; set; }
    }
}
