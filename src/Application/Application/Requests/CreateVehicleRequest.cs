namespace Application.Requests
{
    public class CreateVehicleRequest
    {
        public long LineId { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }
    }
}
