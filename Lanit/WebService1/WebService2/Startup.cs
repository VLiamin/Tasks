using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebService2.Consumer;
using WebService2.DAL;
using WebService2.Mappers;
using WebService2.Mappers.Interfaces;

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
                        cfg.ReceiveEndpoint("add", ep =>
                        {
                            ep.ConfigureConsumer<AddConsumer>(context);

                        });
                        cfg.ReceiveEndpoint("getAll", ep =>
                        {
                            ep.ConfigureConsumer<GetAllConsumer>(context);

                        });

                    });

                    busConfigurator.AddConsumer<DeleteConsumer>();
                    busConfigurator.AddConsumer<GetConsumer>();
                    busConfigurator.AddConsumer<AddConsumer>();
                    busConfigurator.AddConsumer<GetAllConsumer>();
                });

            services.AddMassTransitHostedService();
            services.AddControllers();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=LAPTOP-QQUBGIB1\\SQLEXPRESS01;Database=Homework6;Trusted_Connection=True;"));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGetAnswerMapper, GetAnswerMapper>();
            services.AddTransient<IDeleteAnswerMapper, DeleteAnswerMapper>();
            services.AddTransient<IGetAllAnswerMapper, GetAllAnswerMapper>();
            services.AddTransient<IAddAnswerMapper, AddAnswerMapper>();
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
