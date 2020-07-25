using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantum.Mt.Domain.Components.Consumers;
using Quantum.Mt.Domain.Models;

namespace Quantum.Mt.Api
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
            services.AddControllers();
            // services.AddMassTransit(x =>
            // {
            //     x.AddConsumer<SubmitOrderConsumer>();
            //     x.AddRequestClient<ISubmitOrder>();
            // });

            services.AddMediator(x =>
            {
                x.AddConsumer<SubmitOrderConsumer>();
                x.AddRequestClient<SubmitOrder>();
            });
            
            services.AddOpenApiDocument(c => c.PostProcess = d => d.Info.Title = "My sample api");
        }
 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection()
                .UseOpenApi()
                .UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}