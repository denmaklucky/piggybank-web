using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace pibbybank.site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            //Нужно для EF SeedData
            .UseDefaultServiceProvider(options =>
            options.ValidateScopes = false);
    }
}
