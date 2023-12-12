using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities;
using Modular.Core.Interfaces;
using Modular.Core.Services.Repositories.Abstract;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class ConfigurationRepository : IConfigurationRepository
    {

        #region "  Constructors  "

        public ConfigurationRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly IDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Configuration> All()
        {
            var query = from configuration in _context.Configurations select configuration;
            return query;
        }

        public string GetValue(string key)
        {
            var query = All();
            query = query.Where(configuration => configuration.Key.Trim().ToUpper() == key.Trim().ToUpper());

            Configuration? config = query.SingleOrDefault();

            return config != null ? config.Value : string.Empty;
        }

        public Configuration? Get(Guid Id)
        {
            return _context.Configurations.Where(e => e.Id.Equals(Id)).SingleOrDefault();
        }

        public List<Configuration> Search(string searchTerm)
        {
            var configurations = All();
            configurations = configurations.Where(x => EF.Functions.Like(searchTerm, x.Key));
            return configurations.ToList();
        }

        public void Add(Configuration configuration)
        {
            _context.Configurations.Add(configuration);
        }

        public void Update(Configuration configuration)
        {
            _context.Configurations.Update(configuration);
        }

        public void Delete(Configuration configuration)
        {
            _context.Configurations.Remove(configuration);
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

        public string SerializeToJson(Configuration configuration)
        {
            return JsonConvert.SerializeObject(configuration, Formatting.Indented);
        }

        public Configuration? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Configuration>(json);
            }
            catch
            {
                return null;
            }
        }

        #endregion


    }
}
