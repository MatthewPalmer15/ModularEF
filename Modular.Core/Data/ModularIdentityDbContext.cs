using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modular.Core.Identity;
using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Models.Entity;
using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using Modular.Core.Services.Factories.Config;
using Modular.Core.Services.Factories.Entity;
using Modular.Core.Services.Factories.Identity;
using Modular.Core.Services.Factories.Location;
using Modular.Core.Services.Factories.Misc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using System.Text;

namespace Modular.Core
{
    public class ModularIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        #region "  Constructors  "

        public ModularIdentityDbContext()
        {
            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIV);
        }

        public ModularIdentityDbContext(DbContextOptions<ModularDbContext> options) : base(options)
        {
            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIV);
        }

        #endregion

        #region "  Constants  "

        internal static readonly byte[] EncryptionKey = new byte[32]{ 218, 67, 67, 63, 204, 244, 241, 114, 106, 200, 253, 68, 254, 170, 233, 174, 241, 127, 130, 233, 16, 17, 217, 204, 18, 174, 7, 247, 196, 98, 133, 163 };

        internal static readonly byte[] EncryptionIV = new byte[16]{ 58, 191, 153, 193, 2, 157, 167, 89, 225, 55, 84, 168, 83, 75, 77, 242 };

        private readonly IEncryptionProvider _encryptionProvider;

        #endregion

        #region "  DbSets  "

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            //  Identity
            IdentityFactory.OnModelCreating(builder);

            builder.Entity<AuditEntry>(entity =>
            {
                entity.ToTable("tblAuditEntry");

                entity.Property(e => e.EntityObject).HasConversion(
                    value => JsonConvert.SerializeObject(value),
                    serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue) ?? new Dictionary<string, object>()
                );
            });

            builder.Entity<AuditRequestLog>(entity =>
            {
                entity.ToTable("tblAuditRequestLog");
            });

            builder.UseEncryption(_encryptionProvider);
        }

    }
}
