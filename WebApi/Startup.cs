using Lib;
using Lib.Mapping;
using Lib.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Data;
using WebApi.Interceptors;
using WebApi.Mappers;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCrudFramework<AppDbContext>();

            services.AddScoped(typeof(IInterceptor<,>), typeof(RequestLogger<,>));
            services.AddScoped(typeof(IInterceptor<,>), typeof(RequestLogger2<,>));
            services.AddScoped(typeof(IInterceptor<,>), typeof(RequestLogger3<,>));
            services.AddScoped<IInterceptor<ProductVm, ProductVm>, ProductInterceptor>();

            services.AddScoped<IMapper<ProductVm, Product>, ProductMapper>();
            services.AddScoped<IMapper<OrderVm, Order>, OrderMapper>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
