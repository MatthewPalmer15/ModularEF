using Modular.Core.Models.Audit;
using Modular.Core.Models.Config;
using Modular.Core.Services.Repositories.Abstract.Audit;

namespace Modular.Core.Services.Repositories.Concrete.Audit
{
    public class AuditLogRepository : IAuditLogRepository
    {

        #region "  Constructors  "

        public AuditLogRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<AuditLog> All()
        {
            var query = from auditLog in _context.AuditLogs select auditLog;
            return query;
        }

        public AuditLog? Get(Guid id)
        {
            return _context.AuditLogs.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public void Add(AuditLog auditLog)
        {
            _context.AuditLogs.Add(auditLog);
        }

        public void Update(AuditLog auditLog)
        {
            _context.AuditLogs.Update(auditLog);
        }

        public void Delete(AuditLog auditLog)
        {
            _context.AuditLogs.Remove(auditLog);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


        #endregion


    }
}
