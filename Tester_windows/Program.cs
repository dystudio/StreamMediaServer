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
            Client.PullStream("rtmp://121.42.182.33/live/31", "192.168.1.32", 8000, "admin", "admin@BX");
            Console.WriteLine("已启动");
            Console.ReadLine();
            task = Client.Cleanup();
            task.Wait();
        }
    }
}
