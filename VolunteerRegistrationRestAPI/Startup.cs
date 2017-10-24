using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VolunteerRegistrationBLL.Facade;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Facade;
using VolunteerRegistrationDAL.UOW;

namespace VolunteerRegistrationRestAPI
{
    public class Startup
    {
        private IHostingEnvironment Environment { get; }

        private IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddSingleton(Configuration);

            if (Environment.IsDevelopment())
                services.AddDbContext<VolunteerRegistrationContext>(opt => opt.UseInMemoryDatabase("VR"));
            else
                services.AddDbContext<VolunteerRegistrationContext>(opt => opt.UseSqlServer($"{Configuration["DefaultConnection"]}"));

            services.AddScoped<IBLLFacade, BLLFacade>();
            services.AddScoped<IDALFacade, DALFacade>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add services!
            services.AddScoped<IVolunteerService, VolunteerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}