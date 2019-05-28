using System.ComponentModel.DataAnnotations;

namespace Plantopia.WebApi2.Data.Model.Device
{
    public class BaseDevice
    {
        [Key]
        public int BaseDeviceId { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }
    }
}
