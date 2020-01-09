using System;
using System.Collections.Generic;
using System.Linq;


namespace PatternsExamples.Iterator
{
    public static class IteratorMethod
    {
        public static IEnumerable<T> Cartesian<T>(this IEnumerable<IEnumerable<T>> source, Func<T, T, T> aggregator)
        {
            var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext()) return Enumerable.Empty<T>();
            var result = enumerator.Current;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                result = result.SelectMany(e => current, (x, y) => aggregator(x, y));
            }
            return result;
        }
    }
}
