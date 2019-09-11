using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Mediator
{
    public class DefaultMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TOut> Send<TIn, TOut, THandler>(TIn input) 
            where THandler : IHandler<TIn, TOut>
        {
            var handler = _serviceProvider.GetRequiredService<THandler>();

            var interceptors = _serviceProvider.GetServices<IInterceptor<TIn, TOut>>()
                .ToList();

            var pipeLine = new List<Func<TIn, Task<TOut>>> { handler.Process };

            while (interceptors.Any())
            {
                var lastInterceptor = interceptors.Last();
                var firstPipe = pipeLine.First();

                Func<TIn, Task<TOut>> newPipe = (TIn ip) => lastInterceptor.Process(handler, ip, firstPipe);

                pipeLine.Insert(0, newPipe);
                interceptors.RemoveAt(interceptors.Count - 1);
            }
            
            var result = await pipeLine.First()(input);

            return result;
        }
    }
}
