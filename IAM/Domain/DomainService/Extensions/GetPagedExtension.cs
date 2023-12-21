using System.Linq.Expressions;

namespace DomainService.Extensions
{
    public static class GetPagedExtension
    {
        public static IList<T> GetPagedAndSorted<T>(this IQueryable<T> query, int pageNumber, int pageSize, string orderDirection, string orderByField, out int totalCount) where T : class
        {
            totalCount = query.Count();
            int count = (pageNumber - 1) * pageSize;
            return query.OrderBy(orderByField, orderDirection).Skip(count).Take(pageSize).ToList();
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string orderByMember, string direction)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            MemberExpression memberExpression = Expression.PropertyOrField(parameterExpression, orderByMember);
            LambdaExpression expression = Expression.Lambda(memberExpression, parameterExpression);
            MethodCallExpression expression2 = Expression.Call(typeof(Queryable), (direction.ToLower() == "asc") ? "OrderBy" : "OrderByDescending", new Type[2]
            {
            typeof(T),
            memberExpression.Type
            }, query.Expression, Expression.Quote(expression));
            return query.Provider.CreateQuery<T>(expression2);
        }
    }
}
