using Plantopia.WebApi.Domains.Enums;

namespace Plantopia.WebApi.Domains.Model.Device
{
    public class DeviceUserAccess
    {
        public int DeviceUserAccessId { get; set; }

        public int DeviceId { get; set; }

        public int UserId { get; set; }

        public RoleType Role { get; set; }
    }
}
