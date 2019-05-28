using System;
using System.Threading.Tasks;

namespace Plantopia.Tools.Broker
{
    class Program
    {
        static void Main(string[] args)
        {
            TestConnection x = new TestConnection();

            x.SendMockToServer();
            //Task.Run(x.Scanner);
            //Task.Run(x.SubscribeAndPublish);
            Console.ReadLine();
        }
    }
}
