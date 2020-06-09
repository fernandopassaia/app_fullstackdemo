using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AppFullStackDemo.Api
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                    .UseUrls("http://*:4001") //Localhost dev: Angular will run on 4200 and BackEnd will run on 4001)
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                        .UseStartup<Startup>();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}
