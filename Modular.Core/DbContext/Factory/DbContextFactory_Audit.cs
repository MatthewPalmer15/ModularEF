using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities.Concrete;
using Newtonsoft.Json;

namespace Modular.Core
{
    internal static partial class DbContextFactory
    {

        internal static class Audit
        {

            internal static void OnModelCreating(ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<AuditEntry>(entity =>
                {
                    entity.ToTable("tblAuditEntry");

                    entity.Property(e => e.EntityObject).HasConversion(
                        value => JsonConvert.SerializeObject(value),
                        serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue) ?? new Dictionary<string, object>()
                    );
                });

                modelBuilder.Ignore<AuditLog>();

            }

        }
    }
}
