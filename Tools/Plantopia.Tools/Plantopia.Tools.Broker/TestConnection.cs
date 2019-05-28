using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Client.Unsubscribing;
using MQTTnet.Formatter;
using MQTTnet.Protocol;
using MQTTnet.Server;

namespace Plantopia.Tools.Broker
{
    public class TestConnection
    {
        private object locker = new object();
        private static int x = 0;

        public async Task Scanner()
        {
            for (int i = 0; i < 256; i++)
            {
                Test(i);
            }
        }

        public async void Test(int i)
        {
            var client1 = new MqttFactory().CreateMqttClient();
            var client2 = new MqttFactory().CreateMqttClient();

            try
            {
                var receivedMessages = new List<MqttApplicationMessageReceivedEventArgs>();

                await client1.ConnectAsync(new MqttClientOptionsBuilder().WithTcpServer($"10.11.162.{i}")
                    .WithProtocolVersion(MqttProtocolVersion.V310).Build());
                Console.WriteLine($"successs==========10.11.162.{i}");
            }
            catch (Exception e)
            {
                lock (locker)
                {
                    x++;
                    Console.WriteLine($"{x}  {e.Message} 10.11.162.{i}");
                }
            }
        }

        public async Task Subscribe_And_Publish()
        {
            var client = new MqttFactory().CreateMqttClient();
            
            try
            {
                var receivedMessages = new List<MqttApplicationMessageReceivedEventArgs>();
                await client.ConnectAsync(new MqttClientOptionsBuilder().WithTcpServer($"10.11.162.100")
                    .WithProtocolVersion(MqttProtocolVersion.V310).Build());
                client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
                {
                    lock (receivedMessages)
                    {
                        Console.WriteLine($"{e.ApplicationMessage.ConvertPayloadToString()}");
                        receivedMessages.Add(e);
                    }
                });

                await client.SubscribeAsync("devices/lora/#");

                while (true)
                {
                    await Task.Delay(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // await server.StopAsync();
            }
        }
    }
}

