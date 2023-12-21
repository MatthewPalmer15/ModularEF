#nullable disable

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modular.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modular.Core.Entities.Concrete
{
    public class AuditEntry : BaseEntity<Guid>, IAuditEntry
    {

        public DateTime Timestamp { get; set; }

        public Guid ApplicationUserId { get; set; }

        public IAuditEntry.ActionType Action { get; set; }

        public string EntityId { get; set; }

        public string EntityName { get; set; }

        public Dictionary<string, object> EntityObject { get; set; }

        [NotMapped]
        public List<PropertyEntry> TempProperties { get; set; }

    }
}
