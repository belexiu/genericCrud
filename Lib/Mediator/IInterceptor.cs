using System;
using System.Threading.Tasks;

namespace Lib.Mediator
{
    public interface IInterceptor<TIn, TOut>
    {
        Task<TOut> Process(IHandler<TIn, TOut> handler, TIn input, Func<TIn, Task<TOut>> next);
    }
}
