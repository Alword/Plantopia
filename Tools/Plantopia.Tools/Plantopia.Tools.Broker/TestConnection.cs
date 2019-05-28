using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Formatter;
using MQTTnet.Server;
using Newtonsoft.Json;

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

        public async Task SubscribeAndPublish()
        {
            var client = new MqttFactory().CreateMqttClient();

            try
            {
                var receivedMessages = new List<MqttApplicationMessageReceivedEventArgs>();
                await client.ConnectAsync(new MqttClientOptionsBuilder().WithTcpServer($"10.11.162.100").WithProtocolVersion(MqttProtocolVersion.V310).Build());
                client.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(e =>
                {
                    lock (receivedMessages)
                    {
                        string msg = e.ApplicationMessage.ConvertPayloadToString();
                        Console.WriteLine(msg);
                        SendDataToServer(msg);
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
                Console.WriteLine($"Test tool down");
                // await server.StopAsync();
            }
        }

        public async void SendDataToServer(string msg)
        {
            var bme280 = JsonConvert.DeserializeObject<Bme280>(msg);

            var data = new DeviceData
            {
                AirHumidity = 0,
                Datetime = bme280.Status.date,
                DeviceDataId = 0,
                DeviceInstanceId = 1,
                Pressure = bme280.Data.Pressure,
                SoilHumidity = bme280.Data.Humidity,
                Temperature = bme280.Data.Temperature
            };

            SendToServer(data);
        }

        public async void SendMockToServer()
        {

            var data = new DeviceData
            {
                AirHumidity = 0,
                Datetime = DateTime.Now,
                DeviceDataId = 0,
                DeviceInstanceId = 1,
                Pressure = 10,
                SoilHumidity = 20,
                Temperature = 30
            };

            SendToServer(data);
        }

        public async void SendToServer(DeviceData data)
        {
            string serverUrl = "https://api.plantopia.ru/api/values/";
            //string serverUrl = "https://localhost:44343/api/values/";


            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://localhost:44343/api/values/", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(response.StatusCode == HttpStatusCode.OK
                    ? $"OK: {responseBody}"
                    : "Неизвестная ошибка");
            }
            finally
            {

            }
        }
    }
}

