namespace PublicTransportation.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
            => list == null || !list.Any();
    }
}
