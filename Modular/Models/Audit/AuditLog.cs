using Modular.Core.Helpers.Types;

namespace Modular.Core.Models.Audit
{
    public class AuditLog : BaseEntity
    {

        public ObjectType ObjectType { get; set; } = ObjectType.Unknown;

        public Guid ObjectID { get; set; } = Guid.Empty;

        public string Message { get; set; } = string.Empty;

        public string DeviceInformation { get; set; } = string.Empty;

    }
}
