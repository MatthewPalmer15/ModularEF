using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;

namespace Modular.Core
{
    internal static class DbContextUtils
    {

        /// <summary>
        /// Converts Microsoft.EntityFrameworkCore.EntityState to Modular.Core.Entities.Abstract.IAuditEntry.ActionType.
        /// </summary>
        /// <param name="entityState"></param>
        /// <returns></returns>
        public static IAuditEntry.ActionType ConvertToActionType(EntityState entityState)
        {
            IAuditEntry.ActionType actionType;
            switch (entityState)
            {
                case EntityState.Added:
                    actionType = IAuditEntry.ActionType.Create;
                    break;

                case EntityState.Modified:
                    actionType = IAuditEntry.ActionType.Update;
                    break;

                case EntityState.Deleted:
                    actionType = IAuditEntry.ActionType.Delete;
                    break;

                default:
                    actionType = IAuditEntry.ActionType.Unknown;
                    break;

            }
            return actionType;
        }

        /// <summary>
        /// Creates an Audit Entry record.
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="actionType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static AuditEntry CreateAuditEntry(EntityEntry entry, IAuditEntry.ActionType actionType, Guid userId)
        {
            AuditEntry auditEntry = new AuditEntry()
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Action = actionType,
                ApplicationUserId = userId,
                EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue?.ToString() ?? "",
                EntityName = entry.Metadata.ClrType.Name,
                EntityObject = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue),

                // TempProperties are properties that are only generated on save, e.g. ID's
                // These properties will be set correctly after the audited entity has been saved
                TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList(),
            };
            return auditEntry;
        }

    }
}
