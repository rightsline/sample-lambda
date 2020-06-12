using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RightslineSampleLambdaDotNet.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T TrySingle<T>(this IEnumerable<T> items, Func<T, bool> predicate, string fieldName)
        {
            var item = items.SingleOrDefault(predicate);

            if(item == null)
            {
                throw new Exception($"{fieldName} missing");
            }

            return item;
        }
    }
}
