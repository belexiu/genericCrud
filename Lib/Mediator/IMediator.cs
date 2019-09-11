using System.Threading.Tasks;

namespace Lib.Mediator
{
    public interface IMediator
    {
        Task<TOut> Send<TIn, TOut, THandler>(TIn input) 
            where THandler : IHandler<TIn, TOut>;
    }
}
