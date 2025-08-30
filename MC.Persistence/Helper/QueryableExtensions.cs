using System.Linq.Dynamic.Core;

namespace MC.Persistence.Helper
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(propertyName);
        }

        public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy($"{propertyName} descending");
        }
    }
}
