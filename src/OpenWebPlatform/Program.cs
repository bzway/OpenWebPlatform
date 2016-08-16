using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Topshelf;

namespace OpenWebPlatform
{
    public class Program : ServiceControl
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.RunAsLocalService();
                x.SetDescription("this is a description for the service");
                x.SetServiceName("Top Service");
                x.Service<Program>();
            });
        }

        public bool Start(HostControl hostControl)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var host = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseUrls("http://localhost:5000")
               .UseStartup<Startup>()
               .Build();

            host.Run();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return false;
        }
    }
}
