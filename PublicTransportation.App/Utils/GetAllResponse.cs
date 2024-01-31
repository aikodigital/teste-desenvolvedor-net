namespace PublicTransportation.App.Utils
{
    public class GetAllResponse<T>
    {
        public int TotalCount { get; set; }
        public ICollection<T> Rows { get; set; }
        public BaseSearchParameters SearchParameters { get; set; }
    }
}
