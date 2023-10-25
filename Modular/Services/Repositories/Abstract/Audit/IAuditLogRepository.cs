using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services.Repositories.Abstract.Audit
{
    public interface IAuditLogRepository : IRepository<AuditLog>, IDisposable
    {
    }
}
