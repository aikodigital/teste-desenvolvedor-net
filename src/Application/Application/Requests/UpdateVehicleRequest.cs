namespace Application.Requests
{
    public class UpdateVehicleRequest
    {
        public long Id { get; set; }

        public long LineId { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }
    }
}
