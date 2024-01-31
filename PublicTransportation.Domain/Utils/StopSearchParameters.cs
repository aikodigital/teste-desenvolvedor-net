namespace PublicTransportation.Domain.Utils
{
    public class StopSearchParameters : BaseSearchParameters
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
