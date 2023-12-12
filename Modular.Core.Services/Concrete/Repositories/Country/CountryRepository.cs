using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities;
using Modular.Core.Interfaces;
using Modular.Core.Services.Repositories.Abstract;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class CountryRepository : ICountryRepository
    {

        #region "  Constructors  "

        public CountryRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly IDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Country> All()
        {
            var query = from country in _context.Countries select country;
            return query;
        }

        public Country? Get(Guid Id)
        {
            return _context.Countries.Where(e => e.Id.Equals(Id)).SingleOrDefault();
        }

        public List<Country> Search(string searchTerm)
        {
            var countries = All();
            countries = countries.Where(x => EF.Functions.Like(searchTerm, x.Name));
            return countries.ToList();
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
