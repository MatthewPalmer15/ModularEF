using Modular.Core.Entities;
using Modular.Core.Services.Repositories.Abstract;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {

        #region "  Constructors  "

        public CompanyRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Company> All()
        {
            var query = from company in _context.Companies select company;
            return query;
        }

        public Company? Get(Guid Id)
        {
            return _context.Companies.Where(e => e.Id.Equals(Id)).SingleOrDefault();
        }

        public void Add(Company company)
        {
            _context.Companies.Add(company);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
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

        public string SerializeToJson(Company company)
        {
            return JsonConvert.SerializeObject(company, Formatting.Indented);
        }

        public Company? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Company>(json);
            }
            catch
            {
                return null;
            }
        }
        #endregion

    }
}

