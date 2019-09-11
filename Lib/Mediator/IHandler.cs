using System.Threading.Tasks;

namespace Lib.Mediator
{
    public interface IHandler<TIn, TOut>
    {
        Task<TOut> Process(TIn input);
    }
}
