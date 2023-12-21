#nullable disable

using Modular.Core.Entities.Abstract;

namespace Modular.Core.Entities.Concrete
{
    public class AuditLog : BaseEntity<int>, IAuditLog
    {

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string? Exception { get; set; }

    }
}
