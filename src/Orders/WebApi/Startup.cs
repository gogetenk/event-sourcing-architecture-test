using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orders.Application.Behaviours;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;
using YtDeveloppement.EventSourcing.Orders.Infrastructure.Repositories;

namespace YtDeveloppement.EventSourcing.Microservices.Orders.WebApi
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

            services.AddMediatR(typeof(Application.Commands.CreateOrderCommand));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();

            services.AddTransient<IEventRepository, EventRepository>((sp) => new EventRepository(Configuration["EventStore:ConnectionString"]));
            services.AddTransient<IReadOrderRepository, ReadOrderRepository>((sp) => new ReadOrderRepository(Configuration["OrderDb:Read:ConnectionString"]));
            services.AddTransient<IWriteOrderRepository, WriteOrderRepository>((sp) => new WriteOrderRepository(Configuration["OrderDb:Write:ConnectionString"]));
            //services.AddMarten(Configuration.GetConnectionString("Marten"));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EventSourcingBehaviour<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
