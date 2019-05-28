using System;
using System.Collections.Generic;
using System.Text;

namespace Plantopia.Tools.Broker
{
    public class DeviceData
    {
        public int DeviceDataId { get; set; }

        public int DeviceInstanceId { get; set; }

        public DateTime Datetime { get; set; }

        public double Pressure { get; set; }

        public double Temperature { get; set; }

        public double SoilHumidity { get; set; }

        public double AirHumidity { get; set; }
    }
}
