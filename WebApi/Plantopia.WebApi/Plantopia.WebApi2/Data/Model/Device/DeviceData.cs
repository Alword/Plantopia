using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantopia.WebApi2.Data.Model.Device
{
    public class DeviceData
    {
        [Key]
        public int DeviceDataId { get; set; }

        public int DeviceInstanceId { get; set; }

        [ForeignKey(nameof(DeviceInstanceId))]
        public virtual DeviceInstance DeviceInstance { get; set; }

        public DateTime Datetime { get; set; }

        public double Pressure { get; set; }

        public double Temperature { get; set; }

        public double SoilHumidity { get; set; }

        public double AirHumidity { get; set; }
    }
}
