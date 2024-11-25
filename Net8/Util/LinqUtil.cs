using System.Linq.Expressions;

namespace Net8.Util
{
    public static class LinqUtil
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ?
                        source.Where(predicate) :
                        source;
        }
    }
}