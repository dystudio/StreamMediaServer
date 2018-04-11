using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StreamMediaServer.HIKVision;

namespace StreamMediaServer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Client.Init();
            Client.PullStream("rtmp://121.42.182.33/live/31", "192.168.1.31", 8000, "admin", "admin@BX");
            BuildWebHost(args).Run();
            Client.Cleanup();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
