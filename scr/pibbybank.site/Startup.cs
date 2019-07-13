using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using piggybank.dal;
using piggybank.dal.Contracts;
using piggybank.site.Configurates;
using piggybank.site.Models;

namespace pibbybank.site
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PiggyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("localConnectionString")));
            services.AddTransient<IPBRepository, PBRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();
            app.UseMvc(routers =>
            {
                routers.MapRoute(
                    name: null,
                    template: "{controller=History}/{action=Index}/{id?}"
                    );
            });

            SeedData.EnsurePopulated(app);
            MapperInit.Configurate();
        }

        public IConfiguration Configuration { get; }
    }
}
