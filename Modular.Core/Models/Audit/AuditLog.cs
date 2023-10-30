
#nullable disable

namespace Modular.Core.Models.Audit
{
    public class AuditLog : BaseEntity
    {

        public string Message { get; set; }

        public string DeviceInformation { get; set; }



    }
}
