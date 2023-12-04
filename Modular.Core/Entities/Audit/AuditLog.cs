#nullable disable

namespace Modular.Core.Entities
{
    public class AuditLog : BaseEntity<int>
    {

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string? Exception { get; set; }

    }
}
