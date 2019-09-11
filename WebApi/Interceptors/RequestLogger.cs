using System;
using System.Threading.Tasks;
using Lib.Mediator;
using Newtonsoft.Json;

namespace WebApi.Interceptors
{
    public class RequestLogger<TIn, TOut> : IInterceptor<TIn, TOut>
    {
        public async Task<TOut> Process(IHandler<TIn, TOut> pipe, TIn input, Func<TIn, Task<TOut>> next)
        {
            Console.WriteLine($"In 1 {pipe.GetType().FullName}");

            var resultNext = await next(input);

            Console.WriteLine("Out 1");

            return resultNext;
        }
    }

    public class RequestLogger2<TIn, TOut> : IInterceptor<TIn, TOut>
    {
        public async Task<TOut> Process(IHandler<TIn, TOut> pipe, TIn input, Func<TIn, Task<TOut>> next)
        {
            Console.WriteLine($"In 2 {pipe.GetType().FullName}");

            var resultNext = await next(input);

            Console.WriteLine("Out 2");

            return resultNext;
        }
    }

    public class RequestLogger3<TIn, TOut> : IInterceptor<TIn, TOut>
    {
        public async Task<TOut> Process(IHandler<TIn, TOut> pipe, TIn input, Func<TIn, Task<TOut>> next)
        {
            Console.WriteLine($"In 3 {pipe.GetType().FullName}");

            var resultNext = await next(input);

            Console.WriteLine("Out 3");

            return resultNext;
        }
    }
}
