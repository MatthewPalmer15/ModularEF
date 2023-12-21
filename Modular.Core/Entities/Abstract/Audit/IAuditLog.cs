#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities
{
    public interface IAuditLog : IBaseEntity<int>
    {

        public DateTime Timestamp { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public string? Exception { get; set; }

    }
}
