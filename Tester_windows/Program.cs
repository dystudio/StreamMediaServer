using StreamMediaServer.HIKVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester_windows
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Client.Init();
            task.Wait();
            //Client.PullStream("rtmp://121.42.182.33/live/30", "bxxa.f3322.net", 8030, "admin", "admin@BX");
            Client.PullStream("rtmp://121.42.182.33/live/31", "bxxa.f3322.net", 8031, "admin", "admin@BX");
            Client.PullStream("rtmp://121.42.182.33/live/32", "bxxa.f3322.net", 8032, "admin", "admin@BX");
            Client.PullStream("rtmp://121.42.182.33/live/33", "bxxa.f3322.net", 8033, "admin", "admin@BX");
            Client.PullStream("rtmp://121.42.182.33/live/34", "bxxa.f3322.net", 8034, "admin", "admin@BX");
            Console.WriteLine("已启动");
            Console.ReadLine();
            task = Client.Cleanup();
            task.Wait();
        }
    }
}
