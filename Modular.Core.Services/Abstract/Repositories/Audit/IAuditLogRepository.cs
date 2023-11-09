using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;

namespace Modular.Core.Services.Repositories.Abstract.Audit
{
    public interface IAuditLogRepository : IRepository<AuditLog>, IDisposable
    {
    }
}
