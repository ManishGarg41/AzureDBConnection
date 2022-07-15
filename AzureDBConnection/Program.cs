using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDBConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config=> {
                        var connetionString = config.Build().GetConnectionString("appConfiguration");
                        //config.AddAzureAppConfiguration(connetionString);
                        config.AddAzureAppConfiguration(options=> {
                            options.Connect(connetionString);
                            options.ConfigureRefresh(refresh=> {
                                refresh.Register("refreshAll", refreshAll:true).SetCacheExpiration(TimeSpan.FromSeconds(5));
                            });
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });

    }
}
