using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService2.Consumer;
using WebService2.DAL;

namespace WebService2
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
                            host.Username("WebService2");
                            host.Password("123");
                        });
                        cfg.ReceiveEndpoint("get", ep =>
                        {
                            ep.ConfigureConsumer<GetConsumer>(context);

                        });
                        cfg.ReceiveEndpoint("delete", ep =>
                        {
                            ep.ConfigureConsumer<DeleteConsumer>(context);

                        });
                    });

                    busConfigurator.AddConsumer<DeleteConsumer>();
                    busConfigurator.AddConsumer<GetConsumer>();

                });

            services.AddMassTransitHostedService();
            services.AddControllers();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=LAPTOP-QQUBGIB1\\SQLEXPRESS01;Database=Homework6;Trusted_Connection=True;"));
            services.AddTransient<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext myDbContext)
        {
            myDbContext.Database.Migrate();

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
