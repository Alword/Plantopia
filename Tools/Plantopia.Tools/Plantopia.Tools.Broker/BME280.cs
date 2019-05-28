using System;
using System.Collections.Generic;
using System.Text;

namespace Plantopia.Tools.Broker
{
    public class Bme280
    {
        public BmeData Data;
        public BmeStatus Status;
    }

    public class BmeData
    {
        public double Temperature;
        public double Humidity;
        public double Pressure;
    }

    public class BmeStatus
    {
        public string DevEUI;
        public double Rssi;
        public double Temperature;
        public double Battery;
        public DateTime date;
    }
}
