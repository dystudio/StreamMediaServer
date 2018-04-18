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
            //Client.PullStream("rtmp://192.168.1.206/live/30", "192.168.1.30", 8000, "admin", "admin@BX");
            //Client.PullStream("rtmp://192.168.1.206/live/31", "192.168.1.31", 8000, "admin", "admin@BX");
            //Client.PullStream("rtmp://192.168.1.206/live/32", "192.168.1.32", 8000, "admin", "admin@BX");
            //Client.PullStream("rtmp://192.168.1.206/live/33", "192.168.1.33", 8000, "admin", "admin@BX");
           Client.PullStream("rtmp://192.168.1.206/live/34", "192.168.1.34", 8000, "admin", "admin@BX");
            Console.WriteLine("已启动");
            Console.ReadLine();
            task = Client.Cleanup();
            task.Wait();
        }
    }
}
