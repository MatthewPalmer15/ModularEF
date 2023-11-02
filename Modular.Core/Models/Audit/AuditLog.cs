
#nullable disable

namespace Modular.Core.Models.Audit
{
    public class AuditLog
    {

        public Guid Id { get; set; }

        public string Message { get; set; }

        public string DeviceInformation { get; set; }

        public Guid AuditTrailId { get; set; }

        public AuditTrail AuditTrail { get; set; }


    }
}
