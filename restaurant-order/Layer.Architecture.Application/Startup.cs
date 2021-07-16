using AutoMapper;
using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Service.Engines;
using Layer.Architecture.Service.Parsers;
using Layer.Architecture.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Layer.Architecture.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderParser, OrderParser>();
            services.AddScoped<IRuleHandlerEngineInterface, RuleHandlerEngine>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Order, OrderModel>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
