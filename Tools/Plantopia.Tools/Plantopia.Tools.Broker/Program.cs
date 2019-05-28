using System;
using System.Threading.Tasks;

namespace Plantopia.Tools.Broker
{
    class Program
    {
        static void Main(string[] args)
        {
            TestConnection x = new TestConnection();
            //Task.Run(x.Scanner);
            Task.Run(x.Subscribe_And_Publish);
            Console.ReadLine();
        }
    }
}
