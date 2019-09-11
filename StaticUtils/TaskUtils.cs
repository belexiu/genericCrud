using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaticUtils
{
    public static class TaskUtils
    {
        public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> t1, Task<T2> t2)
        {
            await Task.WhenAll(t1, t2);

            return (t1.Result, t2.Result);
        }

        static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(Task<T1> t1, Task<T2> t2, Task<T3> t3)
        {
            await Task.WhenAll(t1, t2, t3);

            return (t1.Result, t2.Result, t3.Result);
        }

        public static async Task<List<TOut>> SelectAsync<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, Task<TOut>> func)
        {
            var tasks = source.Select(s => func(s));

            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }

        public static async Task ForEachAsync<TIn>(this IEnumerable<TIn> source, Func<TIn, Task> func)
        {
            var tasks = source.Select(s => func(s));

            await Task.WhenAll(tasks);
        }
    }
}
