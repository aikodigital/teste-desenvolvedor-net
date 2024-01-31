namespace PublicTransportation.Domain.DTO.Response
{
    public class StopResponseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<LineResponseDTO> Lines { get; set; }
    }
}
