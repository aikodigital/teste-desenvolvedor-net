namespace Application.Requests
{
    public class CreateStopRequest
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
