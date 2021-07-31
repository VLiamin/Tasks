using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.Questions;
using System;
using WebService1.Commands;
using WebService1.Commands.Interfaces;
using WebService1.Models;

namespace WebService1
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
            services.AddMassTransit(
                busConfigurator =>
                {
                    busConfigurator.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("localhost", "/", host =>
                        {
                            host.Username("WebService1");
                            host.Password("123");
                        });
                    });

                    busConfigurator.AddRequestClient<GetQuestion>(
                        new Uri("rabbitmq://localhost/get"),
                        RequestTimeout.After(s: 5));
                    busConfigurator.AddRequestClient<DeleteQuestion>(
                        new Uri("rabbitmq://localhost/delete"),
                        RequestTimeout.After(s: 5));
                    busConfigurator.AddRequestClient<AddQuestion>(
                        new Uri("rabbitmq://localhost/add"),
                        RequestTimeout.After(s: 5));
                    busConfigurator.AddRequestClient<GetAllQuestion>(
                        new Uri("rabbitmq://localhost/getAll"),
                        RequestTimeout.After(s: 5));
                });

            services.AddMassTransitHostedService();
            services.AddControllers();
            services.AddTransient<IGetUserCommand, GetUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IAddUserCommand, AddUserCommand>();
            services.AddTransient<IGetAllUsersCommand, GetAllUsersCommand>();
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
