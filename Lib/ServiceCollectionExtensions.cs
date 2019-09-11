using Lib.CrudHandlers;
using Lib.Db;
using Lib.Mediator;
using Lib.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lib
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCrudFramework<T>(this IServiceCollection services) where T : DbContext
        {
            services.ConfigureEf<T>();
            services.AddDefaultMediator();
            services.AddCrudHandlers();
            services.AddDefaultValidators();
            services.AddDbServices();
            return services;
        }

        public static IServiceCollection ConfigureEf<TDbContext>(this IServiceCollection services) 
            where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>();
            services.AddScoped<DbContext, TDbContext>();
            return services;
        }

        public static IServiceCollection AddDefaultMediator(this IServiceCollection services)
        {
            services.AddScoped<IMediator, DefaultMediator>();
            return services;
        }

        public static IServiceCollection AddCrudHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudCreate<,>), typeof(CrudCreate<,>));
            services.AddScoped(typeof(ICrudRead<,>), typeof(CrudRead<,>));
            services.AddScoped(typeof(ICrudUpdate<,>), typeof(CrudUpdate<,>));
            services.AddScoped(typeof(ICrudDelete<,>), typeof(CrudDelete<,>));
            services.AddScoped(typeof(ICrudList<,>), typeof(CrudList<,>));
            return services;
        }

        public static IServiceCollection AddDefaultValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICreateValidator<>), typeof(DefaultValidator<>));
            services.AddScoped(typeof(IUpdateValidator<>), typeof(DefaultValidator<>));
            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDbCreate<>), typeof(DbCreate<>));
            services.AddScoped(typeof(IDbRead<>), typeof(DbRead<>));
            services.AddScoped(typeof(IDbDelete<>), typeof(DbDelete<>));
            services.AddScoped(typeof(IDbUpdate<>), typeof(DbUpdate<>));
            services.AddScoped(typeof(IDbList<>), typeof(DbList<>));
            return services;
        }
    }
}
