using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Location;
using Modular.Core.Services.Repositories.Abstract.Audit;
using Modular.Core.Services.Repositories.Abstract.Location;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class ContinentRepository : IContinentRepository
    {

        #region "  Constructors  "

        public ContinentRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Continent> All()
        {
            var query = from continent in _context.Continents select continent;
            return query;
        }

        public void Add(Continent continent)
        {
            _context.Continents.Add(continent);
        }

        public void Update(Continent continent)
        {
            continent.Update();
            _context.Continents.Update(continent);
        }

        public void Delete(Continent continent)
        {
            _context.Continents.Remove(continent);
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
