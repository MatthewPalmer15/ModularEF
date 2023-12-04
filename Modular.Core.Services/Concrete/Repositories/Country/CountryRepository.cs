using Modular.Core.Entities;
using Modular.Core.Services.Repositories.Abstract;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class CountryRepository : ICountryRepository
    {

        #region "  Constructors  "

        public CountryRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Country> All()
        {
            var query = from country in _context.Countries select country;
            return query;
        }

        public Country? Get(Guid id)
        {
            return _context.Countries.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public void Add(Country country)
        {
            _context.Countries.Add(country);
        }

        public void Update(Country country)
        {
            _context.Countries.Update(country);
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
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

        public string SerializeToJson(Country country)
        {
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        public Country? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Country>(json);
            }
            catch
            {
                return null;
            }
        }

        #endregion

    }
}
