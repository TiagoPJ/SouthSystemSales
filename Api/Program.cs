using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            BuildWebHostBuilder(args).Build();

        public static IWebHostBuilder BuildWebHostBuilder(string[] args, string basePath = "") =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
