using FireForgetStressTestApp.Services.Implementations;
using FireForgetStressTestApp.Services.Interfaces;
using FireForgetTask.Interfaces;
using FireForgetTask.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FireForgetStressTestApp
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
            services.AddDbContext<Notifications_TestingContext>(
                options => options.UseSqlServer("Server=DESKTOP-1TDJQRD;Database=Notifications_Testing;Trusted_Connection=True;"));
            services.AddScoped<ITestService, TestService>();
            services.AddTransient<IFireForgetTask<ITestService>, FireForgetTask<ITestService>>();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fire And Forget API",
                    Version = "v1"
                });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fire And Forget API");
            });
        }
    }
}
