using Plantopia.WebApi2.Data.Enums;

namespace Plantopia.WebApi2.Data.Model.Device
{
    public class DeviceUserAccess
    {
        public int DeviceUserAccessId { get; set; }

        public int DeviceId { get; set; }

        public int UserId { get; set; }

        public RoleType Role { get; set; }
    }
}
