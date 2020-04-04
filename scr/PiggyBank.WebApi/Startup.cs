using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PiggyBank.Common.Interfaces;
using PiggyBank.Domain.Infrastructure;
using PiggyBank.Domain.Services;

namespace PiggyBank.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient(x => new ServiceSettings
            {
                ConnectionString = Configuration.GetConnectionString("dbConnection")
            });
            services.AddTransient<IAccountService, PiggyService>();
            services.AddTransient<ICategoryService, PiggyService>();
            services.AddTransient<IOperationService, PiggyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthorization();
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
