using System;
using System.Threading.Tasks;
using Lib.Mediator;
using Newtonsoft.Json;
using WebApi.ViewModels;

namespace WebApi.Interceptors
{
    public class ProductInterceptor : IInterceptor<ProductVm, ProductVm>
    {
        public async Task<ProductVm> Process(IHandler<ProductVm, ProductVm> handler, ProductVm input, Func<ProductVm, Task<ProductVm>> next)
        {
            Console.WriteLine($"\n\nStarting reqeust for creating/updating product");
            Console.WriteLine($"Handler type: {handler.GetType().FullName}");
            Console.WriteLine($"Input: {JsonConvert.SerializeObject(input, Formatting.Indented)}");

            var resultNext = await next(input);

            Console.WriteLine($"Output order interceptor: {JsonConvert.SerializeObject(resultNext, Formatting.Indented)}");
            Console.WriteLine($"Finished order interceptor reqeust\n\n");

            return resultNext;
        }
    }
}
