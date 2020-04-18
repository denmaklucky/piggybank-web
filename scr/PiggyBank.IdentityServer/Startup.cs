using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PiggyBank.IdentityServer.Models;

namespace PiggyBank.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
            => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddIdentityServer()
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients);

            builder.AddDeveloperSigningCredential();

            //services.AddDbContext<IndeintityContext>(opt => opt.);
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IndeintityContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityServer();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
