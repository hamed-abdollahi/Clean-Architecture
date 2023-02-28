namespace Clean.Shared
{
    public static class Pagination
    {

        public static IEnumerable<TSource>? GetPage<TSource>(this IEnumerable<TSource> source, int page,int size,out int rowCount)
        {
            rowCount = source.Count();
            var res =  source.Skip((page-1)*size).Take(size);
            return !res.Any() ? null : res;
        }

    }
}