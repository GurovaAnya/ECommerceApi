using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ECommerceApi.Utilities
{
    public static class Helpers
    {
        public static Func<T, T> DynamicSelectGenerator<T>(List<string> fields = null)
        {
            if (fields == null)
                fields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToList();

            var xParameter = Expression.Parameter(typeof(T), "o");
            var xNew = Expression.New(typeof(T));

            var bindings = fields.Select(o => o.Trim())
                .Select(o =>
                    {
                        var mi = typeof(T).GetProperty(o, BindingFlags.IgnoreCase);
                        var xOriginal = Expression.Property(xParameter, mi);
                        return Expression.Bind(mi, xOriginal);
                    }
                );

            var xInit = Expression.MemberInit(xNew, bindings);
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);
            return lambda.Compile();
        }
    }
}