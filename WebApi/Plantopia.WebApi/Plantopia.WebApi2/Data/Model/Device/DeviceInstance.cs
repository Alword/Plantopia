using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantopia.WebApi2.Data.Model.Device
{
    public class DeviceInstance
    {
        [Key]
        public int DeviceInstanceId { get; set; }

        [Required]
        public int BaseDeviceId { get; set; }
        [ForeignKey(nameof(BaseDeviceId))]
        public virtual BaseDevice BaseDevice { get; set; }

        [MaxLength(16)]
        public string DeviceKey { get; set; }
    }
}
